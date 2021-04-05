using System.Threading.Tasks;
using FrameworkCore.Configuration;
using PlaywrightSharp;

namespace ApplicationMap.Pages.QueryHub
{
    public sealed class LoginPage
    {
        public readonly IPage Self;
        public string URL = Z34.Host.QueryHub + "qh/qh-app/#/auth/login";

        public LoginPage(IPage page)
        {
            Self = page;
        }

        private string UsernameInput => "#username";
        private string PasswordInput => "#password";
        private string LoginButton => "input:text('Sign In')";

        public async Task LogIn(string user, string pass)
        {
            await Self.TypeAsync(UsernameInput, user);
            await Self.TypeAsync(PasswordInput, pass);
            await Self.ClickAsync(LoginButton);
        }
    }
}