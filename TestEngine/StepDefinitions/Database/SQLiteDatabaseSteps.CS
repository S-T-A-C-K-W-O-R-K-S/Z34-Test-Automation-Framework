using FrameworkCore.Configuration;
using Microsoft.Data.Sqlite;
using NUnit.Framework;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestEngine.StepDefinitions.Common;

namespace TestEngine.StepDefinitions.Database
{
	[Binding]
	class SQLiteDatabaseSteps : BaseStep
	{
		private readonly SqliteCommand Script;

        public SQLiteDatabaseSteps() : base()
			=> Script = Z34.DatabaseConnection.CreateCommand();

        [Given]
        public static void GIVEN_THE_SQLITE_DATABASE_DOES_NOT_EXIST()
        {
            if (File.Exists(Z34.ConnectionStringBuilder.DataSource))
                File.Delete(Z34.ConnectionStringBuilder.DataSource);

            Assert.IsFalse(File.Exists(Z34.ConnectionStringBuilder.DataSource), "Database Exists");
        }

        [Given]
        public async Task GIVEN_I_BOOTSTRAP_AND_CONNECT_TO_THE_DATABASE()
            => await Z34.DatabaseConnection.OpenAsync();

        [Given]
        public static void GIVEN_I_CONFIRM_THAT_THE_CONNECTION_IS_ALIVE()
            => Assert.AreEqual(ConnectionState.Open, Z34.DatabaseConnection.State, "Connection State");

        [When(@"I CREATE A ""(.*)"" TABLE")]
        public async Task WHEN_I_CREATE_A_STRING_TABLE(string table)
        {
            Script.CommandText = $"CREATE TABLE IF NOT EXISTS {table} (TIMESTAMP VARCHAR(255), LANGUAGE VARCHAR(255), ENTRY VARCHAR(255))";
            await Script.ExecuteNonQueryAsync();
        }

        [When(@"I INSERT ""(.*)"" AND ""(.*)"" INTO THE ""(.*)"" TABLE")]
        public async Task WHEN_I_INSERT_STRING_AND_STRING_INTO_THE_STRING_TABLE(string language, string entry, string table)
        {
            Script.CommandText = $"INSERT INTO {table} VALUES ('{DateTime.UtcNow:dd.MM.yyyy @ HH:mm:ss.fff}', '{language}', '{entry}')";
            await Script.ExecuteNonQueryAsync();
        }

        [Then(@"I CONFIRM THAT A ROW HAS BEEN CREATED IN THE ""(.*)"" TABLE")]
        public async Task THEN_I_CONFIRM_THAT_A_ROW_HAS_BEEN_CREATED_IN_THE_STRING_TABLE(string table)
        {
            Script.CommandText = $"SELECT COUNT(*) FROM {table}";
            Assert.AreEqual(1, await Script.ExecuteScalarAsync(), "Row Count");
        }
    }
}