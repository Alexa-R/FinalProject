using System.Collections.Generic;
using System.Configuration;
using FinalProject.Helpers;
using FinalProject.Lists;
using FinalProject.WrapperElement;
using FinalProject.WrapperFactory;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class CheckoutPage : BasePage
    {
        private WrapperWebElement PaymentMethodDropdownMenu => new WrapperWebElement(By.XPath("//g-fancy-dropdown[.//*[contains(text(),'Payment Method')]]"));
        private WrapperWebElement PaymentMethodDropdownList => new WrapperWebElement(By.XPath("//g-fancy-dropdown[.//*[contains(text(),'Payment Method')]]//ul"));
        private WrapperWebElement ShippingMethodDropdownMenu => new WrapperWebElement(By.XPath("//g-fancy-select[contains(@params,'ShippingMethod')]//button"));
        private WrapperWebElement PoNumberInputField => new WrapperWebElement(By.XPath("//*[@id='poNumber']"));
        private WrapperWebElement PlaceOrderButton => new WrapperWebElement(By.XPath("//*[@aria-label='Place Order']"));
        private WrapperWebElement ChangeShippingAddressLink => new WrapperWebElement(By.XPath("//*[@id='shippingAddress']//*[@class='bold link_primary']"));
        private WrapperWebElement ChangeBillingAddressLink => new WrapperWebElement(By.XPath("//*[@id='billingAddress']//*[@class='bold link_primary']"));
        private WrapperWebElement AddNewAddressButton => new WrapperWebElement(By.XPath("//button[text()='Add a New Address']"));
        private WrapperWebElement NicknameInputField => new WrapperWebElement(By.XPath("//*[@id='nicknameNew']"));
        private WrapperWebElement CompanyNameInputField => new WrapperWebElement(By.XPath("//*[@id='companyNameNew']"));
        private WrapperWebElement PhoneNumberInputField => new WrapperWebElement(By.XPath("//*[@id='phoneNew']"));
        private WrapperWebElement FirstAddressInputField => new WrapperWebElement(By.XPath("//*[@id='address1New']"));
        private WrapperWebElement CityInputField => new WrapperWebElement(By.XPath("//*[@id='cityNew']"));
        private WrapperWebElement ZipCodeInputField => new WrapperWebElement(By.XPath("//*[@id='zipNew']"));
        private WrapperWebElement CountyInputField => new WrapperWebElement(By.XPath("//*[@id='countyNew']"));
        private WrapperWebElement SaveButton => new WrapperWebElement(By.XPath("//button[contains(@data-bind,'saveNewAddress')]"));
        private WrapperWebElement OrderConfirmationContainer => new WrapperWebElement(By.XPath("//*[@id='orderConfirmation']"));
        private WrapperWebElement MakeRecurringOrderButton => new WrapperWebElement(By.XPath("//button[contains(@class,'recurring')]"));
        private WrapperWebElement RecurringOrderModal => new WrapperWebElement(By.XPath("//*[@id='recurring-order']"));
        private WrapperWebElement RecurringOrderName => new WrapperWebElement(By.XPath("//*[@id='CC-checkoutScheduledOrder-sname']"));
        private WrapperWebElement RecurringOrderStart => new WrapperWebElement(By.XPath("//*[@id='CC-checkoutScheduledOrder-sstartdate']"));
        private WrapperWebElement RecurringOrderEnd => new WrapperWebElement(By.XPath("//*[@id='CC-checkoutScheduledOrder-senddatetype']"));
        private WrapperWebElement RecurringOrderFrequencyDropdownMenu => new WrapperWebElement(By.XPath("//*[@id='CC-scheduledOrder-scheduleMode']"));
        private WrapperWebElement RecurringOrderCancelButton => new WrapperWebElement(By.XPath("//*[@id='recurring-order']//*[@data-dismiss='modal']"));
        private WrapperWebElement CartSummaryTotalItemsText => new WrapperWebElement(By.XPath("//*[@class='cart-summary__total-items-text']"));
        private WrapperWebElement CartSummaryTotalQuantityText => new WrapperWebElement(By.XPath("//*[@class='cart-summary__total-qty-text']"));
        private WrapperWebElement EstimatedTotalOrderSummaryValue => new WrapperWebElement(By.XPath("//*[@class='cart-summary__value-row'][.//*[text()='Estimated Total']]//g-price"));

        public void ClickPaymentMethodDropdownMenu()
        {
            LogHelper.Info("Clicking on the Payment Method Dropdown Menu");
            PaymentMethodDropdownMenu.Click();

            if (PaymentMethodDropdownList.Displayed == false)
            {
                PaymentMethodDropdownMenu.Click();
            }
        }

        public void ClickPaymentMethodFromPaymentMethodDropdown(string paymentMethodName)
        {
            LogHelper.Info($"Clicking on the {paymentMethodName} from Payment Method Dropdown Menu");
            new WrapperWebElement(By.XPath($"//g-fancy-dropdown[.//*[contains(text(),'Payment Method')]]//li[text()='{paymentMethodName}']")).Click();
        }
        
        public void ClickShippingMethodDropdownMenu()
        {
            LogHelper.Info("Clicking on the Shipping Method Dropdown Menu");
            ShippingMethodDropdownMenu.Click();
        }

        public void ClickShippingMethodFromShippingMethodDropdown(string shippingMethodName)
        {
            LogHelper.Info($"Clicking on the {shippingMethodName} from Shipping Method Dropdown Menu");
            new WrapperWebElement(By.XPath($"//g-fancy-select[contains(@params,'ShippingMethod')]//li[text()='{shippingMethodName}']")).Click();
        }

        public void EnterPoNumber(string pONumber)
        {
            LogHelper.Info($"Entering of the PO number '{pONumber}'");
            PoNumberInputField.SendKeys(pONumber);
        }
        
        public void ClickPlaceOrderButton()
        {
            LogHelper.Info("Clicking on the Place Order Button");
            PlaceOrderButton.Click();
            WaitUntilPageIsLoaded();
        }

        public void ClickChangeShippingAddressLink()
        {
            LogHelper.Info("Clicking on the Change Shipping Address Link");
            ChangeShippingAddressLink.Click();

            if (AddNewAddressButton.Displayed == false)
            {
                ChangeShippingAddressLink.Click();
            }
        }

        public void ClickAddNewAddressButton()
        {
            LogHelper.Info("Clicking on the Add New Address Button");
            AddNewAddressButton.Click();

            if (NicknameInputField.Displayed == false)
            {
                AddNewAddressButton.Click();
            }
        }

        public void EnterNickname(string nickname)
        {
            LogHelper.Info($"Entering of the Nickname '{nickname}'");
            NicknameInputField.SendKeys(nickname);
        }

        public void EnterCompanyName(string companyName)
        {
            LogHelper.Info($"Entering of the Company Name '{companyName}'");
            CompanyNameInputField.SendKeys(companyName);
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            LogHelper.Info($"Entering of the Phone Number '{phoneNumber}'");
            PhoneNumberInputField.SendKeys(phoneNumber);
        }

        public void EnterFirstAddress(string firstAddress)
        {
            LogHelper.Info($"Entering of the First Address '{firstAddress}'");
            FirstAddressInputField.SendKeys(firstAddress);
        }

        public void EnterCity(string city)
        {
            LogHelper.Info($"Entering of the City '{city}'");
            CityInputField.SendKeys(city);
        }

        public void EnterZipCode(string zipCode)
        {
            LogHelper.Info($"Entering of the ZipCode '{zipCode}'");
            ZipCodeInputField.SendKeys(zipCode);
        }

        public void EnterCounty(string county)
        {
            LogHelper.Info($"Entering of the County '{county}'");
            CountyInputField.SendKeys(county);
        }

        public void ClickCountryFromCountriesDropdownMenu(string countryValue)
        {
            LogHelper.Info($"Clicking on the {countryValue} from Countries Dropdown Menu");
            new WrapperWebElement(By.XPath($"//*[@id='countryNew']/option[@value='{countryValue}']")).Click();
        }

        public void ClickStateFromStatesDropdownMenu(string stateValue)
        {
            LogHelper.Info($"Clicking on the {stateValue} from States Dropdown Menu");
            new WrapperWebElement(By.XPath($"//*[@id='stateNew']/option[@value='{stateValue}']")).Click();
        }

        public void ClickSaveButton()
        {
            LogHelper.Info("Clicking on the Save Button");
            SaveButton.Click();
            WaitUntilPageIsLoaded();
        }

        public void ClickChangeBillingAddressLink()
        {
            LogHelper.Info("Clicking on the Change Billing Address Link");
            ChangeBillingAddressLink.Click();
        }
        
        public bool IsOrderConfirmationContainerDisplayed()
        {
            LogHelper.Info("Checking the display of the Order Confirmation Container");
            return OrderConfirmationContainer.Displayed;
        }

        public void ClickMakeRecurringOrderButton()
        {
            LogHelper.Info("Clicking on the Make Recurring Order Button");
            MakeRecurringOrderButton.Click();

            if (RecurringOrderModal.Displayed == false)
            {
                MakeRecurringOrderButton.Click();
            }
        }

        public bool IsRecurringOrderModalDisplayed()
        {
            LogHelper.Info("Checking the display of the Recurring Order Modal");
            return RecurringOrderModal.Displayed;
        }

        public bool IsRecurringOrderNameDisplayed()
        {
            LogHelper.Info("Checking the display of the Recurring Order Name");
            return RecurringOrderName.Displayed;
        }

        public bool IsRecurringOrderStartDisplayed()
        {
            LogHelper.Info("Checking the display of the Recurring Order Start");
            return RecurringOrderStart.Displayed;
        }

        public bool IsRecurringOrderEndDisplayed()
        {
            LogHelper.Info("Checking the display of the Recurring Order End");
            return RecurringOrderEnd.Displayed;
        }

        public bool IsRecurringOrderFrequencyDropdownMenuDisplayed()
        {
            LogHelper.Info("Checking the display of the Recurring Order Frequency Dropdown Menu");
            return RecurringOrderFrequencyDropdownMenu.Displayed;
        }

        public void ClickRecurringOrderFrequencyDropdown()
        {
            LogHelper.Info("Clicking on the Recurring Order Frequency Dropdown Menu");
            RecurringOrderFrequencyDropdownMenu.Click();
        }

        public IList<string> GetRecurringOrderFrequencyDropdownElementsText()
        {
            LogHelper.Info("Getting the Recurring Order Frequency Dropdown Elements Text");
            var recurringOrderFrequencyDropdownMenuList =  WebDriverFactory.Driver.FindElements(By.XPath("//*[@id='CC-scheduledOrder-scheduleMode']//option"));
            var recurringOrderFrequencyDropdownMenuTextList = new List<string>();

            for (var i = 0; i < recurringOrderFrequencyDropdownMenuList.Count; i++)
            {
                recurringOrderFrequencyDropdownMenuTextList.Add(recurringOrderFrequencyDropdownMenuList[i].Text);
            }

            return recurringOrderFrequencyDropdownMenuTextList;
        }

        public void ClickFrequencyFromFrequencyDropdown(string frequencyName)
        {
            LogHelper.Info($"Clicking on the {frequencyName} from Frequency Dropdown Menu");
            new WrapperWebElement(By.XPath($"//*[@id='CC-scheduledOrder-scheduleMode']//option[text()='{frequencyName}']")).Click();
        }

        public bool AreRecurringOrderDaysOfWeekElementsDisplayed()
        {
            LogHelper.Info("Checking the display of the Recurring Order Days Of Week Elements");
            bool isDisplayed = false;

            for (var i = 0; i < RecurringOrderLists.DaysOfWeekList.Count; i++)
            {
                isDisplayed = new WrapperWebElement(By.XPath($"//*[@class='form-group'][.//*[text()='Choose day(s) of week:']]//*[text()='{RecurringOrderLists.DaysOfWeekList[i]}']")).Displayed;
            }

            return isDisplayed;
        }

        public bool AreRecurringOrderWeeksOfMonthElementsDisplayed()
        {
            LogHelper.Info("Checking the display of the Recurring Order Weeks Of Month");
            bool isDisplayed = false;

            for (var i = 0; i < RecurringOrderLists.WeeksOfMonthList.Count; i++)
            {
                isDisplayed = new WrapperWebElement(By.XPath($"//*[@class='form-group'][.//*[text()='Choose week(s) of month:']]//*[text()='{RecurringOrderLists.WeeksOfMonthList[i]}']")).Displayed;
            }

            return isDisplayed;
        }

        public void ClickRecurringOrderCancelButton()
        {
            LogHelper.Info("Clicking on the Recurring Order Cancel Button");
            RecurringOrderCancelButton.Click();
        }

        public bool IsCartSummaryTotalItemsTextDisplayed()
        {
            LogHelper.Info("Checking the display of the Cart Summary Total Items");
            return CartSummaryTotalItemsText.Displayed;
        }

        public bool IsCartSummaryTotalQuantityTextDisplayed()
        {
            LogHelper.Info("Checking the display of the Cart Summary Total Quantity");
            return CartSummaryTotalQuantityText.Displayed;
        }

        public bool IsOrderSummaryValueDisplayed(string valueName)
        {
            LogHelper.Info($"Checking the display of the Order Summary {valueName}");
            return new WrapperWebElement(By.XPath($"//*[@class='cart-summary__value-row'][.//*[text()='{valueName}']]//g-price")).Displayed;
        }

        public void WaitUntilOrderSummaryIsLoaded()
        {
            LogHelper.Info("Loading of the Order Summary");
            EstimatedTotalOrderSummaryValue.WaitForInvisibilityOfElementWithText(EstimatedTotalOrderSummaryValue.Text);
        }

        public void ClickAddressRadioButton(string nickname)
        {
            LogHelper.Info("Clicking on the Address Radio Button");
            new WrapperWebElement(By.XPath($"//*[@class='radiocheck_wrap'][.//*[text()='{nickname}']]//*[@class='fill']")).Click();
        }

        public void AddNewAddress(string nickname, string companyName, string phoneNumber)
        {
            ClickAddNewAddressButton();
            EnterNickname(nickname);
            EnterCompanyName(companyName);
            EnterPhoneNumber(phoneNumber);
            EnterFirstAddress(ConfigurationManager.AppSettings["Address1"]);
            ClickCountryFromCountriesDropdownMenu(ConfigurationManager.AppSettings["Country"]);
            ClickStateFromStatesDropdownMenu(ConfigurationManager.AppSettings["State"]);
            EnterCounty(ConfigurationManager.AppSettings["County"]);
            EnterCity(ConfigurationManager.AppSettings["City"]);
            EnterZipCode(ConfigurationManager.AppSettings["PostalCode"]);
            ClickSaveButton();
            ClickAddressRadioButton(nickname);
        }
    }
}