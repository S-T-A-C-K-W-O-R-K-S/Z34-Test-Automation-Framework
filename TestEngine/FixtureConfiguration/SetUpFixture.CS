using Atata;
using FrameworkCore.EventLogConfiguration;
using NUnit.Framework;

namespace TestEngine.FixtureConfiguration
{
    [SetUpFixture]
    public class SetUpFixture
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