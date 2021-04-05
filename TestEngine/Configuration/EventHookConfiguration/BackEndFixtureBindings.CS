using System;
using TechTalk.SpecFlow;
using FrameworkCore.Configuration;
using AventStack.ExtentReports.Gherkin.Model;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace TestEngine.Configuration.EventHookConfiguration
{
    public partial class SpecFlowEventBindings
    {
        [BeforeFeature("Back-End")]
        public static void BeforeBackEndFeature()
            => Z34.DatabaseConnection = new SqliteConnection(Z34.ConnectionStringBuilder.ConnectionString);

        [AfterStep("Back-End")]
        public void AfterBackEndStep()
        {
            string stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError is not null)
            {
                _ = (stepType) switch
                {
                    "Given" => _currentScenario
                    .CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                    .Fail(_scenarioContext.TestError.Message),

                    "When" => _currentScenario
                    .CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text)
                    .Fail(_scenarioContext.TestError.Message),

                    "Then" => _currentScenario
                    .CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text)
                    .Fail(_scenarioContext.TestError.Message),

                    "And" => _currentScenario
                    .CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text)
                    .Fail(_scenarioContext.TestError.Message),

                    _ => throw new ArgumentOutOfRangeException(nameof(stepType), stepType, $"Invalid Step Type: {stepType}")
                };
            }
        }

        [AfterScenario("Back-End")]
        public async Task AfterBackEndScenario()
        {
            if (Z34.DatabaseConnection is not null)
                await Z34.DatabaseConnection.CloseAsync();
        }
    }
}