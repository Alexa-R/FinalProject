using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.UserFlow
{
    public class Checkout : BaseTest
    {
        [Test]
        public void RegisteredUserWithPoNumberPaymentMethod()
        {
            LoginHelper.LoginAsUser();
            AddToCartHelper.AddItemToCartFromHomePage();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.WaitUntilOrderSummarySectionIsLoaded();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdownList(PaymentMethodNamesConstants.InvoiceNumber);
            Pages.CheckoutPage.EnterPoNumber("123456789");
            Pages.CheckoutPage.ClickPoNumberSubmitButton();
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }

        [Test]
        public void RegisteredUserWithVisaPayment()
        {
            LoginHelper.LoginAsUser();
            AddToCartHelper.AddItemToCartFromHomePage();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.WaitUntilOrderSummarySectionIsLoaded();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdownList(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }

        [Test]
        public void RegisteredUserCreatingShippingAddressOnCheckoutStep()
        {
            LoginHelper.LoginAsUser();
            AddToCartHelper.AddItemToCartFromHomePage();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            CheckoutHelper.AddNewShippingAddress();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdownList(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }
    }
}