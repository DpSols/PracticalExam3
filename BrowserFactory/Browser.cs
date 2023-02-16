using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalExam3.BrowserFactory
{
    public class Browser
    {
        public WebDriver WebDriver { get; }
        public WebDriverWait WebDriverWait { get; }

        public Browser(WebDriver webDriver)
        {
            WebDriver = webDriver;
            WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            MaximizeWindow();
            SetImplicitTime();
        }

        public void GoToUrl(Uri uri)
        {
            GoToUrl(uri.ToString());
        }

        public void GoToUrl(string uri)
        {
            WebDriver.Navigate().GoToUrl(uri);
        }

        public void Quit()
        {
            WebDriver.Quit();
        }

        private void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }

        private void SetImplicitTime()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public bool IsStarted => WebDriver.SessionId != null;
    }
}
