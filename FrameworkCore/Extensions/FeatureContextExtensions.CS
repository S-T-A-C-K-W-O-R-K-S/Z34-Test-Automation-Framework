using FrameworkCore.Models;
using PlaywrightSharp;
using TechTalk.SpecFlow;

namespace FrameworkCore.Extensions
{
	public static class FeatureContextExtensions
	{
		// TODO: These Should Probably Be Properties

		public static void SetPageInstance(this FeatureContext context, IPage page)
		{
			if (!context.TryGetValue<IPage>("PageInstance", out IPage _)) context.Add("PageInstance", page);
			if (context.TryGetValue<IPage>("PageInstance", out IPage _)) context.Set(page, "PageInstance");
		}

		public static IPage GetPageInstance(this FeatureContext context)
			=> context.TryGetValue<IPage>("PageInstance", out IPage _) ? context.Get<IPage>("PageInstance") : null;

		public static void SetBrowserInstance(this FeatureContext context, IBrowser browser)
		{
			if (!context.TryGetValue<IBrowser>("BrowserInstance", out IBrowser _)) context.Add("BrowserInstance", browser);
			if (context.TryGetValue<IBrowser>("BrowserInstance", out IBrowser _)) context.Set(browser, "BrowserInstance");
		}

		public static IBrowser GetBrowserInstance(this FeatureContext context)
			=> context.TryGetValue<IBrowser>("BrowserInstance", out IBrowser _) ? context.Get<IBrowser>("BrowserInstance") : null;

		public static void SetUser(this FeatureContext context, User user)
		{
			if (!context.TryGetValue<User>("User", out User _)) context.Add("User", user);
			if (context.TryGetValue<User>("User", out User _)) context.Set(user, "User");
		}

		public static User GetUser(this FeatureContext context)
			=> context.TryGetValue<User>("User", out User _) ? context.Get<User>("User") : null;
	}
}