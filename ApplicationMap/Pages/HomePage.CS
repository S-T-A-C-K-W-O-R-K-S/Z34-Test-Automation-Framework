using Atata;

namespace ApplicationMap.Pages
{
    using _ = HomePage;

    [Url("http://.../qh/qh-app/#/")]
    public class HomePage : Page<_>
    {
        [FindById("homeImg")] public Image<_> HomePageImage { get; private set; }
    }
}