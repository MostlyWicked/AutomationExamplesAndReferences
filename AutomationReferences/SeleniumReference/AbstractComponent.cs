

using difido_client;

namespace SeleniumReference
{
    abstract class AbstractComponent
    {
        protected IReportDispatcher Report = ReportManager.Instance;

        // The AbstractComponent class is the base class for all the elements on a page
        // A component may be a part of either another component (such as a panel) or a page.
        public AbstractComponent ParentComponent { get; protected set; }
        public AbstractPage ParentPage { get; protected set; }

        protected WebDriverWrapper InnerDriver { get; set; }

        // The saved xpath locator can be used for various actions on the component
        protected string Locator;

        protected AbstractComponent(AbstractComponent parentComponent, string locator)
        {
            ParentComponent = parentComponent;
            Locator = locator;
            InnerDriver = parentComponent.InnerDriver;
        }

        protected AbstractComponent(AbstractPage parentPage, string locator)
        {
            ParentPage = parentPage;
            Locator = locator;
            InnerDriver = parentPage.InnerDriver;
        }
    }
}
