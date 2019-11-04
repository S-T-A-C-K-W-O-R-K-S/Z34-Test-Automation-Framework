using Framework.Base;
using Framework.Config;
using Framework.Helpers;
using TechTalk.SpecFlow;

namespace UnitTests.Tests
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            InitializeConfig();
            Settings.DatabaseEndpoint = Settings.DatabaseEndpoint.DBConnect(Settings.ConnectionString);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
        }
    }
}