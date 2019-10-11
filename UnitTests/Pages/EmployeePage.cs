using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement TxtSearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        public IWebElement LnkCreateNew { get; set; }

        public CreateEmployeePage ClickCreateNew()
        {
            LnkCreateNew.Click();
            return new CreateEmployeePage();
        }
    }
}
