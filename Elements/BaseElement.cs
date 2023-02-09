using OpenQA.Selenium;
using PracticalExam3.BrowserFactory;

namespace PracticalExam3.Elements
{
    public abstract class BaseElement
    {
        protected By Locator { get; }

        protected BaseElement(By locator)
        {
            Locator = locator;
        }

        private WebDriver WebDriver
        {
            get { return BrowserService.Browser.WebDriver; }
        }


        public void Click()
        {
            FindElement().Click();
        }

        public string GetText()
        {
            return FindElement().Text;
        }

        public bool IsDisplayed()
        {
            return FindElement().Displayed;
        }

        protected IWebElement FindElement()
        {
            return WebDriver.FindElement(Locator);
        }
    }
}

