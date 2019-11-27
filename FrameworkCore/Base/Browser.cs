namespace FrameworkCore.Base
{
    public class Browser
    {
        private readonly DriverContext DriverContext;

        public Browser(DriverContext driverContext)
        {
            DriverContext = driverContext;
        }

        public BrowserType Type { get; set; }
    }

    public enum BrowserType
    {
        Firefox,
        Chrome
    }
}