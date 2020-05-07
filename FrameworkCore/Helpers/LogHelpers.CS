using System;
using System.IO;
using System.Text;
using FrameworkCore.Config;

namespace FrameworkCore.Helpers
{
    public static class LogHelpers
    {
        private static readonly string LogFileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
        private static readonly string LogPath = Settings.LogPath;

        public static string LogFile { get; set; }

        // TODO: Make Log HTML File, For More Aesthetic Text Formatting

        public static void InitializeLogFile()
        {
            LogFile = LogPath + LogFileName + ".log";

            if (!Directory.Exists(LogPath)) Directory.CreateDirectory(LogPath);

            if (!Settings.DebugMode || File.Exists(LogFile)) return;

            StreamWriter streamWriter = File.AppendText(LogFile);

            streamWriter.WriteLine(new StringBuilder()
                .AppendLine("[DEBUG] :: LOGGING STARTED")
                .AppendLine("\t" + "DateTime.Now" + "\t" + "\t" + ":" + "\t" + DateTime.Now)
                .AppendLine("\t" + ".ToLongDateString" + "\t" + ":" + "\t" + DateTime.Now.ToLongDateString())
                .AppendLine("\t" + ".ToLongTimeString" + "\t" + ":" + "\t" + DateTime.Now.ToLongTimeString())
                .AppendLine("\t" + ".ToUniversalTime" + "\t" + ":" + "\t" + DateTime.Now.ToUniversalTime())
                .AppendLine("\t" + ".ToLocalTime" + "\t" + "\t" + ":" + "\t" + DateTime.Now.ToLocalTime()));

            streamWriter.Close();
        }

        public static async void WriteToLog(string logMessage)
        {
            string logEvent = $"{DateTime.Now:dd.MM.yyyy} @ {DateTime.Now:HH.mm.ss} >>> {logMessage}" + Environment.NewLine;

            await File.AppendAllTextAsync(LogFile, logEvent);
        }
    }
}
