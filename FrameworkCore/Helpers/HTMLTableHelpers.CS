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
            public PlaywrightHTMLTableProcessor(PlaywrightHTMLTableProcessorOptions options)
            {
                PlaywrightPage = options.PlaywrightPage;
                TableSelector = options.TableSelector;
                HeaderRowSelector = options.HeaderRowSelector;
                HeaderCellSelector = options.HeaderCellSelector;
                BodyRowSelector = options.BodyRowSelector;
                BodyCellSelector = options.BodyCellSelector;
            }

            private IPage PlaywrightPage { get; }
            private string TableSelector { get; }
            private string HeaderRowSelector { get; }
            private string HeaderCellSelector { get; }
            private string BodyRowSelector { get; }
            private string BodyCellSelector { get; }

            public async Task<DataTable> ProcessHTMLTable()
            {
                return await ParseHTMLTable(await GetHTMLTable());
            }


            private async Task<IElementHandle> GetHTMLTable()
            {
                return await PlaywrightPage.QuerySelectorAsync(TableSelector);
            }


            private async Task<DataTable> ParseHTMLTable(IElementHandle table)
            {
                var dataTable = new DataTable {Locale = new CultureInfo("en-GB")};

                foreach (var cell in await (await table.QuerySelectorAsync(HeaderRowSelector)).QuerySelectorAllAsync(
                    HeaderCellSelector))
                    dataTable.Columns.Add((await cell.GetInnerTextAsync()).Trim());

                foreach (var row in await table.QuerySelectorAllAsync(BodyRowSelector))
                    dataTable.Rows.Add((await row.QuerySelectorAllAsync(BodyCellSelector))
                        .Select(cell => cell.GetInnerTextAsync()).Select(task => task.Result.Trim()).ToArray());

                return dataTable;
            }
        }

        public class PlaywrightHTMLTableProcessorOptions
        {
            public PlaywrightHTMLTableProcessorOptions
            (IPage playwrightPage, string tableSelector, string headerRowSelector, string headerCellSelector,
                string bodyRowSelector, string bodyCellSelector)
            {
                PlaywrightPage = playwrightPage;
                TableSelector = tableSelector;
                HeaderRowSelector = headerRowSelector;
                HeaderCellSelector = headerCellSelector;
                BodyRowSelector = bodyRowSelector;
                BodyCellSelector = bodyCellSelector;
            }

            public IPage PlaywrightPage { get; set; }
            public string TableSelector { get; set; }
            public string HeaderRowSelector { get; set; }
            public string HeaderCellSelector { get; set; }
            public string BodyRowSelector { get; set; }
            public string BodyCellSelector { get; set; }
        }
    }
}