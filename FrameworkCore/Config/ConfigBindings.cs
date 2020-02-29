using FrameworkCore.Base;
using Newtonsoft.Json;

namespace FrameworkCore.Config
{
    [JsonObject("Configuration")]
    public class ConfigBindings
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AUT")]
        public string AUT { get; set; }

        [JsonProperty("BrowserType")]
        public BrowserType BrowserType { get; set; }

        [JsonProperty("LogPath")]
        public string LogPath { get; set; }

        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("DebugMode")]
        public bool DebugMode { get; set; }

        [JsonProperty("RemoteExecution")]
        public bool RemoteExecution { get; set; }

        [JsonProperty("RemoteHost")]
        public string RemoteHost { get; set; }

        [JsonProperty("RemoteBrowserVersion")]
        public string RemoteBrowserVersion { get; set; }
    }
}