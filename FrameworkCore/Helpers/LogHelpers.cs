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
        private static readonly string LogFile = LogPath + LogFileName + ".log";
        public static FileInfo LogFileInstance;

        public static FileInfo CreateLogFile()
        {
            if (!Directory.Exists(LogPath)) Directory.CreateDirectory(LogPath);

            FileInfo logFileInstance = new FileInfo(LogFile);

            if (Settings.DebugMode)
            {
                byte[] encodedDebugLogCreationEvent = Encoding.ASCII.GetBytes(new StringBuilder()
                    .AppendLine("[DEBUG] :: LOGGING STARTED")
                    .AppendLine("\t" + "DateTime.Now" + "\t" + "\t" + ":" + "\t" + DateTime.Now)
                    .AppendLine("\t" + ".ToLongDateString" + "\t" + ":" + "\t" + DateTime.Now.ToLongDateString())
                    .AppendLine("\t" + ".ToLongTimeString" + "\t" + ":" + "\t" + DateTime.Now.ToLongTimeString())
                    .AppendLine("\t" + ".ToUniversalTime" + "\t" + ":" + "\t" + DateTime.Now.ToUniversalTime())
                    .AppendLine("\t" + ".ToLocalTime" + "\t" + "\t" + ":" + "\t" + DateTime.Now.ToLocalTime())
                    .ToString());

                logFileInstance.AppendText().Write(encodedDebugLogCreationEvent);
            }

            return logFileInstance;
        }

        public static void WriteToLog(string logMessage, bool append = true)
        {
            string logEvent = $"{DateTime.Now:dd.MM.yyyy} @ {DateTime.Now:HH.mm.ss} >>> {logMessage}" + Environment.NewLine;
            byte[] encodedLogEvent = Encoding.ASCII.GetBytes(logEvent);

            using (FileStream sourceStream = new FileStream(LogFile, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.Write, 4096, true))
            {
                sourceStream.Write(encodedLogEvent, 0, encodedLogEvent.Length);
            }
        }
    }
}