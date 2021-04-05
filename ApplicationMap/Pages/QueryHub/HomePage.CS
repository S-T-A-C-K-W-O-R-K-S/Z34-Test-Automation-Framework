using ApplicationMap.Pages.Common;
using FrameworkCore.Configuration;
using PlaywrightSharp;

namespace ApplicationMap.Pages.QueryHub
{
    public sealed class HomePage : BaseQueryHubPage
    {
        public new readonly IPage Self;

        public HomePage(IPage Page) : base(Page)
        {
            Self = Page;
        }

        public override string URL => Z34.Host.QueryHub + "qh/qh-app/#/";
    }
}