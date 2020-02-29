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

            IConfigurationRoot configRoot = builder.Build();

            Settings.AUT = configRoot.GetSection("Configuration").Get<ConfigBindings>().AUT;
            Settings.BrowserType = configRoot.GetSection("Configuration").Get<ConfigBindings>().BrowserType;
            Settings.LogPath = configRoot.GetSection("Configuration").Get<ConfigBindings>().LogPath;
            Settings.ConnectionString = configRoot.GetSection("Configuration").Get<ConfigBindings>().ConnectionString;
            Settings.DebugMode = configRoot.GetSection("Configuration").Get<ConfigBindings>().DebugMode;
            Settings.RemoteExecution = configRoot.GetSection("Configuration").Get<ConfigBindings>().RemoteExecution;
            Settings.RemoteHost = configRoot.GetSection("Configuration").Get<ConfigBindings>().RemoteHost;
            Settings.RemoteBrowserVersion = configRoot.GetSection("Configuration").Get<ConfigBindings>().RemoteBrowserVersion;
        }
    }
}