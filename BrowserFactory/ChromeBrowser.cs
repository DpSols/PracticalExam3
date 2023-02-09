using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace PracticalExam3.BrowserFactory
{
    public class ChromeBrowser : BrowserFactory
    {
        public ChromeBrowser(ChromeOptions chromeOptions) : base(chromeOptions)
        {
        }

        protected override WebDriver WebDriver
        {
            get
            {
                WebDriver webDriver;

                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                webDriver = new ChromeDriver(AppConfigurations.ChromeOptions);
                return webDriver;
            }
        }
    }
}
