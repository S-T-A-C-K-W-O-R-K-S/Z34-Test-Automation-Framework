using Framework.Base;

namespace UnitTests.Tests
{
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.Chrome)
        {
            InitializeConfig();
            NavigateToAUT();
        }
    }
}