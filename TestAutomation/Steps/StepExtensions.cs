using Framework.Base;
using Framework.Config;
using Framework.Helpers;
using TechTalk.SpecFlow;

namespace UnitTests.Steps
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

        [Given(@"I DELETE EMPLOYEE ""(.*)"" PRIOR TO RUNNING TEST")]
        public void Given_I_DELETE_EMPLOYEE_PRIOR_TO_RUNNING_TEST(string employeeName)
        {
            string query = "DELETE FROM Employees WHERE NAME = '" + employeeName + "'";
            Settings.DatabaseConnection.ExecuteQuery(query);
        }
    }
}