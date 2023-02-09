using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using PracticalExam3.Utilities;

namespace PracticalExam3
{
    internal static class AppConfigurations
    {
        public static ChromeOptions ChromeOptions
        {
            get
            {
                string[] chromeOptions = Configurator.Configuration.GetSection("ChromeOptions").Get<string[]>();
                var settings = new ChromeOptions();
                settings.AddArguments(chromeOptions);
                return settings;
            }
        }

        public static string BaseUrl => Configurator.Configuration.GetValue<string>("Url");
    }
}
