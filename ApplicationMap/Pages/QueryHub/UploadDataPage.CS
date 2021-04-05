using System.Threading.Tasks;
using ApplicationMap.Pages.Common;
using FrameworkCore.Configuration;
using PlaywrightSharp;

namespace ApplicationMap.Pages.QueryHub
{
    public sealed class UploadDataPage : UploadImportwarePage
    {
        public UploadDataPage(IPage Page) : base(Page)
        {
        }

        public override string URL => Z34.Host.QueryHub + "qh/qh-app/#/upload/data";

        public async Task UploadStagedData()
        {
            await UploadStagedFiles();
        }
    }
}