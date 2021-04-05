using System;
using System.Threading.Tasks;
using AventStack.ExtentReports.Gherkin.Model;
using FrameworkCore.Configuration;
using FrameworkCore.Extensions;
using FrameworkCore.Models;
using TechTalk.SpecFlow;

namespace TestEngine.Configuration.EventHookConfiguration
{
    public partial class SpecFlowEventBindings
    {
        [BeforeFeature("End-To-End")]
        public static async Task BeforeUIFeature(FeatureContext featureContext)
        {
            var playwrightDriver = new PlaywrightDriver();
            var (Browser, Page) = await playwrightDriver.InitialisePlaywrightDriver(Z34.TestRunBrowser,
                _playwrightLogger, Z34.TestRunLaunchOptions);

            featureContext.SetBrowserInstance(Browser);
            featureContext.SetPageInstance(Page);
        }

        [AfterStep("End-To-End")]
        public async Task AfterUIStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError is not null)
            {
                var mediaEntity = await _featureContext.GetPageInstance()
                    .CaptureScreenshotAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());

                _ = stepType switch
                {
                    "Given" => _currentScenario
                        .CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message, mediaEntity),

                    "When" => _currentScenario
                        .CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message, mediaEntity),

                    "Then" => _currentScenario
                        .CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message, mediaEntity),

                    "And" => _currentScenario
                        .CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message, mediaEntity),

                    _ => throw new ArgumentOutOfRangeException(nameof(stepType), stepType,
                        $"Invalid Step Type: {stepType}")
                };
            }
        }

        [AfterFeature("End-To-End")]
        public static async Task AfterUIFeature(FeatureContext featureContext)
        {
            foreach (var context in featureContext.GetBrowserInstance().Contexts)
                await context.CloseAsync();

            await featureContext.GetBrowserInstance().CloseAsync();
        }
    }
}