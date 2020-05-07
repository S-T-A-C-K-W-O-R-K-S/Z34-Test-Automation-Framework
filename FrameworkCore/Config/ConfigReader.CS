using System.IO;
using Microsoft.Extensions.Configuration;

namespace FrameworkCore.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings(string config)
        {
            ConfigBindings configBindings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Config")
                .AddJsonFile("APP.CONFIG.JSON")
                .Build()
                .GetSection(config)
                .Get<ConfigBindings>();

            Settings.AUT = configBindings.AUT;
            Settings.BrowserType = configBindings.BrowserType;
            Settings.LogPath = configBindings.LogPath;
            Settings.ConnectionString = configBindings.ConnectionString;
            Settings.DebugMode = configBindings.DebugMode;
            Settings.RemoteExecution = configBindings.RemoteExecution;
            Settings.RemoteHost = configBindings.RemoteHost;
            Settings.RemoteBrowserVersion = configBindings.RemoteBrowserVersion;
        }
    }
}
