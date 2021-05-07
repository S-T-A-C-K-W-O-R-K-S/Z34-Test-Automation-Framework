using ApplicationMap.Elements.Common;
using FrameworkCore.Extensions;
using PlaywrightSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ApplicationMap.Pages.Common
{
	public abstract class BaseQueryHubPage
	{
		public virtual string URL { get; set; }

		public readonly IPage Self;
		public BaseQueryHubPage(IPage Page) => Self = Page;

		public TitleBar TitleBar => new TitleBar(Self);
		public NavigationBar NavigationBar => new NavigationBar(Self);

		public async Task<IEnumerable<IElementHandle>> GetNotifications() => await Self.QuerySelectorAllAsync("div.notification");

		public (int Success, int Warning, int Error) GetNotificationsCount(IEnumerable<IElementHandle> notifications)
		{
			var success = notifications.Where(notification => notification.GetAttributeAsync("class").Result.Contains("notification__success")).Count();
			var warning = notifications.Where(notification => notification.GetAttributeAsync("class").Result.Contains("notification__warning")).Count();
			var error = notifications.Where(notification => notification.GetAttributeAsync("class").Result.Contains("notification__error")).Count();

			return (success, warning, error);
		}

		public async Task NavigateToHomePage()
			=> await Self.ClickAsync(NavigationBar.HomeTab);

		private async Task NavigateToUploadImportware(string navbarTab)
		{
			await Self.ClickAsync(NavigationBar.UploadTab);
			await Self.ClickAsync(navbarTab);
			await Self.WaitForResponseAsync(response => response.Url.Contains("GET_ALL_WORKFLOWS_BY_TAG"));
			await Self.WaitForResponseAsync(response => response.Url.Contains("GET_WFVARIABLES"));
		}

		public async Task NavigateToUploadDataPage()
			=> await NavigateToUploadImportware(NavigationBar.UploadTabsGroup.UploadDataTab);

		public async Task NavigateToUploadMetadataPage()
			=> await NavigateToUploadImportware(NavigationBar.UploadTabsGroup.UploadMetadataTab);


		public async Task NavigateToStagingArea()
		{
			await Self.ClickAsync(NavigationBar.WorkZoneTab);
			await Self.ClickAsync(NavigationBar.WorkZoneTabsGroup.WorkZoneStagingTab);
			await Self.WaitForResponseAsync(response => response.Url.Contains("BEF_MY_WORKZONE"));
			await Task.Delay(2500);
		}

		public async Task NavigateToInBasket()
		{
			await Self.ClickAsync(NavigationBar.WorkZoneTab);
			await Self.ClickAsync(NavigationBar.WorkZoneTabsGroup.WorkZoneInBasketTab);
			await Self.WaitForResponseAsync(response => response.Url.Contains("CP_BATCH_LIST4USER"));
			await Task.Delay(2500);
		}

		public async Task NavigateToZeppelin(FeatureContext context)
		{
			await Self.ClickAsync(NavigationBar.NotebooksTab);
			do { await Task.Delay(2500); } while (context.GetPageInstance().Context.Pages.Length.Equals(1));
			context.SetPageInstance((from page in context.GetPageInstance().Context.Pages where page.Url.Contains("bi") select page).Single());
		}
	}
}