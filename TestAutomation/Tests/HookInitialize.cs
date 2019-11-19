using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;

namespace TestAutomation.Tests
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            InitializeConfig();
            Settings.DatabaseConnection = Settings.DatabaseConnection.DBConnect(Settings.ConnectionString);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
        }
    }
}