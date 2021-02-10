using FinalProject.WrapperElement;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class CartPage
    {
        private WrapperWebElement ContinueToCheckout => new WrapperWebElement(By.XPath("//*[@aria-label='Continue to Checkout']"));

        public void ClickContinueToCheckout()
        {
            ContinueToCheckout.Click();
        }
    }
}