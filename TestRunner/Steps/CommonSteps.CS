using ApplicationMap.Pages;
using FrameworkCore.Base;
using TechTalk.SpecFlow;

namespace TestRunner.Steps
{
    [Binding]
    public class CommonSteps : BaseStep
    {
        private readonly FeatureContext _featureContext;
        private readonly ParallelTestExecution _parallelTestExecution;

        public CommonSteps(ParallelTestExecution parallelTestExecution, FeatureContext featureContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
        }

        private StepExtensions StepExtensions => new StepExtensions(_parallelTestExecution, _featureContext);

        [Given]
        public void Given_I_HAVE_NAVIGATED_TO_THE_LOGIN_PAGE()
        {
            StepExtensions.NavigateToPage("login.html");
            _parallelTestExecution.CurrentPage = new LoginPage(_parallelTestExecution);
        }
    }
}
