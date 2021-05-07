using Newtonsoft.Json;
using PlaywrightSharp;

namespace FrameworkCore.Configuration
{
    [JsonObject]
    public class ConfigurationBindings
    {
        [JsonProperty("Host")]
        public string Host { get; set; }

        [JsonProperty("TestResultsDir")]
        public string TestResultsDir { get; set; }

        [JsonProperty("TestRunBrowser")]
        public string TestRunBrowser { get; set; }

        [JsonProperty("TestRunLaunchOptions")]
        public LaunchOptions TestRunLaunchOptions { get; set; }

        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }
    }
}