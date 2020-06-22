using FrameworkCore.Base;
using TechTalk.SpecFlow;

namespace TestRunner.Steps
{
    [Binding]
    class LoginSteps : BaseStep
    {
        private readonly FeatureContext _featureContext;
        private readonly ParallelTestExecution _parallelTestExecution;

        public LoginSteps(ParallelTestExecution parallelTestExecution, FeatureContext featureContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
        }

        [Given]
        public void Given_I_CONFIRM_THAT_THE_LOGIN_FORM_IS_DISPLAYED()
        {
            ScenarioContext.Current.Pending();
        }

        [When]
        public void When_I_PICK_A_RANDOM_P0_ADDRESS_AND_P1_FROM_A_BDD_TABLE(string p0, string p1, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When]
        public void When_I_CHOOSE_TO_REMEMBER_MY_CREDENTIALS()
        {
            ScenarioContext.Current.Pending();
        }

        [When]
        public void When_I_CLICK_THE_LOGIN_BUTTON()
        {
            ScenarioContext.Current.Pending();
        }

        [Then]
        public void Then_I_SHOULD_BE_AUTHENTICATED_AND_REDIRECTED_TO_THE_DASHBOARD()
        {
            ScenarioContext.Current.Pending();
        }

        [When]
        public void When_I_PICK_A_RANDOM_EMAIL_ADDRESS_AND_PASSWORD_FROM_A_P0(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
