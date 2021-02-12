using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.UserFlow
{
    public class MyAccount : BaseTest
    {
        [Test]
        public void RegisteredUserAddsNewAddressFromCheckoutPageToShipWhenCompletingBuy()
        {
            var searchString = "Shampoo";
            var nicknameForShipping = $"Nickname{RandomHelper.GetRandomString(8)}";
            var companyNameForShipping = $"CompanyName{RandomHelper.GetRandomString(8)}";
            var phoneNumberForShipping = "1234567";
            var nicknameForBilling = $"Nickname{RandomHelper.GetRandomString(8)}";
            var companyNameForBilling = $"CompanyName{RandomHelper.GetRandomString(8)}";
            var phoneNumberForBilling = "7654321";

            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(searchString);
            Pages.SearchResultPage.SelectBrandInFilterBar(PlpFilterBrandNamesConstants.Catwalk);
            Pages.SearchResultPage.WaitUntilThumbnailReload();
            Pages.SearchResultPage.ClickFirstActiveProductThumbnailAddToBagButton();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickViewBagButton();
            Pages.CartPage.ClickContinueToCheckout();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            Pages.CheckoutPage.AddNewAddress(nicknameForShipping, companyNameForShipping, phoneNumberForShipping);
            Pages.CheckoutPage.ClickChangeBillingAddressLink();
            Pages.CheckoutPage.AddNewAddress(nicknameForBilling, companyNameForBilling, phoneNumberForBilling);
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }
    }
}