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
            ContinueToCheckout.Click();
            WaitUntilPageIsLoaded();
            LogHelper.Info("Continue To Checkout is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Continue To Checkout is clicked");
        }
    }
}