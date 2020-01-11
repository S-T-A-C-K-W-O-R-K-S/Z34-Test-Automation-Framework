using System;
using System.IO;
using System.Text;
using FrameworkCore.Config;

namespace FrameworkCore.Helpers
{
    public static class LogHelpers
    {
        internal static class Log
        {
            internal static string FileName { get; set; }
            internal static string Path { get; set; }
            internal static string File { get; set; }
            public static FileInfo FileInstance { get; set; }
        }

        private static void InitializeLog()
        {
            Log.FileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
            Log.Path = Settings.LogPath;
            Log.File = Log.Path + Log.FileName + ".log";
        }

        public static FileInfo CreateLogFile()
        {
            InitializeLog();

            if (!Directory.Exists(Log.Path)) Directory.CreateDirectory(Log.Path);

            FileInfo logFileInstance = new FileInfo(Log.File);

            if (Settings.DebugMode)
            {
                byte[] encodedDebugModeLogCreationEvent = Encoding.ASCII.GetBytes(new StringBuilder()
                    .AppendLine("[DEBUG] :: LOGGING STARTED")
                    .AppendLine("\t" + "DateTime.Now" + "\t" + "\t" + ":" + "\t" + DateTime.Now)
                    .AppendLine("\t" + ".ToLongDateString" + "\t" + ":" + "\t" + DateTime.Now.ToLongDateString())
                    .AppendLine("\t" + ".ToLongTimeString" + "\t" + ":" + "\t" + DateTime.Now.ToLongTimeString())
                    .AppendLine("\t" + ".ToUniversalTime" + "\t" + ":" + "\t" + DateTime.Now.ToUniversalTime())
                    .AppendLine("\t" + ".ToLocalTime" + "\t" + "\t" + ":" + "\t" + DateTime.Now.ToLocalTime())
                    .ToString());

                logFileInstance.AppendText().Write(encodedDebugModeLogCreationEvent);
            }

            return logFileInstance;
        }

        public static void WriteToLog(string logMessage, bool append = true)
        {
            string logEvent = $"{DateTime.Now:dd.MM.yyyy} @ {DateTime.Now:HH.mm.ss} >>> {logMessage}" + Environment.NewLine;
            byte[] encodedLogEvent = Encoding.ASCII.GetBytes(logEvent);

            using (FileStream sourceStream = new FileStream(Log.File, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 4096, true))
            {
                sourceStream.Write(encodedLogEvent, 0, encodedLogEvent.Length);
            }
        }
    }
}