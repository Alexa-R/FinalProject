using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.UserFlow
{
    public class Checkout : BaseTest
    {
        private string _nicknameForShipping;
        private string _companyNameForShipping;
        private string _phoneNumberForShipping;

        [Test]
        public void RegisteredUserWithPoNumberPaymentMethod()
        {
            var poNumber = "123456789";
            
            Pages.HomePage.AddItemToCart();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.WaitUntilOrderSummaryIsLoaded();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.InvoicePayment);
            Pages.CheckoutPage.EnterPoNumber(poNumber);
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
            _nicknameForShipping = $"Nickname{RandomHelper.GetRandomString(8)}";
            _companyNameForShipping = $"CompanyName{RandomHelper.GetRandomString(8)}";
            _phoneNumberForShipping = "1234567";

            Pages.HomePage.AddItemToCart();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            Pages.CheckoutPage.AddNewAddress(_nicknameForShipping, _companyNameForShipping, _phoneNumberForShipping);
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }
    }
}