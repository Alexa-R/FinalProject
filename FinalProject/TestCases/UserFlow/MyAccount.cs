using System.Configuration;
using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.UserFlow
{
    public class MyAccount : BaseTest
    {
        private string _nicknameForShipping;
        private string _companyNameForShipping;
        private string _phoneNumberForShipping;
        private string _nicknameForBilling;
        private string _companyNameForBilling;
        private string _phoneNumberForBilling;

        [Test]
        public void RegisteredUserAddsNewAddressFromCheckoutPageToShipWhenCompletingBuy()
        {
            var searchString = "Shampoo";
            _nicknameForShipping = $"Nickname{RandomHelper.GetRandomString(8)}";
            _companyNameForShipping = $"CompanyName{RandomHelper.GetRandomString(8)}";
            _phoneNumberForShipping = "1234567";
            _nicknameForBilling = $"Nickname{RandomHelper.GetRandomString(8)}";
            _companyNameForBilling = $"CompanyName{RandomHelper.GetRandomString(8)}";
            _phoneNumberForBilling = "7654321";

            Pages.BasePage.CheckUserLoggedIn();
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(searchString);
            Pages.SearchResultPage.SelectBrandInFilterBar(PlpFilterBrandNamesConstants.Catwalk);
            Pages.SearchResultPage.WaitUntilThumbnailReload();
            Pages.SearchResultPage.ClickFirstActiveProductThumbnailAddToBagButton();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickViewBagButton();
            Pages.CartPage.ClickContinueToCheckout();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            Pages.CheckoutPage.AddNewAddress(_nicknameForShipping, _companyNameForShipping, _phoneNumberForShipping);
            Pages.CheckoutPage.ClickChangeBillingAddressLink();
            Pages.CheckoutPage.AddNewAddress(_nicknameForBilling, _companyNameForBilling, _phoneNumberForBilling);
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.ClickPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }
    }
}