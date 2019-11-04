using Framework.Base;
using Framework.Config;
using Framework.Helpers;
using TechTalk.SpecFlow;

namespace UnitTests.Tests
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            InitializeConfig();
            Settings.DatabaseEndpoint = Settings.DatabaseEndpoint.DBConnect(Settings.ConnectionString);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
        }
    }
}