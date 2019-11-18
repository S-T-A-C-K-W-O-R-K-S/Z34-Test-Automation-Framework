using System.Configuration;

namespace Framework.Config
{
    public class ConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string) base["name"];

        [ConfigurationProperty("aut", IsRequired = true)]
        public string AUT => (string) base["aut"];

        [ConfigurationProperty("browser", IsRequired = true)]
        public string Browser => (string) base["browser"];

        [ConfigurationProperty("log-path", IsRequired = true)]
        public string LogPath => (string) base["log-path"];

        [ConfigurationProperty("connection-string", IsRequired = true)]
        public string ConnectionString => (string) base["connection-string"];

        [ConfigurationProperty("debug-mode", IsRequired = true)]
        public bool DebugMode => (bool) base["debug-mode"];
    }
}