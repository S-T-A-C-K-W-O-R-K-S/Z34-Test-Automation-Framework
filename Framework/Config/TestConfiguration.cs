using System.Configuration;

namespace Framework.Config
{
    class TestConfiguration : ConfigurationSection
    {
        private static readonly TestConfiguration TestConfig = (TestConfiguration) ConfigurationManager.GetSection("TestConfiguration");

        public static TestConfiguration Settings => TestConfig;

        [ConfigurationProperty("TestSettings")]
        public ConfigElementCollection TestSettings => (ConfigElementCollection) base[nameof(TestSettings)];
    }
}