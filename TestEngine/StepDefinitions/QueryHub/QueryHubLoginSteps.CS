using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationMap.Pages.QueryHub;
using FrameworkCore.Extensions;
using FrameworkCore.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestEngine.StepDefinitions.Common;

namespace TestEngine.StepDefinitions.QueryHub
{
    [Binding]
    public sealed class QueryHubLoginSteps : BaseStep
    {
        private new readonly FeatureContext FeatureContext;
        private HomePage HomePage;

        private LoginPage LoginPage;

        public QueryHubLoginSteps(FeatureContext FeatureContext) : base(FeatureContext)
        {
            this.FeatureContext = FeatureContext;
        }

        [Given]
        public async Task GIVEN_I_NAVIGATE_TO_THE_LOGIN_PAGE()
        {
            LoginPage = new LoginPage(FeatureContext.GetPageInstance());
            await LoginPage.Self.GoToAsync(LoginPage.URL);
        }

        [Given(@"I CONFIRM THAT THE PAGE TITLE IS ""(.*)""")]
        public async Task GIVEN_I_CONFIRM_THAT_THE_PAGE_TITLE_IS_STRING(string title)
        {
            Assert.AreEqual(title, await LoginPage.Self.GetTitleAsync(), "QueryHub Login Page Title");
        }

        [When]
        public async Task WHEN_I_LOG_IN_WITH_CREDENTIALS_FROM_A_TABLE(Table credentialsTable)
        {
            var users = (List<User>) credentialsTable.CreateSet<User>();
            var randomUser = users[new Random().Next(users.Count - 1)];

            FeatureContext.SetUser(new User {Username = randomUser.Username, Password = randomUser.Password});

            await LoginPage.LogIn(randomUser.Username, randomUser.Password);

            HomePage = new HomePage(FeatureContext.GetPageInstance());
        }

        [Then]
        public async Task THEN_I_CONFIRM_THAT_I_AM_LOGGED_IN_AS_THE_SELECTED_USER()
        {
            Assert.AreEqual(FeatureContext.GetUser().Username.Flatten(),
                (await HomePage.TitleBar.GetLoggedInUserName()).Flatten(), "QueryHub Logged In User");
        }
    }
}