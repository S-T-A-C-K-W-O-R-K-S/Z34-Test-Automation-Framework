using Atata;
using FrameworkCore.EventLogConfiguration;
using NUnit.Framework;
using TechTalk.SpecFlow;

[assembly: LevelOfParallelism(5)]
[assembly: Parallelizable(ParallelScope.Children)]

namespace TestEngine.FixtureConfiguration
{
    [Binding]
    public abstract class BaseFixture
    {
        [BeforeTestRun]
        public static void SetUpTestRun()
        {
            AtataContext.GlobalConfiguration
                .UseBaseUrl("https://weboas.is/")
                .UseCulture("en-GB")
                .UseAllNUnitFeatures()
                .AddLogConsumer(new ExtentLogConsumer())
                .AddScreenshotConsumer(new ExtentScreenshotConsumer());
        }

        [AfterTestRun]
        public static void TearDownTestRun()
        {
            ExtentContext.Reports.Flush();
        }
    }
}