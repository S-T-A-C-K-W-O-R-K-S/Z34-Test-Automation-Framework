using System;
using TechTalk.SpecFlow;

namespace Framework.Base
{
    public class Base
    {
        // TODO: Implement Scenario Context Via Context Injection
        public BasePage CurrentPage
        {
            get => (BasePage) ScenarioContext.Current["currentPage"];
            set => ScenarioContext.Current["currentPage"] = value;
        }

        protected static TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage) Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }
    }
}