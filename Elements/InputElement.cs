using OpenQA.Selenium;

namespace PracticalExam3.Elements
{
    public class InputElement : BaseElement
    {
        public InputElement(By locator) : base(locator)
        {
        }
        public void Input(string text)
        {
            FindElement().SendKeys(text);
        }

        public void Clear()
        {
            FindElement().Clear();
        }
    }
}
