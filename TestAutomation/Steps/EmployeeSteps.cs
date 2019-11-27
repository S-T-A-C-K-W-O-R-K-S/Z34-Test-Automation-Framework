using System;
using FrameworkCore.Base;
using FrameworkCore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomation.Pages;

namespace TestAutomation.Steps
{
    [Binding]
    public class EmployeeSteps : BaseStep
    {
        private readonly ParallelTestExecution _parallelTestExecution;

        private dynamic _employeeDetails;

        public EmployeeSteps(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
        }

        [When]
        public void When_I_FOLLOW_THE_EMPLOYEE_LIST_LINK()
        {
            _parallelTestExecution.CurrentPage = _parallelTestExecution.CurrentPage.As<HomePage>().ClickEmployeeList();
        }

        [When(@"I CLICK THE (.*) \[EMPLOYEE\] BUTTON")]
        public void When_I_CLICK_THE_BUTTON(string button)
        {
            switch (button)
            {
                case "CREATE NEW":
                    _parallelTestExecution.CurrentPage = _parallelTestExecution.CurrentPage.As<EmployeeListPage>().ClickCreateNew();
                    break;
                case "CREATE":
                    break;
                default:
                    #pragma warning disable CS4014
                    LogHelpers.WriteToLog($"[ERROR] :: Invalid Button Name: {button}");
                    #pragma warning restore CS4014

                    throw new ArgumentOutOfRangeException(nameof(button), button, $"Invalid Button Name: {button}");
            }
        }

        [When]
        public void When_I_ENTER_THE_DETAILS_OF_THE_EMPLOYEE(Table employeeDetailsTable)
        {
            _employeeDetails = employeeDetailsTable.CreateDynamicInstance();
            _parallelTestExecution.CurrentPage.As<CreateEmployeePage>().EnterEmployeeDetails(_employeeDetails.NAME.ToString(), _employeeDetails.SALARY.ToString(), _employeeDetails.HOURS.ToString(), _employeeDetails.GRADE.ToString(), _employeeDetails.EMAIL.ToString());
            _parallelTestExecution.CurrentPage = _parallelTestExecution.CurrentPage.As<CreateEmployeePage>().ClickCreateEmployeeButton();
        }

        [Then]
        public void Then_THE_NEWLY_CREATED_EMPLOYEE_SHOULD_HAVE_SUCCESSFULLY_SAVED()
        {
            Assert.IsTrue(_parallelTestExecution.CurrentPage.As<EmployeeListPage>().AssertEmployeePresence(_employeeDetails.NAME));
        }
    }
}