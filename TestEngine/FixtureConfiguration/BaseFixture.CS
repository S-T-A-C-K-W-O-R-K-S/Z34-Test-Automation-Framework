using Atata;
using FrameworkCore.EventLogConfiguration;
using NUnit.Framework;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(5)]

// NUnit Doesn't Create A Separate Instance Of The Test Fixture For Each Execution Of A Test (The State Is Shared Between Executions)
// The Above Means That Having The Parallel Scope Set To A Scope Narrower Than "Fixtures" Causes Runtime Exceptions
// The Most Common Exception Caused By Setting An Unsupported Parallel Scope Is [System.ArgumentException : An Item With The Same Key Has Already Been Added]

namespace TestEngine.FixtureConfiguration
{
    [Binding]
    public abstract class BaseFixture
    {
        [BeforeTestRun]
        public static void SetUpTestRun()
        {
            AtataContext.GlobalConfiguration
                .UseCulture("en-GB")
                .UseAllNUnitFeatures()
                .AddLogConsumer(new ExtentLogConsumer())
                .AddScreenshotConsumer(new ExtentScreenshotConsumer());
        }

        [AfterTestRun]
        public static void TearDownTestRun()
        {
            ExtentContext.Reports.Flush();
        }
    }
}