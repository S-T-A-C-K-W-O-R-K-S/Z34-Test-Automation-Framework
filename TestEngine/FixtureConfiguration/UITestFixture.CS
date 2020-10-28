using Atata;
using TechTalk.SpecFlow;

namespace TestEngine.FixtureConfiguration
{
    [Binding]
    public sealed class UITestFixture : BaseFixture
    {
        [BeforeScenario]
        public static void SetUpScenario()
        {
            AtataContext.Configure()
                .UseFirefox()
                .WithFixOfCommandExecutionDelay()
                .WithLocalDriverPath()
                .Build();
        }

        [AfterScenario]
        public static void TearDownScenario()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}