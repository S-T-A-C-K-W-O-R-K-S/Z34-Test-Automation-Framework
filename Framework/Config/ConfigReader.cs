using System;
using Framework.Base;

namespace Framework.Config
{
    public static class ConfigReader
    {
        public static void SetFrameworkSettings(string config)
        {
            Settings.AUT = TestConfiguration.Settings.TestSettings[config].AUT;
            Settings.BrowserType = (BrowserType) Enum.Parse(typeof(BrowserType), TestConfiguration.Settings.TestSettings[config].Browser);
            Settings.LogPath = TestConfiguration.Settings.TestSettings[config].LogPath;
            Settings.ConnectionString = TestConfiguration.Settings.TestSettings[config].ConnectionString;
            Settings.DebugMode = Convert.ToBoolean(TestConfiguration.Settings.TestSettings[config].DebugMode);
        }
    }
}