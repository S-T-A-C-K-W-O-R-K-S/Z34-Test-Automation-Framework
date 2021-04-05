using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FrameworkCore.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Reports = AventStack.ExtentReports.ExtentReports;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(5)]

namespace TestEngine.Configuration.EventHookConfiguration
{
    [Binding]
    public partial class SpecFlowEventBindings
    {
        private static ILoggerFactory _playwrightLogger;

        private static Reports _extent;

        private static List<ExtentTest> Features;

        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenario;

        public SpecFlowEventBindings(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Features = new List<ExtentTest>();

            _playwrightLogger = LoggerFactory.Create(
                builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Debug);
                    builder.AddDebug();
                    builder.AddFilter((filter, _) => filter == "PlaywrightSharp.Playwright");
                });

            ConfigurationReader.SetFrameworkSettings(Z34.TestRunProfile);

            var reporter = new ExtentHtmlReporter(Z34.TestResultsDir + Path.DirectorySeparatorChar);
            reporter.Config.EnableTimeline = true;
            reporter.Config.ReportName = Z34.TestRunName;
            reporter.Config.DocumentTitle = Z34.TestRunName;
            reporter.Config.Theme = Theme.Dark;

            _extent = new Reports();
            _extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Features.Add(_extent.CreateTest<Feature>(featureContext.FeatureInfo.Title));
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _currentScenario = Features
                .Single(feature => feature.Model.Name == _featureContext.FeatureInfo.Title)
                .CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.ScenarioExecutionStatus.ToString().Equals("StepDefinitionPending"))
                _ = stepType switch
                {
                    "Given" => _currentScenario
                        .CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                        .Skip("Step Definition Pending"),

                    "When" => _currentScenario
                        .CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text)
                        .Skip("Step Definition Pending"),

                    "Then" => _currentScenario
                        .CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text)
                        .Skip("Step Definition Pending"),

                    "And" => _currentScenario
                        .CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text)
                        .Skip("Step Definition Pending"),

                    _ => throw new ArgumentOutOfRangeException(nameof(stepType), stepType,
                        $"Invalid Step Type: {stepType}")
                };

            if (_scenarioContext.TestError is null)
                _ = stepType switch
                {
                    "Given" => _currentScenario
                        .CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text),

                    "When" => _currentScenario
                        .CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text),

                    "Then" => _currentScenario
                        .CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text),

                    "And" => _currentScenario
                        .CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text),

                    _ => throw new ArgumentOutOfRangeException(nameof(stepType), stepType,
                        $"Invalid Step Type: {stepType}")
                };
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }
    }
}