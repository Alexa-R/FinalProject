using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.Lists;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.CheckoutAndOrderConfirmation
{
    [TestFixture]
    public class CheckoutPageOrderSummary : BaseTest
    {
        [Test]
        public void VerifyOrderSummaryDisplayIsCorrect()
        {
            LoginHelper.LoginAsUser();
            AddToCartHelper.AddItemToCartFromHomePage();
            Pages.BasePage.ClickBagButton();
            Pages.BasePage.ClickCheckoutButton();
            Pages.CheckoutPage.ClickChangeShippingAddressLink();
            CheckoutHelper.AddNewShippingAddress();
            Pages.CheckoutPage.ClickChangeBillingAddressLink();
            CheckoutHelper.AddNewBillingAddress();
            Pages.CheckoutPage.ClickPaymentMethodDropdownMenu();
            Pages.CheckoutPage.SelectPaymentMethodFromPaymentMethodDropdownList(PaymentMethodNamesConstants.VisaEndingIn1026);
            Pages.CheckoutPage.ClickShippingMethodDropdownMenu();
            Pages.CheckoutPage.SelectShippingMethodFromShippingMethodDropdownList(ShippingMethodNamesConstants.UpsGround);
            Pages.CheckoutPage.ClickMakeRecurringOrderButton();
            Assert.True(Pages.CheckoutPage.IsRecurringOrderModalDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderNameDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderStartDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderEndDisplayed());
            Assert.True(Pages.CheckoutPage.IsRecurringOrderFrequencyDropdownMenuDisplayed());

            Pages.CheckoutPage.ClickRecurringOrderFrequencyDropdownMenu();
            CollectionAssert.AreEqual(RecurringOrderLists.RecurringOrderFrequenciesTextList, Pages.CheckoutPage.GetRecurringOrderFrequencyDropdownMenuElementsText());

            Pages.CheckoutPage.SelectFrequencyFromFrequencyDropdownMenu(RecurringOrderFrequenciesNamesConstants.Weekly);
            Assert.True(Pages.CheckoutPage.AreRecurringOrderDaysOfWeekListElementsDisplayed());
            Assert.True(Pages.CheckoutPage.AreRecurringOrderWeeksOfMonthListElementsDisplayed());

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