using System.Data.SqlClient;
using Framework.Base;

namespace Framework.Config
{
    public static class Settings
    {
        public static string AUT { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string LogPath { get; set; }
        public static SqlConnection DatabaseConnection { get; set; }
        public static string ConnectionString { get; set; }
        public static bool DebugMode { get; set; }
    }
}