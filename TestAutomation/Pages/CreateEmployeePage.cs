using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;

namespace UnitTests.Pages
{
    internal class CreateEmployeePage : BasePage
    {
        private static IWebElement TextName => DriverContext.Driver.FindElement(By.Id("Name"), 2500);
        private static IWebElement TextSalary => DriverContext.Driver.FindElement(By.Id("Salary"), 2500);
        private static IWebElement TextWorkHours => DriverContext.Driver.FindElement(By.Id("DurationWorked"), 2500);
        private static IWebElement TextGrade => DriverContext.Driver.FindElement(By.Id("Grade"), 2500);
        private static IWebElement TextEmail => DriverContext.Driver.FindElement(By.Id("Email"), 2500);
        private static IWebElement ButtonCreateEmployee => DriverContext.Driver.FindElement(By.XPath("//input[@value='Create']"), 2500);

        internal void EnterEmployeeDetails(string name, string salary, string hours, string grade, string email)
        {
            TextName.SendKeys(name);
            TextSalary.SendKeys(salary);
            TextWorkHours.SendKeys(hours);
            TextGrade.SendKeys(grade);
            TextEmail.SendKeys(email);
        }

        internal EmployeeListPage ClickCreateEmployeeButton()
        {
            ButtonCreateEmployee.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return new EmployeeListPage();
        }
    }
}