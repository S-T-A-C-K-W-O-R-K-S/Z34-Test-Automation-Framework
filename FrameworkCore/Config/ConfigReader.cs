using System.IO;
using Microsoft.Extensions.Configuration;

namespace FrameworkCore.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings(string config)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Config")
                .AddJsonFile("APP.CONFIG.JSON");

            var configRoot = builder.Build();

            var selectedConfig = configRoot.GetSection("Configuration").Get<ConfigBindings>();

            Settings.AUT = selectedConfig.AUT;
            Settings.BrowserType = selectedConfig.BrowserType;
            Settings.LogPath = selectedConfig.LogPath;
            Settings.ConnectionString = selectedConfig.ConnectionString;
            Settings.DebugMode = selectedConfig.DebugMode;
            Settings.RemoteExecution = selectedConfig.RemoteExecution;
            Settings.RemoteHost = selectedConfig.RemoteHost;
            Settings.RemoteBrowserVersion = selectedConfig.RemoteBrowserVersion;
        }
    }
}