namespace PracticalExam3.BrowserFactory
{
    public static class BrowserService
    {
        private static readonly ThreadLocal<Browser> BrowserContainer = new ThreadLocal<Browser>();

        private static readonly ThreadLocal<BrowserFactory> BrowserFactoryContainer = new ThreadLocal<BrowserFactory>();

        private static bool IsApplicationStarted() => BrowserContainer.IsValueCreated && BrowserContainer.Value.IsStarted;

        public static Browser Browser => GetBrowser();

        public static bool IsBrowserStarted => IsApplicationStarted();

        private static Browser GetBrowser()
        {
            if (!IsApplicationStarted())
            {
                BrowserContainer.Value = BrowserFactory.GetBrowser;
            }

            return BrowserContainer.Value;
        }

        private static BrowserFactory BrowserFactory
        {
            get
            {
                if (!BrowserFactoryContainer.IsValueCreated)
                {
                    SetDefaultFactory();
                }

                return BrowserFactoryContainer.Value;
            }
            set => BrowserFactoryContainer.Value = value;
        }

        private static void SetDefaultFactory()
        {
            BrowserFactory = new ChromeBrowser(AppConfigurations.ChromeOptions);
        }
    }
}
