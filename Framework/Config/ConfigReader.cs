using System;
using System.IO;
using System.Xml.XPath;
using Framework.Base;

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
            XPathItem connectionString = navigator.SelectSingleNode("Framework/RunSettings/ConnectionString");
            XPathItem debugMode = navigator.SelectSingleNode("Framework/RunSettings/DebugMode");

            if (testType != null) Settings.TestType = testType.Value;
            if (aut != null) Settings.AUT = aut.Value;
            if (build != null) Settings.Build = build.Value;
            if (browserType != null) Settings.BrowserType = (BrowserType) Enum.Parse(typeof(BrowserType), browserType.Value);
            if (isLog != null) Settings.IsLog = Convert.ToBoolean(isLog.Value);
            if (logPath != null) Settings.LogPath = logPath.Value;
            if (isReport != null) Settings.IsReport = Convert.ToBoolean(isReport.Value);
            if (connectionString != null) Settings.ConnectionString = connectionString.Value;
            if (debugMode != null) Settings.DebugMode = Convert.ToBoolean(debugMode.Value);
        }
    }
}