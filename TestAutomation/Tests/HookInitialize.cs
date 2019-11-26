using System;
using System.Diagnostics.CodeAnalysis;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;

namespace TestAutomation.Tests
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private readonly ParallelTestExecution _parallelTestExecution;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        public HookInitialize (ParallelTestExecution parallelTestExecution, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        private static ExtentReports _extent;
        private static ExtentKlovReporter _klov;

        [BeforeTestRun]
        [SuppressMessage("Compiler Warning", "CS0162: Unreachable Code Detected", Justification = "Refactor Pending")]
        public void BeforeTestRun()
        {
            InitializeConfig();
            Settings.DatabaseConnection = Settings.DatabaseConnection.DBConnect(Settings.ConnectionString);
            string run = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";

            ExtentHtmlReporter reporter = new ExtentHtmlReporter($"..\\..\\..\\..\\REPORTS\\{run}\\");
            reporter.Config.ReportName = run;
            reporter.Config.DocumentTitle = run;
            reporter.Config.Theme = Theme.Standard;

            _extent = new ExtentReports();

            if (false) // TODO: Handle Exception Thrown While KLOV Is Not Running
            {
                _klov = new ExtentKlovReporter();
                _klov.InitMongoDbConnection("localhost", 27017);
                _klov.ProjectName = "Execute Automation Tests";
                _klov.InitKlovServerConnection("http://localhost:5689");
                _klov.ReportName = $"run_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";

                _extent.AttachReporter(reporter, _klov);
            }

            _extent.AttachReporter(reporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _feature = _extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

            LogHelpers.WriteToLog($"[START] :: {_featureContext.FeatureInfo.Title} >>> {_scenarioContext.ScenarioInfo.Title}");
        }

        [AfterStep]
        public void AfterStep()
        {
            string stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "When":
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "And":
                        _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    default:
                        LogHelpers.WriteToLog($"[ERROR] :: Invalid Step Type: {stepType}");
                        throw new ArgumentOutOfRangeException(nameof(stepType), stepType, $"Invalid Step Type: {stepType}");
                }
            }

            else if (_scenarioContext.TestError != null)
            {
                LogHelpers.WriteToLog($"[ERROR] :: Current Scenario Error: {_scenarioContext.TestError.Message}");

                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;
                    case "When":
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;
                    case "And":
                        _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;
                    default:
                        LogHelpers.WriteToLog($"[ERROR] :: Invalid Step Type: {stepType}");
                        throw new ArgumentOutOfRangeException(nameof(stepType), stepType, $"Invalid Step Type: {stepType}");
                }
            }

            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        break;
                    case "When":
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        break;
                    case "And":
                        _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        break;
                    default:
                        LogHelpers.WriteToLog($"[ERROR] :: Invalid Step Type: {stepType}");
                        throw new ArgumentOutOfRangeException(nameof(stepType), stepType, $"Invalid Step Type: {stepType}");
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _parallelTestExecution.Driver.Close();
            _parallelTestExecution.Driver.Quit();

            LogHelpers.WriteToLog($"[END] :: {_featureContext.FeatureInfo.Title} >>> {_scenarioContext.ScenarioInfo.Title}");

            _extent.Flush();
        }
    }
}