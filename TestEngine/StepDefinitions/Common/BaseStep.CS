using TechTalk.SpecFlow;

namespace TestEngine.StepDefinitions.Common
{
    [Binding]
    public abstract class BaseStep : Steps
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        protected BaseStep()
        {
        }

        protected BaseStep(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        protected BaseStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        protected BaseStep(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
    }
}