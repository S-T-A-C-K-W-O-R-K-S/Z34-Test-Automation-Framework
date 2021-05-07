using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using PlaywrightSharp;

namespace FrameworkCore.Helpers
{
    public static class HTMLTableHelpers
    {
        public class PlaywrightHTMLTableProcessor
        {
            private IPage PlaywrightPage { get; set; }
            private string TableSelector { get; set; }
            private string HeaderRowSelector { get; set; }
            private string HeaderCellSelector { get; set; }
            private string BodyRowSelector { get; set; }
            private string BodyCellSelector { get; set; }

            public PlaywrightHTMLTableProcessor(PlaywrightHTMLTableProcessorOptions options)
            {
                PlaywrightPage = options.PlaywrightPage;
                TableSelector = options.TableSelector;
                HeaderRowSelector = options.HeaderRowSelector;
                HeaderCellSelector = options.HeaderCellSelector;
                BodyRowSelector = options.BodyRowSelector;
                BodyCellSelector = options.BodyCellSelector;
            }

            public async Task<DataTable> ProcessHTMLTable()
                => await ParseHTMLTable(await GetHTMLTable());


            private async Task<IElementHandle> GetHTMLTable()
                => await PlaywrightPage.QuerySelectorAsync(TableSelector);


            private async Task<DataTable> ParseHTMLTable(IElementHandle table)
            {
				var dataTable = new DataTable { Locale = new CultureInfo("en-GB") };

				foreach (var cell in await (await table.QuerySelectorAsync(HeaderRowSelector)).QuerySelectorAllAsync(HeaderCellSelector))
                    dataTable.Columns.Add((await cell.GetInnerTextAsync()).Trim());

                foreach (var row in await table.QuerySelectorAllAsync(BodyRowSelector))
                    dataTable.Rows.Add((await row.QuerySelectorAllAsync(BodyCellSelector))
                        .Select(cell => cell.GetInnerTextAsync()).Select(task => task.Result.Trim()).ToArray());

                return dataTable;
            }
        }

        public class PlaywrightHTMLTableProcessorOptions
        {
            public IPage PlaywrightPage { get; set; }
            public string TableSelector { get; set; }
            public string HeaderRowSelector { get; set; }
            public string HeaderCellSelector { get; set; }
            public string BodyRowSelector { get; set; }
            public string BodyCellSelector { get; set; }

            public PlaywrightHTMLTableProcessorOptions
                (IPage playwrightPage, string tableSelector, string headerRowSelector, string headerCellSelector, string bodyRowSelector, string bodyCellSelector)
            {
                PlaywrightPage = playwrightPage;
                TableSelector = tableSelector;
                HeaderRowSelector = headerRowSelector;
                HeaderCellSelector = headerCellSelector;
                BodyRowSelector = bodyRowSelector;
                BodyCellSelector = bodyCellSelector;
            }
        }
    }
}