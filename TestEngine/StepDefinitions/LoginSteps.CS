using System;
using System.Collections.Generic;
using ApplicationMap.Pages;
using Atata;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestEngine.Models;

namespace TestEngine.StepDefinitions
{
    public sealed class LoginSteps : BaseStep
    {
        [Given]
        public void GIVEN_I_NAVIGATE_TO_THE_LOGIN_PAGE()
        {
            Go.To<LoginPage>();
        }

        [Given(@"I CONFIRM THAT THE PAGE TITLE IS ""(.*)""")]
        public void GIVEN_I_CONFIRM_THAT_THE_PAGE_TITLE_IS_STRING(string title)
        {
            On<LoginPage>().PageTitle.Should.Equals(title);
        }

        [When]
        public void WHEN_I_LOG_IN_WITH_CREDENTIALS_FROM_A_BDD_TABLE(Table credentialsTable)
        {
            var users = (List<User>) credentialsTable.CreateSet<User>();

            var random = new Random();
            var randomUser = users[random.Next(users.Count - 1)];

            On<LoginPage>()
                .UsernameInput.Set(randomUser.Username)
                .PasswordInput.Set(randomUser.Password)
                .LogInButton.ClickAndGo();
        }

        [When(@"I CONFIRM THAT THE PAGE TITLE IS ""(.*)""")]
        public void WHEN_I_CONFIRM_THAT_THE_PAGE_TITLE_IS_STRING(string title)
        {
            On<HomePage>().PageTitle.Should.Equals(title);
        }

        [Then]
        public void THEN_I_TRIGGER_A_JAVASCRIPT_ALERT_WITH_A_MESSAGE()
        {
            On<HomePage>()
                .HomePageImage.Should.BeVisible()
                .Report.Screenshot();

            AtataContext.Current.Driver.ExecuteScript("alert('Hello human! I am an alert box!!')");
        }
    }
}