using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace ApplicationMap.Pages
{
    public class CreateEmployeePage : BasePage
    {
        public CreateEmployeePage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
        }

        private IWebElement TextName => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("Name"));
        private IWebElement TextSalary => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("Salary"));
        private IWebElement TextWorkHours => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("DurationWorked"));
        private IWebElement TextGrade => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("Grade"));
        private IWebElement TextEmail => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("Email"));
        private IWebElement ButtonCreateEmployee => ParallelTestExecution.Driver.FindElementOrTimeOut(By.XPath("//input[@value='Create']"));

        public void EnterEmployeeDetails(string name, string salary, string hours, string grade, string email)
        {
            TextName.SendKeys(name);
            TextSalary.SendKeys(salary);
            TextWorkHours.SendKeys(hours);
            TextGrade.SendKeys(grade);
            TextEmail.SendKeys(email);
        }

        public EmployeeListPage ClickCreateEmployeeButton()
        {
            ButtonCreateEmployee.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new EmployeeListPage(ParallelTestExecution);
        }
    }
}