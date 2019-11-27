using System;
using System.IO;
using FrameworkCore.Config;

namespace FrameworkCore.Helpers
{
    public static class LogHelpers
    {
        private static readonly string LogFileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
        private static readonly string LogPath = Settings.LogPath;
        private static readonly string LogFile = LogPath + LogFileName + ".log";
        private static StreamWriter _streamWriter;

        public static void CreateLogFile()
        {
            if (!Directory.Exists(LogPath)) Directory.CreateDirectory(LogPath);

            if (!Settings.DebugMode || File.Exists(LogFile)) return;

            _streamWriter = File.AppendText(LogFile);
            _streamWriter.WriteLine("[DEBUG] :: LOGGING STARTED" + Environment.NewLine +
                                    "\t" + "DateTime.Now" + "\t" + "\t" + ":" + "\t" + DateTime.Now + Environment.NewLine +
                                    "\t" + ".ToLongDateString" + "\t" + ":" + "\t" + DateTime.Now.ToLongDateString() + Environment.NewLine +
                                    "\t" + ".ToLongTimeString" + "\t" + ":" + "\t" + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                    "\t" + ".ToUniversalTime" + "\t" + ":" + "\t" + DateTime.Now.ToUniversalTime() + Environment.NewLine +
                                    "\t" + ".ToLocalTime" + "\t" + "\t" + ":" + "\t" + DateTime.Now.ToLocalTime() + Environment.NewLine);
            _streamWriter.Close();
        }

        public static void WriteToLog(string logMessage)
        {
            _streamWriter = File.AppendText(LogFile);
            _streamWriter.WriteLine("{0:dd.MM.yyyy} @ {0:HH.mm.ss} >>> {1}", DateTime.Now, logMessage);
            _streamWriter.Close();
        }
    }
}