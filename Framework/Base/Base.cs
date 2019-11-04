using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Framework.Base
{
    public class Base
    {
        [SuppressMessage("Code Quality", "IDE0052: Remove Unread Private Members", Justification = "Offers No Advantage In This Context")]
        private IWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }

        public TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage
            {
                Driver = DriverContext.Driver
            };

            PageFactory.InitElements(DriverContext.Driver, pageInstance);

            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }
    }
}