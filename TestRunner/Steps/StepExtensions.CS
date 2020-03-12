using System.Text;
using ApplicationMap.Pages;
using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;

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

        [Given(@"I DELETE EMPLOYEE ""(.*)"" FROM TABLE ""(.*)"" IN DATABASE ""(.*)"" PRIOR TO RUNNING TEST")]
        public static void Given_I_DELETE_EMPLOYEE_PRIOR_TO_RUNNING_TEST(string employeeName, string tableName, string databaseName)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine($"USE {databaseName}")
                .AppendLine($"DELETE FROM {tableName}")
                .AppendLine($"WHERE NAME = '{employeeName}'");

            Settings.DatabaseConnection.ExecuteQuery(query.ToString());
        }

        public void NavigateToAUT()
        {
            _parallelTestExecution.Driver.Navigate().GoToUrl(Settings.AUT);
            LogHelpers.WriteToLog($"[EVENT] :: Navigate To Page :: {Settings.AUT}");

            _parallelTestExecution.Driver.WaitForPageLoaded();
            LogHelpers.WriteToLog($"[EVENT] :: DOM On Page Loaded :: {Settings.AUT}");
        }
    }
}