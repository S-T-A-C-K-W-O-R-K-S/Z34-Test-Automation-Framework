using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;

namespace TestAutomation.Steps
{
    [Binding]
    public sealed class StepExtensions : BaseStep
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

        public void NavigateToAUT()
        {
            DriverContext.Browser.GoToURL(Settings.AUT);
            LogHelpers.WriteToLog($"Navigating To Page: {Settings.AUT}");
            DriverContext.Driver.WaitForPageLoaded();
            LogHelpers.WriteToLog($"DOM On Page Fully Loaded: {Settings.AUT}");
        }

        [Given(@"I DELETE EMPLOYEE ""(.*)"" PRIOR TO RUNNING TEST")]
        public void Given_I_DELETE_EMPLOYEE_PRIOR_TO_RUNNING_TEST(string employeeName)
        {
            string query = "DELETE FROM Employees WHERE NAME = '" + employeeName + "'";
            Settings.DatabaseConnection.ExecuteQuery(query);
        }
    }
}