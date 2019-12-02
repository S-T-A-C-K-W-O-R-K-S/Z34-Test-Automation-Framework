using System.Configuration;
using FrameworkCore.Base;

namespace FrameworkCore.Config
{
    public class ConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string) base["name"];

        [ConfigurationProperty("aut", IsRequired = true)]
        public string AUT => (string) base["aut"];

        [ConfigurationProperty("browser-type", IsRequired = true)]
        public BrowserType BrowserType => (BrowserType) base["browser-type"];

        [ConfigurationProperty("log-path", IsRequired = true)]
        public string LogPath => (string) base["log-path"];

        [ConfigurationProperty("connection-string", IsRequired = true)]
        public string ConnectionString => (string) base["connection-string"];

        [ConfigurationProperty("debug-mode", IsRequired = true)]
        public bool DebugMode => (bool) base["debug-mode"];

        [ConfigurationProperty("remote-execution", IsRequired = true)]
        public bool RemoteExecution => (bool) base["remote-execution"];

        [ConfigurationProperty("remote-host", IsRequired = true)]
        public string RemoteHost => (string)base["remote-host"];
    }
}