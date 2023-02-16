using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        private WebDriver WebDriver => BrowserService.Browser.WebDriver;
        private WebDriverWait WebDriverWait => BrowserService.Browser.WebDriverWait;


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

        public void WaitForDisplayed()
        {
            WebDriverWait.Until(_ => IsDisplayed());
        }
        
        protected IWebElement FindElement()
        {
            return WebDriver.FindElement(Locator);
        }
    }
}

