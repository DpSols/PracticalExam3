using NUnit.Framework;
using OpenQA.Selenium;
using PracticalExam3.Utilities;

namespace PracticalExam3.Tests
{
    [TestFixture]
    public class UserInterfaceTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            HomePage.OpenPage();
            Assert.That(HomePage.IsPageOpened, Is.True);
            
            HomePage.GoToNextStep();
            Assert.That(CardPage.CardNumber, Is.EqualTo("1 / 4"));

            var randomPassword = RandomGenerator.GetString(15).ToUpper();
            var randomEmail = RandomGenerator.GetString(10).ToLower();
            var randomDomain = RandomGenerator.GetString(5).ToLower();
            var randomTopDomain = RandomGenerator.GetInt(1, 10);
            
            CardPage.SetPasswordField(randomPassword);
            CardPage.SetEmailField(randomEmail, randomDomain, randomTopDomain);
            CardPage.AcceptTermsAndConditions();
            CardPage.ClickOnNextButton();
            Assert.That(CardPage.CardNumber, Is.EqualTo("2 / 4"));
        }

        [Test]
        public void Test2()
        {
            CardPage.OpenPage();
            Assert.That(CardPage.IsPageOpened, Is.True);
            
            CardPage.AcceptCookies();
            Assert.Throws<WebDriverTimeoutException>(CardPage.AcceptCookies);
        }

        [Test]
        public void Test3()
        {
            CardPage.OpenPage();
            Assert.That(CardPage.IsPageOpened, Is.True);
            Assert.That(CardPage.TimerStatus, Is.EqualTo("00:00:00"));
        }

        [Test]
        public void Test4()
        {
            CardPage.OpenPage();
            Assert.That(CardPage.IsPageOpened, Is.True);
            
            CardPage.HideHelpForm();
            Assert.That(CardPage.IsHelpFormHidden, Is.True);
        }
    }
}
