
using difido_client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumReference
{
    // This class can also have an abstract base class, similarly to Components and Pages
    public class WebDriverWrapper
    {
        private IReportDispatcher Report = ReportManager.Instance;
        private IWebDriver InnerDriver;

        public enum Browsers
        {
            Chrome, Firefox, InternetExplorer, Edge
        }

        // A string or another type of argument can also be used if more convenient than enum
        public WebDriverWrapper(Browsers browser)
        {
            // WebDriver Factory
            switch (browser)
            {
                case Browsers.Chrome:
                    InnerDriver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    InnerDriver = new FirefoxDriver();
                    break;
                default:
                    throw new NotImplementedException("The selected browser is not currently supported");
            }
        }

        public bool Click(string locator, int timeout)
        {
            // Reporting the action is important, report can be made more specific
            Report.Report($"Clicking element at {locator}");

            // We'll need to use explicit waiting to ensure the clicked object has the chance to load
            WebDriverWait wait = new WebDriverWait(InnerDriver, TimeSpan.FromSeconds(timeout));

            try
            {
                wait.Until(d => d.FindElement(By.XPath(locator))).Click();
                return true;
            }
            catch
            {
                Report.Report("Click failed"); //Optionally - can fail the test by setting status to failure/error - see DifidoReportsReference
                return false;
            }
        }

        // This class can contain many useful methods that wrap the selenium WebDriver, such as searching for elements with
        // explicit timeout and more.
    }
}
