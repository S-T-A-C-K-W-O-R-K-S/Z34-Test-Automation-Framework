using FrameworkCore.Base;
using Microsoft.Data.Sqlite;

namespace FrameworkCore.Config
{
    public static class Settings
    {
        public static string AUT { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string LogPath { get; set; }
        public static SqliteConnection DatabaseConnection { get; set; }
        public static string ConnectionString { get; set; }
        public static bool DebugMode { get; set; }
        public static bool RemoteExecution { get; set; }
        public static string RemoteHost { get; set; }
        public static string RemoteBrowserVersion { get; set; }
    }
}
