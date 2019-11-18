using System.Configuration;

namespace Framework.Config
{
    [ConfigurationCollection(typeof(ConfigElements), AddItemName = "TestSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    class ConfigElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new ConfigElements();

        protected override object GetElementKey(ConfigurationElement element) => (element as ConfigElements).Name;

        public ConfigElements this[string type] => (ConfigElements) base.BaseGet(type);
    }
}