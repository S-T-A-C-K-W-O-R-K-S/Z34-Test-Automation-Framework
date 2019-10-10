using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class EmployeePage : BasePage
    {
        public EmployeePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement LnkLogin { get; set; }
    }
}
