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
            PaymentMethodDropdownMenu.Click();

            if (PaymentMethodDropdownList.Displayed == false)
            {
                PaymentMethodDropdownMenu.Click();
            }

            LogHelper.Info("Payment Method Dropdown Menu is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Payment Method Dropdown Menu is clicked");
        }

        public void SelectPaymentMethodFromPaymentMethodDropdown(string paymentMethodName)
        {
            new WrapperWebElement(By.XPath($"//g-fancy-dropdown[.//*[contains(text(),'Payment Method')]]//li[text()='{paymentMethodName}']")).Click();
            LogHelper.Info($"{paymentMethodName} from Payment Method Dropdown Menu is selected");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{paymentMethodName} from Payment Method Dropdown Menu is selected");
        }

        public void ClickShippingMethodDropdownMenu()
        {
            ShippingMethodDropdownMenu.Click();
            LogHelper.Info("Shipping Method Dropdown Menu is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Shipping Method Dropdown Menu is clicked");
        }

        public void SelectShippingMethodFromShippingMethodDropdown(string shippingMethodName)
        {
            new WrapperWebElement(By.XPath($"//g-fancy-select[contains(@params,'ShippingMethod')]//li[text()='{shippingMethodName}']")).Click();
            LogHelper.Info($"{shippingMethodName} from Shipping Method Dropdown Menu is selected");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{shippingMethodName} from Shipping Method Dropdown Menu is selected");
        }

        public void EnterPoNumber(string pONumber)
        {
            PoNumberInputField.SendKeys(pONumber);
            LogHelper.Info("PO number is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("PO number is entered");
        }
        
        public void ClickPlaceOrderButton()
        {
            PlaceOrderButton.Click();
            WaitUntilPageIsLoaded();
            LogHelper.Info("Place Order Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Place Order Button is clicked");
        }

        public void ClickChangeShippingAddressLink()
        {
            ChangeShippingAddressLink.Click();

            if (AddNewAddressButton.Displayed == false)
            {
                ChangeShippingAddressLink.Click();
            }

            LogHelper.Info("Change Shipping Address Link is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Change Shipping Address Link is clicked");
        }

        public void ClickAddNewAddressButton()
        {
            AddNewAddressButton.Click();

            if (NicknameInputField.Displayed == false)
            {
                AddNewAddressButton.Click();
            }

            LogHelper.Info("Add New Address Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Add New Address Button is clicked");
        }

        public void EnterNickname(string nickname)
        {
            NicknameInputField.SendKeys(nickname);
            LogHelper.Info("Nickname is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Nickname is entered");
        }

        public void EnterCompanyName(string companyName)
        {
            CompanyNameInputField.SendKeys(companyName);
            LogHelper.Info("Company Name is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Company Name is entered");
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            PhoneNumberInputField.SendKeys(phoneNumber);
            LogHelper.Info("Phone Number is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Phone Number is entered");
        }

        public void EnterFirstAddress(string firstAddress)
        {
            FirstAddressInputField.SendKeys(firstAddress);
            LogHelper.Info("First Address is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("First Address is entered");
        }

        public void EnterCity(string city)
        {
            CityInputField.SendKeys(city);
            LogHelper.Info("City is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("City is entered");
        }

        public void EnterZipCode(string zipCode)
        {
            ZipCodeInputField.SendKeys(zipCode);
            LogHelper.Info("ZipCode is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("ZipCode is entered");
        }

        public void EnterCounty(string county)
        {
            CountyInputField.SendKeys(county);
            LogHelper.Info("County is entered");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("County is entered");
        }

        public void SelectCountryFromCountriesDropdownMenu(string countryValue)
        {
            new WrapperWebElement(By.XPath($"//*[@id='countryNew']/option[@value='{countryValue}']")).Click();
            LogHelper.Info($"{countryValue} from Countries Dropdown Menu is selected");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{countryValue} from Countries Dropdown Menu is selected");
        }

        public void SelectStateFromStatesDropdownMenu(string stateValue)
        {
            new WrapperWebElement(By.XPath($"//*[@id='stateNew']/option[@value='{stateValue}']")).Click();
            LogHelper.Info($"{stateValue} from States Dropdown Menu is selected");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{stateValue} from States Dropdown Menu is selected");
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
            WaitUntilPageIsLoaded();
            LogHelper.Info("Save Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Save Button is clicked");
        }

        public void ClickChangeBillingAddressLink()
        {
            ChangeBillingAddressLink.Click();
            LogHelper.Info("Change Billing Address Link is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Change Billing Address Link is clicked");
        }

        public bool IsOrderConfirmationContainerDisplayed()
        {
            return OrderConfirmationContainer.Displayed;
        }

        public void ClickMakeRecurringOrderButton()
        {
            MakeRecurringOrderButton.Click();

            if (RecurringOrderModal.Displayed == false)
            {
                MakeRecurringOrderButton.Click();
            }

            LogHelper.Info("Make Recurring Order Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Make Recurring Order Button is clicked");
        }

        public bool IsRecurringOrderModalDisplayed()
        {
            return RecurringOrderModal.Displayed;
        }

        public bool IsRecurringOrderNameDisplayed()
        {
            return RecurringOrderName.Displayed;
        }

        public bool IsRecurringOrderStartDisplayed()
        {
            return RecurringOrderStart.Displayed;
        }

        public bool IsRecurringOrderEndDisplayed()
        {
            return RecurringOrderEnd.Displayed;
        }

        public bool IsRecurringOrderFrequencyDropdownMenuDisplayed()
        {
            return RecurringOrderFrequencyDropdownMenu.Displayed;
        }

        public void ClickRecurringOrderFrequencyDropdown()
        {
            RecurringOrderFrequencyDropdownMenu.Click();
            LogHelper.Info("Recurring Order Frequency Dropdown Menu is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Recurring Order Frequency Dropdown Menu is clicked");
        }

        public IList<string> GetRecurringOrderFrequencyDropdownElementsText()
        {
            var recurringOrderFrequencyDropdownMenuList =  WebDriverFactory.Driver.FindElements(By.XPath("//*[@id='CC-scheduledOrder-scheduleMode']//option"));
            var recurringOrderFrequencyDropdownMenuTextList = new List<string>();

            for (var i = 0; i < recurringOrderFrequencyDropdownMenuList.Count; i++)
            {
                recurringOrderFrequencyDropdownMenuTextList.Add(recurringOrderFrequencyDropdownMenuList[i].Text);
            }

            return recurringOrderFrequencyDropdownMenuTextList;
        }

        public void SelectFrequencyFromFrequencyDropdown(string frequencyName)
        {
            new WrapperWebElement(By.XPath($"//*[@id='CC-scheduledOrder-scheduleMode']//option[text()='{frequencyName}']")).Click();
            LogHelper.Info($"{frequencyName} from Frequency Dropdown Menu is selected");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{frequencyName} from Frequency Dropdown Menu is selected");
        }

        public bool AreRecurringOrderDaysOfWeekElementsDisplayed()
        {
            bool isDisplayed = false;

            for (var i = 0; i < RecurringOrderLists.DaysOfWeekList.Count; i++)
            {
                isDisplayed = new WrapperWebElement(By.XPath($"//*[@class='form-group'][.//*[text()='Choose day(s) of week:']]//*[text()='{RecurringOrderLists.DaysOfWeekList[i]}']")).Displayed;
            }

            return isDisplayed;
        }

        public bool AreRecurringOrderWeeksOfMonthElementsDisplayed()
        {
            bool isDisplayed = false;

            for (var i = 0; i < RecurringOrderLists.WeeksOfMonthList.Count; i++)
            {
                isDisplayed = new WrapperWebElement(By.XPath($"//*[@class='form-group'][.//*[text()='Choose week(s) of month:']]//*[text()='{RecurringOrderLists.WeeksOfMonthList[i]}']")).Displayed;
            }

            return isDisplayed;
        }

        public void ClickRecurringOrderCancelButton()
        {
            RecurringOrderCancelButton.Click();
            LogHelper.Info("Recurring Order Cancel Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Recurring Order Cancel Button is clicked");
        }

        public bool IsCartSummaryTotalItemsTextDisplayed()
        {
            return CartSummaryTotalItemsText.Displayed;
        }

        public bool IsCartSummaryTotalQuantityTextDisplayed()
        {
            return CartSummaryTotalQuantityText.Displayed;
        }

        public bool IsOrderSummaryValueDisplayed(string valueName)
        {
            return new WrapperWebElement(By.XPath($"//*[@class='cart-summary__value-row'][.//*[text()='{valueName}']]//g-price")).Displayed;
        }

        public void WaitUntilOrderSummaryIsLoaded()
        {
            EstimatedTotalOrderSummaryValue.WaitForInvisibilityOfElementWithText(EstimatedTotalOrderSummaryValue.Text);
            LogHelper.Info("Order Summary is loaded");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Order Summary is loaded");
        }

        public void ClickAddressRadioButton(string nickname)
        {
            new WrapperWebElement(By.XPath($"//*[@class='radiocheck_wrap'][.//*[text()='{nickname}']]//*[@class='fill']")).Click();
            LogHelper.Info("Address Radio Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Address Radio Button is clicked");
        }

        public void AddNewAddress(string nickname, string companyName, string phoneNumber)
        {
            ClickAddNewAddressButton();
            EnterNickname(nickname);
            EnterCompanyName(companyName);
            EnterPhoneNumber(phoneNumber);
            EnterFirstAddress(ConfigurationManager.AppSettings["Address1"]);
            SelectCountryFromCountriesDropdownMenu(ConfigurationManager.AppSettings["Country"]);
            SelectStateFromStatesDropdownMenu(ConfigurationManager.AppSettings["State"]);
            EnterCounty(ConfigurationManager.AppSettings["County"]);
            EnterCity(ConfigurationManager.AppSettings["City"]);
            EnterZipCode(ConfigurationManager.AppSettings["PostalCode"]);
            ClickSaveButton();
            ClickAddressRadioButton(nickname);
        }
    }
}