using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;
using ApplicationMap.Pages;

namespace TestRunner.Steps
{
    [Binding]
    public class StepExtensions : BaseStep
    {
        private readonly ParallelTestExecution _parallelTestExecution;

        public StepExtensions(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
        }

        [Given]
        public void Given_I_HAVE_NAVIGATED_TO_THE_APPLICATION()
        {
            NavigateToAUT();
            _parallelTestExecution.CurrentPage = new HomePage(_parallelTestExecution);
        }

        [Given(@"I DELETE EMPLOYEE ""(.*)"" PRIOR TO RUNNING TEST")]
        public static void Given_I_DELETE_EMPLOYEE_PRIOR_TO_RUNNING_TEST(string employeeName)
        {
            string query = "DELETE FROM Employees WHERE NAME = '" + employeeName + "'";
            Settings.DatabaseConnection.ExecuteQuery(query);
        }

        public void NavigateToAUT()
        {
            _parallelTestExecution.Driver.Navigate().GoToUrl(Settings.AUT);

            #pragma warning disable CS4014
            LogHelpers.WriteToLog($"[EVENT] :: Navigate To Page :: {Settings.AUT}");
            #pragma warning restore CS4014

            _parallelTestExecution.Driver.WaitForPageLoaded();

            #pragma warning disable CS4014
            LogHelpers.WriteToLog($"[EVENT] :: DOM On Page Loaded :: {Settings.AUT}");
            #pragma warning restore CS4014
        }
    }
}