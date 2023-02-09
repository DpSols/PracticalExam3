using OpenQA.Selenium;
using PracticalExam3.Elements;

namespace PracticalExam3.Pages
{
    public class CardPage : BasePage
    {
        protected override By UniqueWebLocator => PageIndicatorLocator;
        protected override string UrlPath => "/game.html";

        private By PageIndicatorLocator => By.ClassName("page-indicator");
        private By PasswordFieldLocator => By.XPath("//input[@placeholder='Choose Password']");
        private By EmailFieldLocator => By.XPath("//input[@placeholder='Your email']");
        private By DomainFieldLocator => By.XPath("//input[@placeholder='Domain']");
        private By DropdownFieldButtonLocator => By.ClassName("dropdown__field");
        private By DropdownListItemLocator => By.ClassName("dropdown__list-item");
        private By CheckBoxLocator => By.ClassName("checkbox__box");
        private By NextButtonLocator => By.XPath("//a[@class='button--secondary' and text()='Next']");

        public LabelElement PageIndicator => new LabelElement(PageIndicatorLocator);
        public InputElement PasswordField => new InputElement(PasswordFieldLocator);
        public InputElement EmailField => new InputElement(EmailFieldLocator);
        public InputElement DomainField => new InputElement(DomainFieldLocator);
        public ButtonElement DropdownFieldButton => new ButtonElement(DropdownFieldButtonLocator);
        public ButtonElement DropdownListItem => new ButtonElement(DropdownListItemLocator); // just the first of them
        public ButtonElement CheckBoxButton => new ButtonElement(CheckBoxLocator);

        public string CardNumber => PageIndicator.GetText();
    }
}
