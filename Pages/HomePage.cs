using OpenQA.Selenium;
using PracticalExam3.Elements;

namespace PracticalExam3.Pages
{
    public class HomePage : BasePage
    {

        protected override By UniqueWebLocator => ButtonToNextPageLocator;
        protected override string UrlPath => string.Empty;

        private By ButtonToNextPageLocator => By.ClassName("start__link");

        public BaseElement ButtonToNextPage => new ButtonElement(ButtonToNextPageLocator);
    }
}
