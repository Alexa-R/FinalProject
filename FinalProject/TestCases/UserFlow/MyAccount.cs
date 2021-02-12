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
            var nicknameForShipping = $"Nickname_{RandomHelper.GetRandomString(8)}";
            var companyNameForShipping = $"CompanyName_{RandomHelper.GetRandomString(8)}";
            var phoneNumberForShipping = $"PhoneNumber_{RandomHelper.GetRandomString(8)}";
            var nicknameForBilling = $"Nickname_{RandomHelper.GetRandomString(8)}";
            var companyNameForBilling = $"CompanyName_{RandomHelper.GetRandomString(8)}";
            var phoneNumberForBilling = $"PhoneNumber_{RandomHelper.GetRandomString(8)}";

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