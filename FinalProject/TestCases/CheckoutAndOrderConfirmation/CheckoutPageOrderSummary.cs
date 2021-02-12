using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.Lists;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.CheckoutAndOrderConfirmation
{
    public class CheckoutPageOrderSummary : BaseTest
    {
        [Test]
        public void VerifyOrderSummaryDisplayIsCorrect()
        {
            var nicknameForShipping = $"Nickname_{RandomHelper.GetRandomString(8)}";
            var companyNameForShipping = $"CompanyName_{RandomHelper.GetRandomString(8)}";
            var phoneNumberForShipping = $"PhoneNumber_{RandomHelper.GetRandomString(8)}";
            var nicknameForBilling = $"Nickname_{RandomHelper.GetRandomString(8)}";
            var companyNameForBilling = $"CompanyName_{RandomHelper.GetRandomString(8)}";
            var phoneNumberForBilling = $"PhoneNumber_{RandomHelper.GetRandomString(8)}";

            Pages.HomePage.AddItemToCart();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            Pages.CheckoutPage.AddNewAddress(nicknameForShipping, companyNameForShipping, phoneNumberForShipping);
            Pages.CheckoutPage.ClickChangeBillingAddressLink();
            Pages.CheckoutPage.AddNewAddress(nicknameForBilling, companyNameForBilling, phoneNumberForBilling);
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdown(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickShippingMethodDropdownMenu();
            Pages.CheckoutPage.SelectShippingMethodFromShippingMethodDropdown(ShippingMethodNamesConstants.UpsGround);
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