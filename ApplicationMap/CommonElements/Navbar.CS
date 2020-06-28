using FrameworkCore.Base;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using OpenQA.Selenium;

namespace ApplicationMap.CommonElements
{
    public class Navbar : BaseElement
    {
        public readonly IWebElement Self;

        public Navbar(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
            this.Self = ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("nav.navbar"));
        }

        public IWebElement TextSearchBar => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("input[aria-label='Search']"));
        public IWebElement ButtonSearch => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("div.input-group button"));

        public IWebElement DropdownAlerts => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("alertsDropdown"));
        public IWebElement BadgeAlerts => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a#alertsDropdown span.badge"));
        public IWebElement DropdownMessages => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("messagesDropdown"));
        public IWebElement BadgeMessages => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a#messagesDropdown span.badge"));

        public IWebElement DropdownUserLink => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("userDropdown"));
        public IWebElement DropdownUserMenu => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("div[aria-labelledby='userDropdown']"));
        public IWebElement LabelUserName => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("div[aria-labelledby='userDropdown'] span"));
        public IWebElement LabelUserAvatar => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("div[aria-labelledby='userDropdown'] img"));

        public bool UserNameIs(string userName)
        {
            LogHelpers.WriteToLog(LabelUserName.Text == userName
                ? $"[EVENT] :: Logged In As '{LabelUserName.Text}'"
                : $"[ERROR] :: Not Logged In As '{LabelUserName.Text}'");

            return LabelUserName.Text == userName;
        }
    }
}
