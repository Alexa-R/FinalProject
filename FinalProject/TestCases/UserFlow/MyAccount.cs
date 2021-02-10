using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.UserFlow
{
    [TestFixture]
    public class MyAccount : BaseTest
    {
        [Test]
        public void RegisteredUserAddsNewAddressFromCheckoutPageToShipWhenCompletingBuy()
        {
            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.SearchItemInSearchInputField("Shampoo");
            Pages.SearchResultPage.SelectBrandInFilterBar(PlpFilterBrandNamesConstants.Catwalk);
            Pages.SearchResultPage.WaitUntilThumbnailReload();
            Pages.SearchResultPage.ClickFirstActiveProductThumbnailAddToBagButton();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickViewBagButton();
            Pages.CartPage.ClickContinueToCheckout();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            CheckoutHelper.AddNewAddress();
            Pages.CheckoutPage.ClickChangeBillingAddressLink();
            CheckoutHelper.AddNewAddress();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdownList(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickPlaceOrderButton();
        }
    }
}