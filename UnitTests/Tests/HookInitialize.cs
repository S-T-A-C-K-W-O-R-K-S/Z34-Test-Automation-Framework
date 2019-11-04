using Framework.Base;
using TechTalk.SpecFlow;

namespace UnitTests.Tests
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.Chrome)
        {
            InitializeConfig();
            NavigateToAUT();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            HookInitialize init = new HookInitialize();
        }
    }
}