using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Framework.Base
{
    public abstract class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}
