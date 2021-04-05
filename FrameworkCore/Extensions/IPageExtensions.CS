using System;
using System.Data;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using PlaywrightSharp;
using static FrameworkCore.Helpers.HTMLTableHelpers;

namespace FrameworkCore.Extensions
{
    public static class IPageExtensions
    {
        public static async Task<MediaEntityModelProvider> CaptureScreenshotAndReturnModel(this IPage page, string name,
            bool fullPage = true)
        {
            return MediaEntityBuilder
                .CreateScreenCaptureFromBase64String(Convert.ToBase64String(await page.ScreenshotAsync(fullPage)), name)
                .Build();
        }

        public static async Task<DataTable> ProcessHTMLTable(this IPage PlaywrightPage)
        {
            var processorOptions = new PlaywrightHTMLTableProcessorOptions
                (PlaywrightPage, "table", "thead > tr", "th", "tbody > tr", "th, td");

            var processor = new PlaywrightHTMLTableProcessor(processorOptions);

            return await processor.ProcessHTMLTable();
        }

        public static async Task<DataTable> ProcessAngularGrid(this IPage PlaywrightPage)
        {
            var processorOptions = new PlaywrightHTMLTableProcessorOptions
            (PlaywrightPage,
                "ag-grid-angular",
                "div.ag-header-container > div.ag-header-row",
                "div.ag-header-cell",
                "div.ag-center-cols-container > div.ag-row",
                "div.ag-cell");

            var processor = new PlaywrightHTMLTableProcessor(processorOptions);

            return await processor.ProcessHTMLTable();
        }
    }
}