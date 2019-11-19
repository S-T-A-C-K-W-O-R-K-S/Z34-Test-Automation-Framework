using FrameworkCore.Config;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;

namespace FrameworkCore.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateToAUT()
        {
            DriverContext.Browser.GoToURL(Settings.AUT);
            LogHelpers.WriteToLog($"Navigating To Page: {Settings.AUT}");
            DriverContext.Driver.WaitForPageLoaded();
            LogHelpers.WriteToLog($"DOM On Page Fully Loaded: {Settings.AUT}");
        }
    }
}