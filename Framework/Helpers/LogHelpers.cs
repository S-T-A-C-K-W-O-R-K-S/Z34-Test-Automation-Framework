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
            string logPath = Settings.LogPath;
            if (Directory.Exists(logPath))
            {
                _streamWriter = File.AppendText(logPath + LogFileName + ".log");
            }

            else
            {
                Directory.CreateDirectory(logPath);
                _streamWriter = File.AppendText(logPath + LogFileName + ".log");
            }

            if (Settings.DebugMode)
            {
                _streamWriter.WriteLine("[DEBUG] :: LOG CREATED" + Environment.NewLine +
                                        "\t" + "DateTime.Now" + "\t" + "\t" + ":" + "\t" + DateTime.Now + Environment.NewLine +
                                        "\t" + ".ToLongDateString" + "\t" + ":" + "\t" + DateTime.Now.ToLongDateString() + Environment.NewLine +
                                        "\t" + ".ToLongTimeString" + "\t" + ":" + "\t" + DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                        "\t" + ".ToUniversalTime" + "\t" + ":" + "\t" + DateTime.Now.ToUniversalTime() + Environment.NewLine +
                                        "\t" + ".ToLocalTime" + "\t" + "\t" + ":" + "\t" + DateTime.Now.ToLocalTime() + Environment.NewLine);
            }
        }

        // TODO: Fix Inconsistent Timestamps
        public static void WriteToLog(string logMessage)
        {
            _streamWriter.WriteLine("{0} @ {1} >>> {2}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), logMessage);
            _streamWriter.Flush();
        }
    }
}