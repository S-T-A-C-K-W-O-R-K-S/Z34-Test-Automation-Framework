using System;
using System.IO;

namespace Framework.Helpers
{
    public class LogHelpers
    {
        private static string logFileName = string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        public static void CreateLogFile()
        {
            string dir = @"C:\LOGS\";
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + logFileName + ".log");
            }

            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + logFileName + ".log");
            }
        }

        public static void WriteToLog(string logMessage)
        {
            _streamw.Write("{0} @ {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            _streamw.WriteLine(" >>> {0}", logMessage);
            _streamw.Flush();
        }
    }
}
