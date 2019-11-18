using System.Configuration;

namespace Framework.Config
{
    [ConfigurationCollection(typeof(ConfigElement), AddItemName = "TestSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ConfigElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => new ConfigElement();

        protected override object GetElementKey(ConfigurationElement element) => ((ConfigElement) element).Name;

        public new ConfigElement this[string type] => (ConfigElement) base.BaseGet(type);
    }
}