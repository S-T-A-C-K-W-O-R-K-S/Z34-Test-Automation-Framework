using Framework.Config;
using Framework.Helpers;

namespace Framework.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateToAUT()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.WriteToLog($"Navigating To: {Settings.AUT}");
        }


    }
}