﻿using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace TestRunner.Pages
{
    internal class LoginPage : BasePage
    {
        public LoginPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
        }

        private IWebElement TextUserName => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("UserName"));
        private IWebElement TextPassword => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("Password"));
        private IWebElement ButtonLogin => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("input.btn"));

        internal void EnterCredentials(string userName, string password)
        {
            TextUserName.SendKeys(userName);
            TextPassword.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            ButtonLogin.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new HomePage(ParallelTestExecution);
        }

        internal void AssertLoginFormExists()
        {
            TextUserName.ElementIsDisplayed();
            TextPassword.ElementIsDisplayed();
        }
    }
}