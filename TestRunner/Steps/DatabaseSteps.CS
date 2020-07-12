using FrameworkCore.Base;
using FrameworkCore.Config;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TestRunner.Steps
{
    [Binding]
    public class DatabaseSteps : BaseStep
    {
        public DatabaseSteps(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        [Given]
        [System.Obsolete]
        public void Given_I_AM_CONNECTED_TO_THE_DATABASE()
        {
            Assert.AreEqual(Settings.DatabaseConnection.State.ToString(), "Open");
        }

        [Given(@"I CREATE A TABLE CALLED ""(.*)"" WITH THE COLUMNS ""(.*)"", ""(.*)"" AND ""(.*)""")]
        public void Given_I_CREATE_A_TABLE_CALLED_USERS_WITH_THE_COLUMNS_FIRSTNAME_LASTNAME_AND_EMAIL(string usersTable, string firstName, string lastName, string email)
        {
            Assert.Pass("NOT IMPLEMENTED");
        }

        [When(@"I GENERATE (.*) ENTRIES")]
        public void When_I_GENERATE_A_NUMBER_OF_ENTRIES(int entries)
        {
            Assert.Pass("NOT IMPLEMENTED");
        }

        [Then(@"I SHOULD HAVE (.*) ROWN IN THE ""(.*)"" TABLE")]
        [System.Obsolete]
        public void Then_I_SHOULD_HAVE_THE_SAME_NUMBER_OF_ROWS_IN_THE_USERS_TABLE(int rows, string usersTable)
        {
            Assert.Pass("NOT IMPLEMENTED");
        }
    }
}
