using ApplicationMap.Pages.Common;
using FrameworkCore.Configuration;
using PlaywrightSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationMap.Pages.QueryHub
{
	public sealed class UploadMetadataPage : UploadImportwarePage
	{
		public override string URL => Z34.Host.QueryHub + "qh/qh-app/#/upload/metadata";

		public UploadMetadataPage(IPage Page) : base(Page) { }

		public IEnumerable<IElementHandle> StagingAreaNotifications { get; set; }
		public (int Success, int Warning, int Error) StagingAreaNotificationsCount { get; set; }

		private string ClearNotificationButton => "button.clear-notification-btn";

		public async Task<(int Success, int Warning, int Error)> GetStagingAreaNotificationsCount()
		{
			StagingAreaNotifications = await GetNotifications();
			StagingAreaNotificationsCount = GetNotificationsCount(StagingAreaNotifications);
			return StagingAreaNotificationsCount;
		}

		public async Task ClearStagingAreaNotifications()
		{
			foreach (var notification in StagingAreaNotifications)
				await (await notification.QuerySelectorAsync(ClearNotificationButton)).ClickAsync();
		}

		public async Task UploadStagedMetadata()
		{
			await ClearStagingAreaNotifications();
			await UploadStagedFiles();
		}
	}
}