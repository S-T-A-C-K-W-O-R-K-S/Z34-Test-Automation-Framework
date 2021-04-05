using PlaywrightSharp;

namespace ApplicationMap.Elements.Common
{
    public sealed class NavigationBar
    {
        private readonly IPage Page;
        public WorkZoneTabs WorkZoneTabsGroup = new();

        public NavigationBar(IPage Page)
        {
            this.Page = Page;
        }

        public string HomeTab => "button[title='Home']";
        public string UploadTab => "button[title='Upload']";
        public string WorkZoneTab => "button[title='Work Zone']";
        public string DictionariesTab => "button[title='Dictionaries']";
        public string SchedulingTab => "button[title='Scheduling']";
        public string InteractiveModeTab => "button[title='Interactive Mode']";
        public string NotebooksTab => "button:text('Notebooks')";

        public UploadTabs UploadTabsGroup => new();

        public sealed class UploadTabs
        {
            public string UploadDataTab => "button[title='Data']";
            public string UploadMetadataTab => "button[title='Metadata']";
            public string DiscoveryTab => "button[title='Discovery']";
        }

        public sealed class WorkZoneTabs
        {
            public string WorkZoneInBasketTab => "button[title='In Basket']";
            public string WorkZoneStagingTab => "button[title='Staging']";
            public string WorkZoneDiscoveryBasketTab => "button[title='Discovery Basket']";
            public string WorkZoneWorkflowGeneratorTab => "button[title='Workflow Generator']";
        }
    }
}