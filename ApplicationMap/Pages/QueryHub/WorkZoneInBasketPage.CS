using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationMap.Pages.Common;
using FrameworkCore.Configuration;
using FrameworkCore.Extensions;
using PlaywrightSharp;

namespace ApplicationMap.Pages.QueryHub
{
    public sealed class WorkZoneInBasketPage : WorkZonePageWithGrid
    {
        public WorkZoneInBasketPage(IPage Page) : base(Page)
        {
        }

        public override string URL => Z34.Host.QueryHub + "qh/qh-app/#/work-zone/in-basket";

        public async Task<string> GetBatchType(string batch)
        {
            return await GetValueFromFirstRowCellInNamedColumn("TYPE", batch);
        }

        public async Task<bool> DataIngestedSuccessfully(string batch)
        {
            return int.Parse(await GetValueFromFirstRowCellInNamedColumn("STEP ERRORS", batch)).Equals(0);
        }

        #region Unreliable Page Logic

        private async Task<string> GetValueFromFirstRowCellInNamedColumn(string columnName, string batchName,
            int retryForSeconds = 25)
        {
            var visibleBatchType = string.Empty;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.Elapsed.Seconds < retryForSeconds && visibleBatchType.Equals(batchName).Equals(false))
            {
                await RefreshGridAndWaitForRows("CP_BATCH_LIST4USER");
                var grid = await Self.ProcessAngularGrid();
                var retrievedBatchType = grid.Columns["Type"].GetColumnValues<string>().FirstOrDefault();
                visibleBatchType = retrievedBatchType ?? string.Empty;
            }

            stopWatch.Stop();

            if (visibleBatchType.Equals(batchName))
                return (await Self.ProcessAngularGrid()).Columns[columnName].GetColumnValues<string>().FirstOrDefault();

            throw new ArgumentOutOfRangeException(nameof(batchName), batchName, $"Batch Does Not Exist: {batchName}");
        }

        #endregion
    }
}