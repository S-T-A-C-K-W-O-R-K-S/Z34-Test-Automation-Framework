using Bogus;
using FrameworkCore.Base;
using FrameworkCore.Config;
using Microsoft.Data.Sqlite;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TestRunner.Steps
{
    [Binding]
    public class DatabaseSteps : BaseStep
    {
        public DatabaseSteps(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private bool TableExists { get; set; }

        [Given(@"A ""(.*)"" TABLE ALREADY EXISTS IN THE DATABASE")]
        public void Given_A_TABLE_ALREADY_EXISTS_IN_THE_DATABASE(string usersTable)
        {
            SqliteCommand command = Settings.DatabaseConnection.CreateCommand();

            command.CommandText = $"SELECT NAME FROM SQLITE_MASTER WHERE TYPE='table' AND NAME='{usersTable}'";

            try { TableExists = command.ExecuteScalar().ToString() == usersTable; }
            catch { TableExists = false; }
        }

        [When(@"I DELETE ALL RECORDS IN THE ""(.*)"" TABLE")]
        public void When_I_DELETE_ALL_RECORDS_IN_THE_TABLE(string usersTable)
        {
            if (TableExists)
            {
                SqliteCommand command = Settings.DatabaseConnection.CreateCommand();

                command.CommandText = $"DELETE FROM {usersTable}";
                command.ExecuteNonQuery();
            }
        }

        [Then(@"THE ""(.*)"" TABLE CONTAINS NO RECORDS")]
        public void Then_THE_TABLE_CONTAINS_NO_RECORDS(string usersTable)
        {
            if (TableExists)
            {
                SqliteCommand command = Settings.DatabaseConnection.CreateCommand();

                command.CommandText = $"SELECT * FROM {usersTable}";

                Assert.IsFalse(command.ExecuteReader().HasRows);
            }
        }

        [Given]
        public void Given_I_AM_CONNECTED_TO_THE_DATABASE()
        {
            Assert.AreEqual(Settings.DatabaseConnection.State.ToString(), "Open");
        }

        [Given(@"I CREATE A TABLE CALLED ""(.*)"" WITH THE COLUMNS ""(.*)"", ""(.*)"" AND ""(.*)""")]
        public void Given_I_CREATE_A_TABLE_CALLED_USERS_WITH_THE_COLUMNS_FIRSTNAME_LASTNAME_AND_EMAIL(string usersTable, string firstName, string lastName, string email)
        {
            SqliteCommand command = Settings.DatabaseConnection.CreateCommand();

            command.CommandText = $"CREATE TABLE IF NOT EXISTS {usersTable} ({firstName} varchar(255), {lastName} varchar(255), {email} varchar(255))";
            command.ExecuteNonQuery();
        }

        [When(@"I GENERATE (.*) ENTRIES IN THE ""(.*)"" TABLE")]
        public void When_I_GENERATE_A_NUMBER_OF_ENTRIES(int entries, string usersTable)
        {
            using SqliteTransaction transaction = Settings.DatabaseConnection.BeginTransaction();
            SqliteCommand command = Settings.DatabaseConnection.CreateCommand();

            for (int i = 0; i < entries; i++)
            {
                string firstName = new Faker().Name.FirstName().Replace("'", "''");  /* Single Quotes Need To Be Escaped By Duplicating Them */
                string lastName = new Faker().Name.LastName().Replace("'", "''");
                string email = new Faker().Internet.Email().Replace("'", "''");

                command.CommandText = $"INSERT INTO {usersTable} VALUES ('{firstName}', '{lastName}', '{email}')";

                command.ExecuteNonQuery();
            }

            transaction.Commit();
        }

        [Then(@"I SHOULD HAVE (.*) ROWS IN THE ""(.*)"" TABLE")]
        public void Then_I_SHOULD_HAVE_THE_SAME_NUMBER_OF_ROWS_IN_THE_USERS_TABLE(int rows, string usersTable)
        {
            SqliteCommand command = Settings.DatabaseConnection.CreateCommand();
            command.CommandText = $"SELECT COUNT(*) FROM {usersTable}";

            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Assert.AreEqual(int.Parse(reader.GetString(0)), rows);
            }
        }
    }
}
