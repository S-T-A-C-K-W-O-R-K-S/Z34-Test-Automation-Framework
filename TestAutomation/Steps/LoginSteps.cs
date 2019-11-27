using FrameworkCore.Base;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomation.Pages;

namespace TestAutomation.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        private readonly ParallelTestExecution _parallelTestExecution;

        public LoginSteps(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
        }

        [Given]
        public void Given_I_CONFIRM_THE_APPLICATION_IS_RUNNING()
        {
            _parallelTestExecution.CurrentPage.As<HomePage>().AssertLoginLinkPresence();
        }

        [Given]
        public void Given_I_CLICK_THE_LOGIN_LINK()
        {
            _parallelTestExecution.CurrentPage = _parallelTestExecution.CurrentPage.As<HomePage>().ClickLogIn();
        }

        [When]
        public void When_I_ENTER_MY_USERNAME_AND_PASSWORD(Table credentialsTable)
        {
            dynamic data = credentialsTable.CreateDynamicInstance();
            _parallelTestExecution.CurrentPage.As<LoginPage>().EnterCredentials(data.USERNAME, data.PASSWORD);
        }

        [When]
        public void When_I_CLICK_THE_LOGIN_BUTTON()
        {
            _parallelTestExecution.CurrentPage = _parallelTestExecution.CurrentPage.As<LoginPage>().ClickLoginButton();
        }

        [Then]
        public void Then_I_SHOULD_BE_AUTHENTICATED_AND_SEE_A_GREETING_MESSAGE()
        {
            const string user = "admin";

            #pragma warning disable CS4014
            LogHelpers.WriteToLog(_parallelTestExecution.CurrentPage.As<HomePage>().GetLoggedInUser().Contains(user) ? $"Successfully Logged In As :: {user}" : $"[ERROR] :: Login Failed As :: {user}");
            #pragma warning restore CS4014
        }
    }
}