using PlaywrightSharp;
using System.Threading.Tasks;
using System.Linq;
using FrameworkCore.Configuration;
using ApplicationMap.Pages.Common;
using FrameworkCore.Extensions;
using static FrameworkCore.Extensions.IPageExtensions;
using static FrameworkCore.Extensions.DataColumnExtensions;
using System;
using System.Diagnostics;

namespace ApplicationMap.Pages.QueryHub
{
	public sealed class WorkZoneInBasketPage : WorkZonePageWithGrid
	{
		public override string URL => Z34.Host.QueryHub + "qh/qh-app/#/work-zone/in-basket";

		public WorkZoneInBasketPage(IPage Page) : base(Page) { }

		public async Task<string> GetBatchType(string batch)
			=> await GetValueFromFirstRowCellInNamedColumn("TYPE", batch);

		public async Task<bool> DataIngestedSuccessfully(string batch)
			=> int.Parse(await GetValueFromFirstRowCellInNamedColumn("STEP ERRORS", batch)).Equals(0);

		#region Unreliable Page Logic

		private async Task<string> GetValueFromFirstRowCellInNamedColumn(string columnName, string batchName, int retryForSeconds = 25)
		{
			string visibleBatchType = string.Empty;

			var stopWatch = new Stopwatch();
			stopWatch.Start();

			while (stopWatch.Elapsed.Seconds < retryForSeconds && visibleBatchType.Equals(batchName).Equals(false))
			{
				await RefreshGridAndWaitForRows("CP_BATCH_LIST4USER");
				var grid = await Self.ProcessAngularGrid();
				var retrievedBatchType = grid.Columns["Type"].GetColumnValues<string>().FirstOrDefault();
				visibleBatchType = retrievedBatchType is not null ? retrievedBatchType : string.Empty;
			}

			stopWatch.Stop();

			if (visibleBatchType.Equals(batchName))
				return (await Self.ProcessAngularGrid()).Columns[columnName].GetColumnValues<string>().FirstOrDefault();

			throw new ArgumentOutOfRangeException(nameof(batchName), batchName, $"Batch Does Not Exist: {batchName}");
		}

		#endregion
	}
}