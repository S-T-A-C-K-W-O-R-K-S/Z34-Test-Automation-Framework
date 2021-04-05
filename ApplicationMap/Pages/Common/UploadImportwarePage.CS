using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FrameworkCore.Configuration;
using FrameworkCore.Extensions;
using PlaywrightSharp;

namespace ApplicationMap.Pages.Common
{
    public abstract class UploadImportwarePage : BaseQueryHubPage
    {
        public new readonly IPage Self;

        public UploadImportwarePage(IPage Page) : base(Page)
        {
            Self = Page;
        }

        public IEnumerable<IElementHandle> FileUploadNotifications { get; set; }
        public (int Success, int Warning, int Error) FileUploadNotificationsCount { get; set; }
        protected int UploadedFilesCount { get; set; }

        public string UploadDropZone => "div.upload-drop-zone";
        public string FileUploadInput => "input[type='file']";
        public string SelectWorkflowInput => "input[role='combobox']";
        private string UploadButton => "button.btn-primary[title='Upload']";

        private async Task<IEnumerable<IElementHandle>> GetUploadSourceOptions()
        {
            return await Self.QuerySelectorAllAsync("input[type='radio']");
        }

        private async Task<IEnumerable<IElementHandle>> GetDropdownOptions()
        {
            return await Self.QuerySelectorAllAsync("div.ng-option");
        }

        public async Task<string> UploadSource()
        {
            return (from option in await GetUploadSourceOptions()
                where option.IsCheckedAsync().Result.Equals(true)
                select option.GetAttributeAsync("value").Result).Single();
        }

        public async Task SelectWorkflow(string workflow)
        {
            await Self.ClickAsync(SelectWorkflowInput);

            do
            {
                await Task.Delay(500);
            } while ((await GetDropdownOptions()).None());

            foreach (var option in await GetDropdownOptions())
            {
                var optionInnerText = await option.GetInnerTextAsync();

                if (optionInnerText.Flatten().Equals(workflow.Flatten())) await option.ClickAsync();

                break;
            }
        }

        public async Task StageFiles(string path)
        {
            await Self.SetInputFilesAsync(FileUploadInput, Directory.GetFiles(path));
            UploadedFilesCount = Directory.GetFiles(path).Length;
        }

        protected async Task UploadStagedFiles()
        {
            await Self.ClickAsync(UploadButton);
            FileUploadNotifications = await GetNotifications();
            FileUploadNotificationsCount = GetNotificationsCount(FileUploadNotifications);

            for (var i = 0; i < UploadedFilesCount; i++)
                await Self.WaitForResponseAsync(Z34.Host.QueryHub + "qh/api/upload", 150000);
        }
    }
}