namespace SeleniumReference
{
    class Button : AbstractComponent
    {
        public Button(AbstractPage page, string locator) : base(page, locator)
        {
        }

        public Button(AbstractComponent component, string locator) : base(component, locator)
        {
        }

        // This is an example of a useful method in a specific Component.
        // The button's click method makes internal use of the WebDriverWrapper's click method.
        // This principle can be translated to other components types, for example inputting text into a text field.
        public void Click(int timeout = 10)
        {
            try
            {
                // It's important to report every action to difido (see DifidoReportsReference for examples).
                // A more specific report is possible (and recommended).
                Report.StartLevel("Clicking button");

                // Here we make use of the Locator from the base class (assigned and passed in the component's constructor).
                InnerDriver.Click(Locator, timeout);
            }
            finally
            {
                Report.EndLevel();
            }
        }
    }
}
