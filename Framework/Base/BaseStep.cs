using Framework.Config;
using Framework.Helpers;

namespace Framework.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateToAUT()
        {
            DriverContext.Browser.GoToURL(Settings.AUT);
            LogHelpers.WriteToLog($"Navigating To: {Settings.AUT}");
        }
    }
}