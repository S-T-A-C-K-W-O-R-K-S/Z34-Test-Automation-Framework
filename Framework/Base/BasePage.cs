using SeleniumExtras.PageObjects;

namespace Framework.Base
{
    public class BasePage : Base
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}