using System.Text;
using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;

namespace TestRunner.Steps
{
    [Binding]
    public class DatabaseSteps : BaseStep
    {
        private readonly FeatureContext _featureContext;
        private readonly ParallelTestExecution _parallelTestExecution;

        public DatabaseSteps(ParallelTestExecution parallelTestExecution, FeatureContext featureContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
        }

        [Given(@"I DELETE USER ""(.*)"" FROM TABLE ""(.*)"" IN DATABASE ""(.*)"" PRIOR TO RUNNING TEST")]
        public static void Given_I_DELETE_USER_PRIOR_TO_RUNNING_TEST(string userName, string tableName, string databaseName)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine($"USE {databaseName}")
                .AppendLine($"DELETE FROM {tableName}")
                .AppendLine($"WHERE NAME = '{userName}'");

            Settings.DatabaseConnection.ExecuteQuery(query.ToString());
        }
    }
}
