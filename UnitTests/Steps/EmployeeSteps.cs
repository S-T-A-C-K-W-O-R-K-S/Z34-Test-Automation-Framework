using System;
using Framework.Base;
using Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UnitTests.Pages;

namespace UnitTests.Steps
{
    [Binding]
    public sealed class EmployeeSteps : BaseStep
    {
        // TODO: Implement Scenario Context Via Context Injection
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        //
        // private readonly ScenarioContext context;
        //
        // public Employee(ScenarioContext injectedContext)
        // {
        //     context = injectedContext;
        // }

        [When]
        public void When_I_FOLLOW_THE_EMPLOYEE_LIST_LINK()
        {
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
        }

        [When(@"I CLICK THE (.*) \[EMPLOYEE\] BUTTON")]
        public void When_I_CLICK_THE_BUTTON(string button)
        {
            switch (button)
            {
                case "CREATE NEW":
                    CurrentPage = CurrentPage.As<EmployeeListPage>().ClickCreateNew();
                    break;
                case "CREATE":
                    break;
                default:
                    LogHelpers.WriteToLog($"[ERROR] :: Invalid Button Name: {button}");
                    throw new ArgumentOutOfRangeException(nameof(button), button, $"Invalid Button Name: {button}");
            }
        }

        [When]
        public void When_I_ENTER_THE_DETAILS_OF_THE_EMPLOYEE(Table employeeDetailsTable)
        {
            dynamic employeeDetails = employeeDetailsTable.CreateDynamicInstance();
            CurrentPage.As<CreateEmployeePage>().EnterEmployeeDetails(employeeDetails.NAME, employeeDetails.SALARY, employeeDetails.HOURS, employeeDetails.GRADE, employeeDetails.EMAIL);
            CurrentPage = CurrentPage.As<CreateEmployeePage>().ClickCreateEmployeeButton();
        }

        [Then]
        public void Then_THE_NEWLY_CREATED_EMPLOYEE_SHOULD_HAVE_SUCCESSFULLY_SAVED(Table employeeDetailsTable)
        {
            dynamic employeeDetails = employeeDetailsTable.CreateDynamicInstance();
            Assert.IsTrue(CurrentPage.As<EmployeeListPage>().AssertEmployeePresence(employeeDetails.NAME));
        }
    }
}