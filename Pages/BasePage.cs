using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalExam3.BrowserFactory;

namespace PracticalExam3.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver WebDriver { get; }
        protected WebDriverWait WebDriverWait => new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));
        protected BasePage()
        {
            WebDriver = BrowserService.Browser.WebDriver;
        }
        protected IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);

        protected abstract By UniqueWebLocator { get; }

        private readonly string _baseUrl = AppConfigurations.BaseUrl;

        protected abstract string UrlPath { get; }
        
        public void OpenPage()
        {
            var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
            WebDriver.Navigate().GoToUrl(uri);
            WaitForPageLoad();
        }
        public bool IsPageOpened()
        {
            return WebDriver.FindElement(UniqueWebLocator).Displayed;
        }

        public void WaitForPageLoad()
        {
            try
            {
                WebDriverWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
            }
            catch (WebDriverTimeoutException e)
            {
                throw new AssertionException($"Page with unique locator: '{UniqueWebLocator}' was not opened", e);
            }
        }
    }
}
