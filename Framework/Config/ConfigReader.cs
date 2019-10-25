using System;
using System.IO;
using System.Xml.XPath;

namespace Framework.Config
{
    public static class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            string configFile = Environment.CurrentDirectory + "\\Config\\GlobalConfig.xml";

            FileStream stream = new FileStream(configFile, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            XPathItem testType = navigator.SelectSingleNode("Framework/RunSettings/TestType");
            XPathItem aut = navigator.SelectSingleNode("Framework/RunSettings/AUT");
            XPathItem build = navigator.SelectSingleNode("Framework/RunSettings/Build");
            XPathItem browserType = navigator.SelectSingleNode("Framework/RunSettings/BrowserType");
            XPathItem isLog = navigator.SelectSingleNode("Framework/RunSettings/IsLog");
            XPathItem logPath = navigator.SelectSingleNode("Framework/RunSettings/LogPath");
            XPathItem isReport = navigator.SelectSingleNode("Framework/RunSettings/IsReport");

            if (testType != null) Settings.TestType = testType.ToString();
            if (aut != null) Settings.AUT = aut.ToString();
            if (build != null) Settings.Build = build.ToString();
            if (browserType != null) Settings.BrowserType = browserType.ToString();
            if (isLog != null) Settings.IsLog = isLog.ToString();
            if (logPath != null) Settings.LogPath = logPath.ToString();
            if (isReport != null) Settings.IsReport = isReport.ToString();
        }
    }
}