using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.Lists;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.CheckoutAndOrderConfirmation
{
    public class CheckoutPageOrderSummary : BaseTest
    {
        private string _nicknameForShipping;
        private string _companyNameForShipping;
        private string _phoneNumberForShipping;
        private string _nicknameForBilling;
        private string _companyNameForBilling;
        private string _phoneNumberForBilling;

        [Test]
        public void VerifyOrderSummaryDisplayIsCorrect()
        {
            _nicknameForShipping = $"Nickname{RandomHelper.GetRandomString(8)}";
            _companyNameForShipping = $"CompanyName{RandomHelper.GetRandomString(8)}";
            _phoneNumberForShipping = "1234567";
            _nicknameForBilling = $"Nickname{RandomHelper.GetRandomString(8)}";
            _companyNameForBilling = $"CompanyName{RandomHelper.GetRandomString(8)}";
            _phoneNumberForBilling = "7654321";

            Pages.HomePage.AddItemToCart();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            Pages.CheckoutPage.AddNewAddress(_nicknameForShipping, _companyNameForShipping, _phoneNumberForShipping);
            Pages.CheckoutPage.ClickChangeBillingAddressLink();
            Pages.CheckoutPage.AddNewAddress(_nicknameForBilling, _companyNameForBilling, _phoneNumberForBilling);
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickShippingMethodDropdownMenu();
            Pages.CheckoutPage.SelectShippingMethodFromShippingMethodDropdown(ShippingMethodNamesConstants.GroundUs);
            Pages.CheckoutPage.ClickMakeRecurringOrderButton();
            Assert.True(Pages.CheckoutPage.IsRecurringOrderModalDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderNameDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderStartDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderEndDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderFrequencyDropdownMenuDisplayed());

            Pages.CheckoutPage.ClickRecurringOrderFrequencyDropdown();
            CollectionAssert.AreEqual(RecurringOrderLists.RecurringOrderFrequenciesTextList, Pages.CheckoutPage.GetRecurringOrderFrequencyDropdownElementsText());

            Pages.CheckoutPage.SelectFrequencyFromFrequencyDropdown(RecurringOrderFrequenciesNamesConstants.Weekly);
            Assert.True(Pages.CheckoutPage.AreRecurringOrderDaysOfWeekElementsDisplayed());
            Assert.True(Pages.CheckoutPage.AreRecurringOrderWeeksOfMonthElementsDisplayed());

            Pages.CheckoutPage.ClickRecurringOrderCancelButton();
            Assert.True(Pages.CheckoutPage.IsCartSummaryTotalItemsTextDisplayed());
            Assert.True(Pages.CheckoutPage.IsCartSummaryTotalQuantityTextDisplayed());
            Assert.True(Pages.CheckoutPage.IsOrderSummaryValueDisplayed(OrderSummaryValuesConstants.SalonPrice));
            Assert.True(Pages.CheckoutPage.IsOrderSummaryValueDisplayed(OrderSummaryValuesConstants.YourPrice));
            Assert.True(Pages.CheckoutPage.IsOrderSummaryValueDisplayed(OrderSummaryValuesConstants.SalesTax));
            Assert.True(Pages.CheckoutPage.IsOrderSummaryValueDisplayed(OrderSummaryValuesConstants.Shipping));
        }
    }
}