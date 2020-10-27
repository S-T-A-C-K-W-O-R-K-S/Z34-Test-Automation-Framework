using Atata;
using FrameworkCore.EventLogConfiguration;
using NUnit.Framework;

[assembly: LevelOfParallelism(5)]
[assembly: Parallelizable(ParallelScope.Children)]

namespace TestEngine.FixtureConfiguration
{
    [SetUpFixture]
    public class BaseFixture
    {
        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            AtataContext.GlobalConfiguration
                .AddLogConsumer(new ExtentLogConsumer())
                .AddScreenshotConsumer(new ExtentScreenshotConsumer());
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentContext.Reports.Flush();
        }
    }
}