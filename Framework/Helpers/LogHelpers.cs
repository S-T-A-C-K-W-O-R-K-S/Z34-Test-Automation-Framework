using System;
using System.IO;
using Framework.Config;

namespace Framework.Helpers
{
    public static class LogHelpers
    {
        private static readonly string LogFileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
        private static StreamWriter _streamWriter;

        public static void CreateLogFile()
        {
            string dir = Settings.LogPath;
            if (Directory.Exists(dir))
            {
                _streamWriter = File.AppendText(dir + LogFileName + ".log");
            }

            else
            {
                Directory.CreateDirectory(dir);
                _streamWriter = File.AppendText(dir + LogFileName + ".log");
            }
        }

        // TODO: Fix Inconsistent Timestamps
        public static void WriteToLog(string logMessage)
        {
            _streamWriter.Write("DEBUG :: " +
                                "DateTime.Now: " + DateTime.Now +
                                "| DateTime.Now.ToLongDateString: " + DateTime.Now.ToLongDateString() +
                                "| DateTime.Now.ToLongTimeString: " + DateTime.Now.ToLongTimeString() +
                                "| DateTime.Now.ToShortDateString: " + DateTime.Now.ToShortDateString() +
                                "| DateTime.Now.ToShortTimeString: " + DateTime.Now.ToShortTimeString() +
                                "| DateTime.Now.ToOADate: " + DateTime.Now.ToOADate() +
                                "| DateTime.Now.ToUniversalTime: " + DateTime.Now.ToUniversalTime());

            _streamWriter.Write("{0} @ {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            _streamWriter.WriteLine(" >>> {0}", logMessage);
            _streamWriter.Flush();
        }
    }
}