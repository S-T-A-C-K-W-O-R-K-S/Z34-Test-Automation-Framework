using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;

namespace TestRunner.Steps
{
    public class StepExtensions : BaseStep
    {
        private readonly FeatureContext _featureContext;
        private readonly ParallelTestExecution _parallelTestExecution;

        public StepExtensions(ParallelTestExecution parallelTestExecution, FeatureContext featureContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
        }

        public void NavigateToPage(string path = "")
        {
            string URL = Settings.AUT + path;

            _parallelTestExecution.Driver.Navigate().GoToUrl(URL);
            LogHelpers.WriteToLog($"[EVENT] :: [{_featureContext.FeatureInfo.Title.ToUpper()}] :: Navigate To Page :: {URL}");

            _parallelTestExecution.Driver.WaitForPageLoaded();
            LogHelpers.WriteToLog($"[EVENT] :: [{_featureContext.FeatureInfo.Title.ToUpper()}] :: DOM On Page Loaded :: {URL}");
        }
    }
}
