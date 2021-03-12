using FinalProject.Helpers;
using FinalProject.WrapperElement;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class CartPage : BasePage
    {
        private WrapperWebElement ContinueToCheckout => new WrapperWebElement(By.XPath("//*[@aria-label='Continue to Checkout']"));

        public void ClickContinueToCheckout()
        {
            LogHelper.Info("Clicking on the Continue To Checkout");
            ContinueToCheckout.Click();
            WaitUntilPageIsLoaded();
        }
    }
}