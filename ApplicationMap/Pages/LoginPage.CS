using Atata;

namespace ApplicationMap.Pages
{
    using _ = LoginPage;

    [Url("http://.../qh/qh-app/#/auth/login")]
    public class LoginPage : Page<_>
    {
        [FindById("username-input")] public TextInput<_> UsernameInput { get; private set; }

        [FindById("password-input")] public PasswordInput<_> PasswordInput { get; private set; }

        [FindByTitle("Log In")] public Button<HomePage, _> LogInButton { get; private set; }
    }
}