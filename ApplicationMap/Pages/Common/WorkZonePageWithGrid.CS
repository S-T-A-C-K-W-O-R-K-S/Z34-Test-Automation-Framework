using FrameworkCore.Extensions;
using PlaywrightSharp;
using System;
using System.Threading.Tasks;

namespace ApplicationMap.Pages.Common
{
    public abstract class WorkZonePageWithGrid : BaseQueryHubPage
    {
        public new readonly IPage Self;
        public WorkZonePageWithGrid(IPage Page) : base(Page) => Self = Page;

        private string RefreshGridButton => "button[title='Refresh Grid']";
        private string GridBodyRow => "div.ag-center-cols-container > div.ag-row";

		protected async Task RefreshGrid(string query)
		{
			await Self.ClickAsync(RefreshGridButton);
			await Self.WaitForResponseAsync(response => response.Url.Contains(query));
		}

		protected async Task RefreshGridAndWaitForRows(string query)
		{
			await RefreshGrid(query);
			await Self.WaitForSelectorAsync(GridBodyRow);
			await Task.Delay(250);
		}

		protected async Task ContinuouslyRefreshGridAndWaitForRows(string query)
		{
			while (!(await Self.IsVisibleAsync(GridBodyRow)))
			{
				await RefreshGrid(query);

				try { await Self.WaitForSelectorAsync(selector: GridBodyRow, timeout: 2500); }
				catch(TimeoutException) { /* A Timeout Is Expected While The Selector Doesn't Exist */ }
			}
		}
	}
}