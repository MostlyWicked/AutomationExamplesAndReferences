using difido_client;

namespace SeleniumReference
{
    public abstract class AbstractPage
    {
        protected IReportDispatcher Report = ReportManager.Instance;

        public WebDriverWrapper InnerDriver { get; protected set; }

        protected AbstractPage(WebDriverWrapper driver)
        {
            InnerDriver = driver;
        }
    }

}
