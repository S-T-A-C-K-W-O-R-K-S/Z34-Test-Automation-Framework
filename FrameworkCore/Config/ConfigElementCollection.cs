using System.Configuration;

namespace FrameworkCore.Config
{
    [ConfigurationCollection(typeof(ConfigElement), AddItemName = "TestSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ConfigElementCollection : ConfigurationElementCollection
    {
        public new ConfigElement this[string type] => (ConfigElement) BaseGet(type);
        protected override ConfigurationElement CreateNewElement() => new ConfigElement();
        protected override object GetElementKey(ConfigurationElement element) => ((ConfigElement) element).Name;
    }
}