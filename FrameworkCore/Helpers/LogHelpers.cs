using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FrameworkCore.Config;

namespace FrameworkCore.Helpers
{
    public static class LogHelpers
    {
        private static readonly string LogFileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
        private static readonly string LogPath = Settings.LogPath;
        private static readonly string LogFile = LogPath + LogFileName + ".log";

        public static void CreateLogFile()
        {
            if (!Directory.Exists(LogPath)) Directory.CreateDirectory(LogPath);

            if (!Settings.DebugMode || File.Exists(LogFile)) return;

            StreamWriter streamWriter = File.AppendText(LogFile);
            streamWriter.WriteLine("[DEBUG] :: LOGGING STARTED" + Environment.NewLine +
                                   "\t" + "DateTime.Now" + "\t" + "\t" + ":" + "\t" + DateTime.Now + Environment.NewLine +
                                   "\t" + ".ToLongDateString" + "\t" + ":" + "\t" + DateTime.Now.ToLongDateString() + Environment.NewLine +
                                   "\t" + ".ToLongTimeString" + "\t" + ":" + "\t" + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                   "\t" + ".ToUniversalTime" + "\t" + ":" + "\t" + DateTime.Now.ToUniversalTime() + Environment.NewLine +
                                   "\t" + ".ToLocalTime" + "\t" + "\t" + ":" + "\t" + DateTime.Now.ToLocalTime() + Environment.NewLine);
            streamWriter.Close();
        }

        public static async Task WriteToLog(string logMessage, bool append = true)
        {
            string logEvent = $"{DateTime.Now:dd.MM.yyyy} @ {DateTime.Now:HH.mm.ss} >>> {logMessage}" + Environment.NewLine;
            byte[] encodedText = Encoding.ASCII.GetBytes(logEvent);

            using (FileStream sourceStream = new FileStream(LogFile, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            }
        }
    }
}