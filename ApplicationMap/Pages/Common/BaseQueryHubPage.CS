using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationMap.Elements.Common;
using FrameworkCore.Extensions;
using PlaywrightSharp;
using TechTalk.SpecFlow;

namespace ApplicationMap.Pages.Common
{
    public abstract class BaseQueryHubPage
    {
        public readonly IPage Self;

        protected BaseQueryHubPage(IPage Page)
        {
            Self = Page;
        }

        public virtual string URL { get; set; }

        public TitleBar TitleBar => new(Self);
        public NavigationBar NavigationBar => new(Self);

        public async Task<IEnumerable<IElementHandle>> GetNotifications()
        {
            return await Self.QuerySelectorAllAsync("div.notification");
        }

        public (int Success, int Warning, int Error) GetNotificationsCount(IEnumerable<IElementHandle> notifications)
        {
            var success = notifications.Count(notification => notification.GetAttributeAsync("class").Result.Contains("notification__success"));
            var warning = notifications.Count(notification => notification.GetAttributeAsync("class").Result.Contains("notification__warning"));
            var error = notifications.Count(notification => notification.GetAttributeAsync("class").Result.Contains("notification__error"));

            return (success, warning, error);
        }

        public async Task NavigateToHomePage()
        {
            await Self.ClickAsync(NavigationBar.HomeTab);
        }

        private async Task NavigateToUploadImportware(string navbarTab)
        {
            await Self.ClickAsync(NavigationBar.UploadTab);
            await Self.ClickAsync(navbarTab);
            await Self.WaitForResponseAsync(response => response.Url.Contains("GET_ALL_WORKFLOWS_BY_TAG"));
            await Self.WaitForResponseAsync(response => response.Url.Contains("GET_WFVARIABLES"));
        }

        public async Task NavigateToUploadDataPage()
        {
            await NavigateToUploadImportware(NavigationBar.UploadTabsGroup.UploadDataTab);
        }

        public async Task NavigateToUploadMetadataPage()
        {
            await NavigateToUploadImportware(NavigationBar.UploadTabsGroup.UploadMetadataTab);
        }


        public async Task NavigateToStagingArea()
        {
            await Self.ClickAsync(NavigationBar.WorkZoneTab);
            await Self.ClickAsync(NavigationBar.WorkZoneTabsGroup.WorkZoneStagingTab);
            await Self.WaitForResponseAsync(response => response.Url.Contains("BEF_MY_WORKZONE"));
        }

        public async Task NavigateToInBasket()
        {
            await Self.ClickAsync(NavigationBar.WorkZoneTab);
            await Self.ClickAsync(NavigationBar.WorkZoneTabsGroup.WorkZoneInBasketTab);
            await Self.WaitForResponseAsync(response => response.Url.Contains("CP_BATCH_LIST4USER"));
        }

        public async Task NavigateToZeppelin(FeatureContext context)
        {
            await Self.ClickAsync(NavigationBar.NotebooksTab);
            do
            {
                await Task.Delay(2500);
            } while (context.GetPageInstance().Context.Pages.Length.Equals(1));

            context.SetPageInstance((from page in context.GetPageInstance().Context.Pages
                where page.Url.Contains("bi")
                select page).Single());
        }
    }
}