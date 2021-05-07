using ApplicationMap.Pages.Common;
using FrameworkCore.Configuration;
using PlaywrightSharp;
using System.Threading.Tasks;

namespace ApplicationMap.Pages.QueryHub
{
	public sealed class UploadDataPage : UploadImportwarePage
	{
		public override string URL => Z34.Host.QueryHub + "qh/qh-app/#/upload/data";

		public UploadDataPage(IPage Page) : base(Page) { }

		public async Task UploadStagedData()
			=> await UploadStagedFiles();
	}
}