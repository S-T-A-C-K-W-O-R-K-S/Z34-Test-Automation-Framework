using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace FrameworkCore.Base
{
    public class ParallelTestExecution
    {
        public IWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string name)
        {
            string screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }
    }
}
