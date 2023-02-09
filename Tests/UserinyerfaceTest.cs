using NUnit.Framework;
using PracticalExam3.Utilities;

namespace PracticalExam3.Tests
{
    [TestFixture]
    public class UserinyerfaceTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            HomePage.OpenPage();
            HomePage.ButtonToNextPage.Click();
            Assert.That(CardPage.CardNumber, Is.EqualTo("1 / 4"));

            CardPage.PasswordField.Clear();
            CardPage.PasswordField.Input(RandomTextGenerator.GetString(15).ToUpper());
            CardPage.EmailField.Clear();
            CardPage.EmailField.Input(RandomTextGenerator.GetString(10).ToLower());
            CardPage.DomainField.Clear();
            CardPage.DomainField.Input("mail");
            CardPage.DropdownListItem.Click();
            CardPage.
        }
    }
}
