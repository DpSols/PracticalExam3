using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PracticalExam3.BrowserFactory
{
    public abstract class BrowserFactory
    {
        public ChromeOptions ChromeOptions { get; } // for now it is only works with chrome
        // TODO implement general browser options class

        protected BrowserFactory(ChromeOptions chromeOptions)
        {
            ChromeOptions = chromeOptions;
        }

        public Browser GetBrowser => new Browser(WebDriver);

        protected abstract WebDriver WebDriver { get; }
    }
}
