using System;
using System.IO;
using System.Xml.XPath;

namespace Framework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem TestType;
            XPathItem AUT;
            XPathItem Build;
            XPathItem BrowserType;
            XPathItem IsLog;
            XPathItem LogPath;
            XPathItem IsReport;

            string configFile = Environment.CurrentDirectory + "\\Config\\GlobalConfig.xml";

            FileStream stream = new FileStream(configFile, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            TestType = navigator.SelectSingleNode("Framework/RunSettings/TestType");
            AUT = navigator.SelectSingleNode("Framework/RunSettings/AUT");
            Build = navigator.SelectSingleNode("Framework/RunSettings/Build");
            BrowserType = navigator.SelectSingleNode("Framework/RunSettings/BrowserType");
            IsLog = navigator.SelectSingleNode("Framework/RunSettings/IsLog");
            LogPath = navigator.SelectSingleNode("Framework/RunSettings/LogPath");
            IsReport = navigator.SelectSingleNode("Framework/RunSettings/IsReport");

            Settings.TestType = TestType.ToString();
            Settings.AUT = AUT.ToString();
            Settings.Build = Build.ToString();
            Settings.BrowserType = BrowserType.ToString();
            Settings.IsLog = IsLog.ToString();
            Settings.LogPath = LogPath.ToString();
            Settings.IsReport = IsReport.ToString();
        }
    }
}