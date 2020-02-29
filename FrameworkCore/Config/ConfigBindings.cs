using FrameworkCore.Base;
using Newtonsoft.Json;

namespace FrameworkCore.Config
{
    [JsonObject("Configuration")]
    public class ConfigBindings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }

        [JsonProperty("browser-type")]
        public BrowserType BrowserType { get; set; }

        [JsonProperty("log-path")]
        public string LogPath { get; set; }

        [JsonProperty("connection-string")]
        public string ConnectionString { get; set; }

        [JsonProperty("debug-mode")]
        public bool DebugMode { get; set; }

        [JsonProperty("remote-execution")]
        public bool RemoteExecution { get; set; }

        [JsonProperty("remote-host")]
        public string RemoteHost { get; set; }

        [JsonProperty("remote-browser-version")]
        public string RemoteBrowserVersion { get; set; }
    }
}