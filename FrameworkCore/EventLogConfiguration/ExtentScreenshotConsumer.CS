using System.IO;
using Atata;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace FrameworkCore.EventLogConfiguration
{
    public class ExtentScreenshotConsumer : IScreenshotConsumer
    {
        public void Take(ScreenshotInfo screenshotInfo)
        {
            var title =
                $"{screenshotInfo.Number:D2} - {screenshotInfo.PageObjectFullName}{screenshotInfo.Title?.Prepend(" - ")}";

            var relativeFilePath =
                Path.Combine(AtataContext.Current.TestNameSanitized, $"{title.SanitizeForFileName()}.png");
            var absoluteFilePath = Path.Combine(ExtentContext.WorkingFolder, relativeFilePath);

            var targetDirectory = Path.GetDirectoryName(absoluteFilePath);

            if (!Directory.Exists(targetDirectory))
                Directory.CreateDirectory(targetDirectory);

            screenshotInfo.Screenshot.SaveAsFile(absoluteFilePath, ScreenshotImageFormat.Png);

            ExtentContext.CurrentTest.Log(
                Status.Info,
                MediaEntityBuilder.CreateScreenCaptureFromPath(relativeFilePath, title).Build());
        }
    }
}