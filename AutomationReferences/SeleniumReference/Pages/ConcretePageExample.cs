
namespace SeleniumReference.Pages
{
    // An example for a page with two buttons
    class ConcretePageExample : AbstractPage
    {
        private const string ButtonLocator1 = "//div[@id='unique_button1_id']"; //xpath should lead to unique web element
        private const string ButtonLocator2 = "//div[@id='unique_button2_id']";

        public Button SpecificButton1;
        public Button SpecificButton2;
        // Other objects representing various components, such as text fields, panels, drop-down lists etc. can be here.

        public ConcretePageExample(WebDriverWrapper driver) : base(driver)
        {
            SpecificButton1 = new Button(this, ButtonLocator1);
            SpecificButton2 = new Button(this, ButtonLocator2);
        }
    }
}
