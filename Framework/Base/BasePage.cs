using SeleniumExtras.PageObjects;

namespace Framework.Base
{
    public abstract class BasePage : Base
    {
        protected BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}