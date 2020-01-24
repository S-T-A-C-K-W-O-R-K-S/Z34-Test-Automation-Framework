namespace FrameworkCore.Base
{
    public class Browser
    {
        private readonly DriverContext _driverContext;

        public Browser(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        public BrowserType Type { get; set; }
    }

    public enum BrowserType
    {
        Firefox,
        Chrome
    }
}