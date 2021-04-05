using System;
using System.IO;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace FrameworkCore.Configuration
{
    public class ConfigurationReader
    {
        public static void SetFrameworkSettings(string config)
        {
            var configurationFilePath = new StringBuilder(Directory.GetCurrentDirectory())
                .Append(Path.DirectorySeparatorChar).Append("Configuration")
                .Append(Path.DirectorySeparatorChar).Append("TestRunConfiguration")
                .ToString();

            ConfigurationBindings configBindings = new ConfigurationBuilder()
                .SetBasePath(configurationFilePath)
                .AddJsonFile("Z34.CONFIG.JSON")
                .Build()
                .GetSection(config)
                .Get<ConfigurationBindings>();

            Z34.Host.Base = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("Host"))
                ? Environment.GetEnvironmentVariable("Host")
                : configBindings.Host;

            Z34.Host.QueryHub = new UriBuilder("http", Z34.Host.Base, 9001).ToString();
            Z34.Host.Zeppelin = new UriBuilder("http", Z34.Host.Base, 9090).ToString();

            Z34.TestRunName = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TestRunName"))
                ? Environment.GetEnvironmentVariable("TestRunName")
                : $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";

            Z34.TestResultsDir = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TestResultsDir"))
                ? Path.Combine(Environment.GetEnvironmentVariable("TestResultsDir"), Z34.TestRunName)
                : !string.IsNullOrEmpty(configBindings.TestResultsDir)
                    ? Path.Combine(configBindings.TestResultsDir, Z34.TestRunName)
                    : Path.Combine(Environment.CurrentDirectory, "Z34 Test Results", Z34.TestRunName);

            Z34.TestRunBrowser = configBindings.TestRunBrowser;
            Z34.TestRunLaunchOptions = configBindings.TestRunLaunchOptions;
            Z34.ConnectionStringBuilder = new SqliteConnectionStringBuilder(configBindings.ConnectionString);
        }
    }
}