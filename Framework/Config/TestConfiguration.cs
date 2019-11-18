using System.Configuration;

namespace Framework.Config
{
    internal class TestConfiguration : ConfigurationSection
    {
        public static TestConfiguration Settings { get; } = (TestConfiguration)ConfigurationManager.GetSection("TestConfiguration");

        [ConfigurationProperty("TestSettings")]
        public ConfigElementCollection TestSettings => (ConfigElementCollection) base[nameof(TestSettings)];
    }
}