using OpenQA.Selenium;
using PracticalExam3.BrowserFactory;
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
        private By DropdownListOpenerLocator => By.ClassName("dropdown__opener");
        private By CheckBoxLocator => By.ClassName("checkbox");
        private By NextButtonLocator => By.XPath("//a[@class='button--secondary' and text()='Next']");
        private By AcceptCookiesLocator => By.XPath("//button[@class='button button--solid button--transparent']");
        private By TimerLocator => By.XPath("//*[@class='timer timer--white timer--center']");
        private By HideHelpLocator => By.XPath("//*[@class='align__cell u-right']");
        private By HelpFormHiddenLocator => By.XPath("//*[@class='help-form is-hidden']");

        private By DropdownListItemLocator(int index)
        {
            if (index is >= 1 and <= 10)
            {
                return By.XPath($"//div[@class='dropdown__list-item'][{index}]");
            }
            
            throw new ArgumentOutOfRangeException($"Index should be between 1 and 10, but was {index}");
        }

        private LabelElement PageIndicator => new LabelElement(PageIndicatorLocator);
        private LabelElement Timer => new LabelElement(TimerLocator);
        private LabelElement HelpFormHiddenIndicator => new LabelElement(HelpFormHiddenLocator);
        private InputElement PasswordField => new InputElement(PasswordFieldLocator);
        private InputElement EmailField => new InputElement(EmailFieldLocator);
        private InputElement DomainField => new InputElement(DomainFieldLocator);
        private ButtonElement DropdownListOpener => new ButtonElement(DropdownListOpenerLocator);
        private ButtonElement CheckBoxButton => new ButtonElement(CheckBoxLocator);
        private ButtonElement NextButton => new ButtonElement(NextButtonLocator);
        private ButtonElement AcceptCookiesButton => new ButtonElement(AcceptCookiesLocator);
        private ButtonElement HideHelpButton => new ButtonElement(HideHelpLocator);

        private void SelectDropDownEmailItem(int index)
        {
            DropdownListOpener.Click();
            new ButtonElement(DropdownListItemLocator(index)).Click();
        }

        public void HideHelpForm()
        {
            HideHelpButton.WaitForDisplayed();
            HideHelpButton.Click();
        }

        public bool IsHelpFormHidden
        {
            get
            {
                try
                {
                    return HelpFormHiddenIndicator.IsDisplayed();
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public void AcceptCookies()
        {
            AcceptCookiesButton.WaitForDisplayed();
            AcceptCookiesButton.Click();
        }
        
        public void SetPasswordField(string password)
        {
            PasswordField.Clear();
            PasswordField.Input(password);
        }

        public void SetEmailField(string email, string domain, int index)
        {
            EmailField.Clear();
            EmailField.Input(email);
            DomainField.Clear();
            DomainField.Input(domain);
            SelectDropDownEmailItem(index);
        }

        public void AcceptTermsAndConditions()
        {
            CheckBoxButton.Click();
        }

        public void ClickOnNextButton()
        {
            var currentCardNumber = CardNumber;
            NextButton.Click();
            BrowserService.Browser
                .WebDriverWait.Until(_ => !CardNumber.Contains(currentCardNumber));
        }

        public string CardNumber => PageIndicator.GetText();
        public string TimerStatus => Timer.GetText();
    }
}