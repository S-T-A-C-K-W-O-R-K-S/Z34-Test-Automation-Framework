using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace Framework.Base
{
    public class Base
    {
        [SuppressMessage("Code Quality", "IDE0052: Remove Unread Private Members", Justification = "Offers No Advantage In This Context")]
        private IWebDriver _driver { get; set; }

        public BasePage CurrentPage
        {
            get
            {
                return (BasePage)ScenarioContext.Current["currentPage"];
            }
            set
            {
                ScenarioContext.Current["currentPage"] = value;
            }
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                _driver = DriverContext.Driver
            };

            PageFactory.InitElements(DriverContext.Driver, pageInstance);

            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}