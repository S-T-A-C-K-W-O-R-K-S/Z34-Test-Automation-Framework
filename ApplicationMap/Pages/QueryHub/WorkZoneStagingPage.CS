using ApplicationMap.Pages.Common;
using FrameworkCore.Configuration;
using FrameworkCore.Extensions;
using PlaywrightSharp;
using System.Threading.Tasks;

namespace ApplicationMap.Pages.QueryHub
{
    public sealed class WorkZoneStagingPage : WorkZonePageWithGrid
    {
        public override string URL => Z34.Host.QueryHub + "qh/qh-app/#/work-zone/staging";

        public WorkZoneStagingPage(IPage Page) : base(Page) { }

        private string ValidateAllButton => "button[title='Validate All']";
        private string PublishAllButton => "button[title='Publish All']";
        private string RemoveAllButton => "button[title='Remove All']";
        private string StatusHeaderCell => "div.ag-header-cell[col-id=STATUS]";

        public async Task ValidateStagedObjects()
        {
            await ContinuouslyRefreshGridAndWaitForRows("BEF_MY_WORKZONE");
            await Self.ClickAsync(ValidateAllButton);
        }

        public async Task PublishStagedObjects()
            => await Self.ClickAsync(PublishAllButton);

        public async Task<bool> ValidatedSuccessfully()
            => await StagedObjectsHaveBeenValidated();

        public async Task<bool> PublishedSuccessfully()
            => await StagedObjectsHaveBeenPublished();

        private async Task OrderByStatus()
        {
            await Self.ClickAsync(StatusHeaderCell);
            await Task.Delay(250);
        }

        #region Unreliable Page Logic

        private async Task<bool> StagedObjectsHaveBeenValidated(int retries = 25)
        {
            bool allObjectsHaveBeenValidated = false;

            #region Code Logic Description
            // Reads All Values In The STATUS Column In Both Ascending Order And Descending Order
            // At The End Of The Loop, Resets The STATUS Column Order To The Default Unordered State
            // Also Checks Whether All Results On The First Page Are The Same In Both Ascending And Descending Order
            // The Above Means That There Are No Other Values In-Between, So All Values Must Be The Same
            #endregion

            for (var i = 0; i < retries && allObjectsHaveBeenValidated.Equals(false); i++)
            {
                await RefreshGridAndWaitForRows("BEF_MY_WORKZONE");

                var grid = await Self.ProcessAngularGrid();

                var objectsInAscendingOrderHaveBeenValidated = true;
                var objectsInDecendingOrderHaveBeenValidated = true;

                await OrderByStatus();

                foreach (var cell in grid.Columns["STATUS"]?.GetColumnValues<string>())
                    objectsInAscendingOrderHaveBeenValidated =
                        objectsInAscendingOrderHaveBeenValidated && cell.Equals("Validated");

                await OrderByStatus();

                foreach (var cell in grid.Columns["STATUS"]?.GetColumnValues<string>())
                    objectsInDecendingOrderHaveBeenValidated =
                        objectsInDecendingOrderHaveBeenValidated && cell.Equals("Validated");

                await OrderByStatus();

                allObjectsHaveBeenValidated = (objectsInAscendingOrderHaveBeenValidated && objectsInDecendingOrderHaveBeenValidated);
            }

            return allObjectsHaveBeenValidated;
        }

        private async Task<bool> StagedObjectsHaveBeenPublished(int retries = 25)
        {
            bool allObjectsHaveBeenPublished = false;

            for (var i = 0; i < retries && allObjectsHaveBeenPublished.Equals(false); i++)
            {
                await RefreshGrid("BEF_MY_WORKZONE");
                allObjectsHaveBeenPublished = (await Self.ProcessAngularGrid()).Rows.Count.Equals(0);
            }

            return allObjectsHaveBeenPublished;
        }

        #endregion
    }
}