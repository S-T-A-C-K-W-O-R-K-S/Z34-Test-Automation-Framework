using Framework.Config;
using Framework.Extensions;
using Framework.Helpers;

namespace Framework.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateToAUT()
        {
            DriverContext.Browser.GoToURL(Settings.AUT);
            LogHelpers.WriteToLog($"Navigating To Page: {Settings.AUT}");
            DriverContext.Driver.WaitForPageLoaded();
            LogHelpers.WriteToLog($"DOM Fully Loaded: {Settings.AUT}");
        }
    }
}