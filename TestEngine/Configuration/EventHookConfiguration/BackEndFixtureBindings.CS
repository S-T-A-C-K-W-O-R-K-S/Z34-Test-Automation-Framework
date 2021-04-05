using System;
using System.Threading.Tasks;
using AventStack.ExtentReports.Gherkin.Model;
using FrameworkCore.Configuration;
using Microsoft.Data.Sqlite;
using TechTalk.SpecFlow;

namespace TestEngine.Configuration.EventHookConfiguration
{
    public partial class SpecFlowEventBindings
    {
        [BeforeFeature("Back-End")]
        public static void BeforeBackEndFeature()
        {
            Z34.DatabaseConnection = new SqliteConnection(Z34.ConnectionStringBuilder.ConnectionString);
        }

        [AfterStep("Back-End")]
        public void AfterBackEndStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError is not null)
                _ = stepType switch
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

                    _ => throw new ArgumentOutOfRangeException(nameof(stepType), stepType,
                        $"Invalid Step Type: {stepType}")
                };
        }

        [AfterScenario("Back-End")]
        public async Task AfterBackEndScenario()
        {
            if (Z34.DatabaseConnection is not null)
                await Z34.DatabaseConnection.CloseAsync();
        }
    }
}