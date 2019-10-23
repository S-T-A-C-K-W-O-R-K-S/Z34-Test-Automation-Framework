using Framework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Config
{
    public class Settings
    {
        public static string TestType { get; set; }
        public static string AUT { get; set; }
        public static string Build { get; set; }
        public static string BrowserType { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
        public static string IsReport { get; set; }
    }
}
