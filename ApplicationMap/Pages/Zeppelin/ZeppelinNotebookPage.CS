using FrameworkCore.Extensions;
using PlaywrightSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationMap.Pages.Zeppelin
{
	public sealed class ZeppelinNotebookPage
	{
		// TODO: Add URL (Could Save The Notebook ID To The Context Dictionary And Require It For The Constructor)

		public readonly IPage Self;
		public ZeppelinNotebookPage(IPage Page) => Self = Page;

		private string RunAllParagraphsButton => "button[ng-click='runAllParagraphs(note.id)']";
		private string RunAllParagraphsAcceptButton => "text='OK'";

		public async Task RunAllParagraphs()
		{
			await Self.ClickAsync(RunAllParagraphsButton);
			await Self.ClickAsync(RunAllParagraphsAcceptButton);
		}

		private async Task<IEnumerable<IElementHandle>> GetParagraphStatuses() => await Self.QuerySelectorAllAsync("div[ng-show='!asIframe'] > span.ng-binding");

		public async Task<bool> ParagraphsExecutedSuccessfully()
		{
			var allParagraphsHaveExecuted = false;
			var noParagraphErrors = true;

			while (allParagraphsHaveExecuted.Equals(false) && noParagraphErrors.Equals(true))
			{
				await Task.Delay(2500);

				var inProgress = 0;
				var errors = 0;

				foreach (var status in await GetParagraphStatuses())
				{
					if (!(await status.GetInnerTextAsync()).Flatten().Equals("FINISHED")) inProgress++;
					if ((await status.GetInnerTextAsync()).Flatten().Equals("ERROR")) errors++;
				}

				if (inProgress.Equals(0)) allParagraphsHaveExecuted = true;
				if (!errors.Equals(0)) noParagraphErrors = false;
			}

			return allParagraphsHaveExecuted.Equals(true) && noParagraphErrors.Equals(true);
		}
	}
}