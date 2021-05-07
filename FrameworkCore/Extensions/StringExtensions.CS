using System.Globalization;

namespace FrameworkCore.Extensions
{
	public static class StringExtensions
	{
		public static string ToTitleCase(this string text)
			=> text is not null ? new CultureInfo("en-GB", false).TextInfo.ToTitleCase(text) : null;

		/// <summary>
		/// Trims Leading And Trailing White-Space Characters, And Converts The Text To Uppercase
		/// </summary>
		/// <param name="text"></param>
		public static string Flatten(this string text)
			=> text is not null ? text.Trim().ToUpper() : null;
	}
}