﻿using System;
using AventStack.ExtentReports;

// Currently Using The Unofficial ExtentReports.Core While ExtentReports Adds Support For .NET Core
// TODO: Revert To The Official ExtentReports Once Support For .NET Core Has Been Added

using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
using NUnit.Framework;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace TestRunner.TestHookConfig
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private static ExtentTest _feature;
        private ExtentTest _currentScenario;

        private static AventStack.ExtentReports.ExtentReports _extent;

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

            ExtentHtmlReporter reporter = new ExtentHtmlReporter($"REPORTS\\{run}\\");
            reporter.Config.ReportName = run;
            reporter.Config.DocumentTitle = run;
            reporter.Config.Theme = Theme.Standard;

            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(string config = "LOCAL-CHROME")
        {
            // TODO: Refactor Hard-Coded Config
            InitializeConfig(config);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            OpenBrowser(Settings.BrowserType);

            Settings.DatabaseConnection = Settings.DatabaseConnection.DBConnect(Settings.ConnectionString);

            _feature = _extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _currentScenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

            LogHelpers.WriteToLog($"[START] :: {_featureContext.FeatureInfo.Title} :: {_scenarioContext.ScenarioInfo.Title}");
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
                        _currentScenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "When":
                        _currentScenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "Then":
                        _currentScenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "And":
                        _currentScenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
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
                        _currentScenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;

                    case "When":
                        _currentScenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;

                    case "Then":
                        _currentScenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
                        break;

                    case "And":
                        _currentScenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.StackTrace);
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
                        _currentScenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                        break;

                    case "When":
                        _currentScenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                        break;

                    case "Then":
                        _currentScenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                        break;

                    case "And":
                        _currentScenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
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

            LogHelpers.WriteToLog($"[CLOSE] :: {_featureContext.FeatureInfo.Title} :: {_scenarioContext.ScenarioInfo.Title}");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();

            LogHelpers.WriteToLog("[FINAL] :: Test Run Results :: TODO: ADD LINK TO RESULTS FILE");
        }
    }
}