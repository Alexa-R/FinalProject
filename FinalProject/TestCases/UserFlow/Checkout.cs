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
            var poNumber = "123456789";
            
            Pages.HomePage.AddItemToCart();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.WaitUntilOrderSummaryIsLoaded();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.InvoiceNumber);
            Pages.CheckoutPage.EnterPoNumber(poNumber);
            Pages.CheckoutPage.ClickPoNumberSubmitButton();
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }

        [Test]
        public void RegisteredUserWithVisaPayment()
        {
            Pages.HomePage.AddItemToCart();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.WaitUntilOrderSummaryIsLoaded();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }

        [Test]
        public void RegisteredUserCreatingShippingAddressOnCheckoutStep()
        {
            var nicknameForShipping = $"Nickname_{RandomHelper.GetRandomString(8)}";
            var companyNameForShipping = $"CompanyName_{RandomHelper.GetRandomString(8)}";
            var phoneNumberForShipping = $"PhoneNumber_{RandomHelper.GetRandomString(8)}";

            Pages.HomePage.AddItemToCart();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            Pages.CheckoutPage.AddNewAddress(nicknameForShipping, companyNameForShipping, phoneNumberForShipping);
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }
    }
}