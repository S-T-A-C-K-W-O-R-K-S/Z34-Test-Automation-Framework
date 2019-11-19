using Framework.Base;
using Framework.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UnitTests.Pages;

namespace UnitTests.Steps
{
    [Binding]
    public sealed class LoginSteps : BaseStep
    {
        // TODO: Implement Scenario Context Via Context Injection
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        //
        // private readonly ScenarioContext context;
        //
        // public Employee(ScenarioContext injectedContext)
        // {
        //     context = injectedContext;
        // }

        [Given]
        public void Given_I_HAVE_NAVIGATED_TO_THE_APPLICATION()
        {
            NavigateToAUT();
            CurrentPage = GetInstance<HomePage>();
        }

        [Given]
        public void Given_I_CONFIRM_THE_APPLICATION_IS_RUNNING()
        {
            CurrentPage.As<HomePage>().AssertLoginLinkPresence();
        }

        [Given]
        public void Given_I_CLICK_THE_LOGIN_LINK()
        {
            CurrentPage = CurrentPage.As<HomePage>().ClickLogIn();
        }

        [When]
        public void When_I_ENTER_MY_USERNAME_AND_PASSWORD(Table credentialsTable)
        {
            dynamic data = credentialsTable.CreateDynamicInstance();
            CurrentPage.As<LoginPage>().EnterCredentials(data.USERNAME, data.PASSWORD);
        }

        [When]
        public void When_I_CLICK_THE_LOGIN_BUTTON()
        {
            CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
        }

        [Then]
        public void Then_I_SHOULD_BE_AUTHENTICATED_AND_SEE_A_GREETING_MESSAGE()
        {
            const string user = "admin";
            LogHelpers.WriteToLog(CurrentPage.As<HomePage>().GetLoggedInUser().Contains(user) ? $"Successfully Logged In As: {user}" : $"[ERROR] :: Login Failed As: {user}");
        }
    }
}