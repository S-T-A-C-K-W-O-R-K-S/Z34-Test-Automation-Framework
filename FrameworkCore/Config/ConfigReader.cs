namespace FrameworkCore.Config
{
    public static class ConfigReader
    {
        public static void SetFrameworkSettings(string config)
        {
            Settings.AUT = TestConfiguration.Settings.TestSettings[config].AUT;
            Settings.BrowserType = TestConfiguration.Settings.TestSettings[config].BrowserType;
            Settings.LogPath = TestConfiguration.Settings.TestSettings[config].LogPath;
            Settings.ConnectionString = TestConfiguration.Settings.TestSettings[config].ConnectionString;
            Settings.DebugMode = TestConfiguration.Settings.TestSettings[config].DebugMode;
            Settings.RemoteExecution = TestConfiguration.Settings.TestSettings[config].RemoteExecution;
            Settings.RemoteHost = TestConfiguration.Settings.TestSettings[config].RemoteHost;
        }
    }
}