using Atata;
using NUnit.Framework;

namespace TestEngine.FixtureConfiguration
{
    [TestFixture]
    public class UITestFixture : BaseFixture
    {
        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure()
                .UseFirefox()
                .WithFixOfCommandExecutionDelay()
                .WithLocalDriverPath()
                .Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}