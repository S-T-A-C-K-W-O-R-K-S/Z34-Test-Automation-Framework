using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Atata;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;
using Reports = AventStack.ExtentReports.ExtentReports;

namespace FrameworkCore.EventLogConfiguration
{
    public static class ExtentContext
    {
        private static readonly Lazy<Reports> LazyReports =
            new Lazy<Reports>(CreateAndInitReportsInstance);

        private static readonly ConcurrentDictionary<AtataContext, ExtentTestData> ExtentTestDataMap =
            new ConcurrentDictionary<AtataContext, ExtentTestData>();

        public static string WorkingFolder { get; set; } =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? string.Empty, "Report");

        public static string ReportTitle { get; set; } =
            "UI Tests Report";

        public static Reports Reports =>
            LazyReports.Value;

        private static ExtentTestData CurrentTestData =>
            ExtentTestDataMap.GetOrAdd(AtataContext.Current, StartExtentTest);

        public static ExtentTest CurrentTest =>
            CurrentTestData.Test;

        public static LogEventInfo LastLogEventOfCurrentTest
        {
            get => CurrentTestData.LastLogEvent;
            set => CurrentTestData.LastLogEvent = value;
        }

        private static Reports CreateAndInitReportsInstance()
        {
            var reports = new Reports();

            if (Directory.Exists(WorkingFolder))
                Directory.Delete(WorkingFolder, true);

            var reporters = CreateReporters();

            reports.AttachReporter(reporters.ToArray());

            return reports;
        }

        private static IEnumerable<IExtentReporter> CreateReporters()
        {
            var htmlReporter = new ExtentHtmlReporter(
                WorkingFolder.EndsWith(Path.DirectorySeparatorChar)
                    ? WorkingFolder
                    : WorkingFolder + Path.DirectorySeparatorChar);

            htmlReporter.Config.DocumentTitle = ReportTitle;

            yield return htmlReporter;
        }

        private static ExtentTestData StartExtentTest(AtataContext atataContext)
        {
            return new ExtentTestData(
                Reports.CreateTest(atataContext.TestName));
        }

        private class ExtentTestData
        {
            public ExtentTestData(ExtentTest test)
            {
                Test = test;
            }

            public ExtentTest Test { get; }

            public LogEventInfo LastLogEvent { get; set; }
        }
    }
}