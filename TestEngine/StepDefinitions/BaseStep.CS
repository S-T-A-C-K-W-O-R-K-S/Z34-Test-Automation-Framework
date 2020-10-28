using Atata;
using TechTalk.SpecFlow;

namespace TestEngine.StepDefinitions
{
    [Binding]
    public abstract class BaseStep : Steps
    {
        protected TPageObject On<TPageObject>() where TPageObject : PageObject<TPageObject>
        {
            return AtataContext.Current.PageObject as TPageObject ?? Go.To<TPageObject>(navigate: false);
        }
    }
}