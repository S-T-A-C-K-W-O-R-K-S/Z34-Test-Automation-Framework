using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace TestAutomation.Pages
{
    internal class CreateEmployeePage : BasePage
    {
        public CreateEmployeePage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
        }

        private IWebElement TextName => ParallelTestExecution.Driver.FindElement(By.Id("Name"), 2500);
        private IWebElement TextSalary => ParallelTestExecution.Driver.FindElement(By.Id("Salary"), 2500);
        private IWebElement TextWorkHours => ParallelTestExecution.Driver.FindElement(By.Id("DurationWorked"), 2500);
        private IWebElement TextGrade => ParallelTestExecution.Driver.FindElement(By.Id("Grade"), 2500);
        private IWebElement TextEmail => ParallelTestExecution.Driver.FindElement(By.Id("Email"), 2500);
        private IWebElement ButtonCreateEmployee => ParallelTestExecution.Driver.FindElement(By.XPath("//input[@value='Create']"), 2500);

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
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new EmployeeListPage(ParallelTestExecution);
        }
    }
}