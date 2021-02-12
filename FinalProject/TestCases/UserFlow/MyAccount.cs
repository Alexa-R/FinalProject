using FinalProject.Constants;
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
            
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(searchString);
            Pages.SearchResultPage.SelectBrandInFilterBar(PlpFilterBrandNamesConstants.Catwalk);
            Pages.SearchResultPage.WaitUntilThumbnailReload();
            Pages.SearchResultPage.ClickFirstActiveProductThumbnailAddToBagButton();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickViewBagButton();
            Pages.CartPage.ClickContinueToCheckout();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            Pages.CheckoutPage.AddNewShippingAddress();
            Pages.CheckoutPage.ClickChangeBillingAddressLink();
            Pages.CheckoutPage.AddNewBillingAddress();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
            Assert.True(Pages.CheckoutPage.IsOrderConfirmationContainerDisplayed());
        }
    }
}