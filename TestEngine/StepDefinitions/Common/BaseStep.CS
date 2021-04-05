using TechTalk.SpecFlow;

namespace TestEngine.StepDefinitions.Common
{
    [Binding]
    public abstract class BaseStep : Steps
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        public BaseStep()
        {
        }

        public BaseStep(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        public BaseStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public BaseStep(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
    }
}