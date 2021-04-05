using Microsoft.Data.Sqlite;
using PlaywrightSharp;
using System;

namespace FrameworkCore.Configuration
{
    public static class Z34
    {
        public static string TestRunProfile = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TestRunProfile"))
            ? Environment.GetEnvironmentVariable("TestRunProfile")
            : "Z34 Default";

        public static class Host
        {
            public static string Base { get; set; }
            public static string QueryHub { get; set; }
            public static string Zeppelin { get; set; }
        }

        public static string TestRunName { get; set; }
        public static string TestResultsDir { get; set; }
        public static string TestRunBrowser { get; set; }
        public static LaunchOptions TestRunLaunchOptions { get; set; }

        public static SqliteConnectionStringBuilder ConnectionStringBuilder { get; set; }
        public static SqliteConnection DatabaseConnection { get; set; }
    }
}