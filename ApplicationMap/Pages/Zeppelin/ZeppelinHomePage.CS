using FrameworkCore.Configuration;
using PlaywrightSharp;
using System.IO;
using System.Threading.Tasks;

namespace ApplicationMap.Pages.Zeppelin
{
	public sealed class ZeppelinHomePage
	{
		public string URL = Z34.Host.Zeppelin + "bi/#/";

		public readonly IPage Self;
		public ZeppelinHomePage(IPage Page) => Self = Page;

		private string UserDropdown => "button.dropdown-toggle";
		private string NotebookUploadInput => "input[type='file']";
		private string OKButton => "button:text('OK')";
		private string NotebookNode => "div.note-folder-item";
		private string NotebookFilter => "input.note-name-query";

		public async Task<string> GetLoggedInUserName()
			=> await Self.GetInnerTextAsync(UserDropdown);

		public async Task ImportNotebook(string path, string notebookName)
		{
			await Self.WaitForSelectorAsync(NotebookFilter);

			await Task.Delay(250);

			var (Notebook, Actions) = await GetNotebookAndActions(notebookName);

			if (Notebook is not null)
			{
				await Notebook.HoverAsync(); await Task.Delay(250);
				await Actions.Delete.ClickAsync(); await Task.Delay(250);
				await Self.ClickAsync(OKButton); await Task.Delay(250);
			}

			await Self.SetInputFilesAsync(NotebookUploadInput, Directory.GetFiles(path));
			await Self.WaitForSelectorAsync($"a:text('{notebookName}')");
		}

		public async Task<bool> NotebookExists(string notebookName)
		{
			var (Notebook, _) = await GetNotebookAndActions(notebookName);

			if (Notebook is not null)
				if (await Notebook.IsVisibleAsync())
					return true;

			return false;
		}

		public async Task OpenNotebook(string notebookName)
		{
			var (Notebook, _) = await GetNotebookAndActions(notebookName);
			if (Notebook is not null)
				if (await Notebook.IsVisibleAsync())
					await Notebook.ClickAsync();
		}

		private async Task<(IElementHandle Notebook, (IElementHandle Rename, IElementHandle ClearOutput, IElementHandle Delete) Actions)> GetNotebookAndActions(string notebookName)
		{
			var notebookNodes = await Self.QuerySelectorAllAsync(NotebookNode);

			foreach (var notebookNode in notebookNodes)
				if ((await notebookNode.QuerySelectorAsync($"a:text('{notebookName}')")) is not null)
					return (await notebookNode.QuerySelectorAsync($"a:text('{notebookName}')"),
						(await notebookNode.QuerySelectorAsync("i[ng-click*='renameNote']"),
						await notebookNode.QuerySelectorAsync("i[ng-click*='clearAllParagraphOutput']"),
						await notebookNode.QuerySelectorAsync("i[ng-click*='moveNoteToTrash']")));

			return (null, (null, null, null));
		}
	}
}