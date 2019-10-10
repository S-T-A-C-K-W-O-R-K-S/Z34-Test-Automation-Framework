using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Framework.Base
{
    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
