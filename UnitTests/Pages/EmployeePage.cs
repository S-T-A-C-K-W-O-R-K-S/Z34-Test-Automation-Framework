using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        IWebElement TxtSearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        IWebElement LnkCreateNew { get; set; }

        public CreateEmployeePage ClickCreateNew()
        {
            LnkCreateNew.Click();
            return new CreateEmployeePage();
        }
    }
}
