using PlaywrightSharp;
using System.Threading.Tasks;

namespace ApplicationMap.Elements.Common
{
	public sealed class TitleBar
	{
		private readonly IPage Page;
		public TitleBar(IPage Page) => this.Page = Page;

		private string UserDropdown => "#user-dropdown";
		private string SettingsButton => ".btn-menu-icon";
		private string NotificationsButton => ".btn-notifications";

		public async Task<string> GetLoggedInUserName()
			=> await Page.GetInnerTextAsync(UserDropdown);
	}
}