using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;

namespace TestRunner.TestHookConfig
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        private static ExtentReports _extent;

        private readonly FeatureContext _featureContext;
        private readonly ParallelTestExecution _parallelTestExecution;
        private readonly ScenarioContext _scenarioContext;

        public HookInitialize(ParallelTestExecution parallelTestExecution, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string run = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";

            ExtentHtmlReporter reporter = new ExtentHtmlReporter($"..\\..\\..\\..\\REPORTS\\{run}\\");
            reporter.Config.ReportName = run;
            reporter.Config.DocumentTitle = run;
            reporter.Config.Theme = Theme.Standard;

            _extent = new ExtentReports();
            _extent.AttachReporter(reporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            InitializeConfig();
            Settings.DatabaseConnection = Settings.DatabaseConnection.DBConnect(Settings.ConnectionString);

            _feature = _extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

            #pragma warning disable CS4014
            LogHelpers.WriteToLog($"[START] :: {_featureContext.FeatureInfo.Title} :: {_scenarioContext.ScenarioInfo.Title}");
            #pragma warning restore CS4014
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
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "When":
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "Then":
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "And":
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    default:
                        #pragma warning disable CS4014
                        LogHelpers.WriteToLog($"[ERROR] :: Invalid Step Type: {stepType}");
                        #pragma warning restore CS4014

                        throw new ArgumentOutOfRangeException(nameof(stepType), stepType, $"Invalid Step Type: {stepType}");
                }
            }

            else if (_scenarioContext.TestError != null)
            {
                #pragma warning disable CS4014
                LogHelpers.WriteToLog($"[ERROR] :: Current Scenario Error: {_scenarioContext.TestError.Message}");
                #pragma warning restore CS4014

                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;

                    case "When":
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;

                    case "Then":
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;

                    case "And":
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;

                    default:
                        #pragma warning disable CS4014
                        LogHelpers.WriteToLog($"[ERROR] :: Invalid Step Type: {stepType}");
                        #pragma warning restore CS4014

                        throw new ArgumentOutOfRangeException(nameof(stepType), stepType, $"Invalid Step Type: {stepType}");
                }
            }

            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                        break;

                    case "When":
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                        break;

                    case "Then":
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                        break;

                    case "And":
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                        break;

                    default:
                        #pragma warning disable CS4014
                        LogHelpers.WriteToLog($"[ERROR] :: Invalid Step Type: {stepType}");
                        #pragma warning restore CS4014

                        throw new ArgumentOutOfRangeException(nameof(stepType), stepType, $"Invalid Step Type: {stepType}");
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _parallelTestExecution.Driver.Close();
            _parallelTestExecution.Driver.Quit();

            #pragma warning disable CS4014
            LogHelpers.WriteToLog($"[READY] :: {_featureContext.FeatureInfo.Title} :: {_scenarioContext.ScenarioInfo.Title}");
            #pragma warning restore CS4014
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();

            #pragma warning disable CS4014
            LogHelpers.WriteToLog("Test Run Results :: TODO: ADD LINK TO RESULTS FILE");
            #pragma warning restore CS4014
        }
    }
}