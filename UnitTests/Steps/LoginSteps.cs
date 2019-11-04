﻿using Framework.Base;
using TechTalk.SpecFlow;
using UnitTests.Pages;

namespace UnitTests.Steps
{
    [Binding]
    public sealed class LoginSteps : BaseStep
    {
        private readonly ScenarioContext _context;

        public LoginSteps(ScenarioContext injectedContext)
        {
            _context = injectedContext;
        }

        [Given]
        public void Given_I_HAVE_NAVIGATED_TO_THE_APPLICATION()
        {
            NavigateToAUT();
            CurrentPage = GetInstance<HomePage>();
        }

        [Given]
        public void Given_I_CONFIRM_THE_APPLICATION_IS_RUNNING()
        {
            _context.Pending();
        }

        [Given]
        public void Given_I_CLICK_THE_LOGIN_LINK()
        {
            _context.Pending();
        }

        [When]
        public void When_I_ENTER_MY_USERNAME_AND_PASSWORD(Table table)
        {
            _context.Pending();
        }

        [When]
        public void When_I_CLICK_THE_LOGIN_BUTTON()
        {
            _context.Pending();
        }

        [Then]
        public void Then_I_SHOULD_BE_AUTHENTICATED_AND_SEE_A_GREETING_MESSAGE()
        {
            _context.Pending();
        }
    }
}