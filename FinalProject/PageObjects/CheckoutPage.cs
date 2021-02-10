﻿using System.Collections.Generic;
using FinalProject.Helpers;
using FinalProject.Lists;
using FinalProject.WrapperElement;
using FinalProject.WrapperFactory;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class CheckoutPage
    {
        private WrapperWebElement PaymentMethodDropdownMenu => new WrapperWebElement(By.XPath("//g-fancy-dropdown[.//*[contains(text(),'Payment Method')]]"));
        private WrapperWebElement ShippingMethodDropdownMenu => new WrapperWebElement(By.XPath("//g-fancy-select[contains(@params,'ShippingMethod')]//button"));
        private WrapperWebElement PoNumberInputField => new WrapperWebElement(By.XPath("//*[@id='poNumber']"));
        private WrapperWebElement PoNumberSubmitButton => new WrapperWebElement(By.XPath("//button[text()='Submit']"));
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
        
        public void ClickPaymentMethodDropdownMenu()
        {
            PaymentMethodDropdownMenu.Click();
        }

        public void SelectPaymentMethodFromPaymentMethodDropdownList(string paymentMethodName)
        {
            new WrapperWebElement(By.XPath($"//g-fancy-dropdown[.//*[contains(text(),'Payment Method')]]//li[text()='{paymentMethodName}']")).Click();
        }

        public void ClickShippingMethodDropdownMenu()
        {
            ShippingMethodDropdownMenu.Click();
        }

        public void SelectShippingMethodFromShippingMethodDropdownList(string shippingMethodName)
        {
            new WrapperWebElement(By.XPath($"//g-fancy-select[contains(@params,'ShippingMethod')]//li[text()='{shippingMethodName}']")).Click();
        }

        public void EnterPoNumber(string pONumber)
        {
            PoNumberInputField.SendKeys(pONumber);
        }

        public void ClickPoNumberSubmitButton()
        {
            PoNumberSubmitButton.Click();
        }

        public void ClickPlaceOrderButton()
        {
            PlaceOrderButton.Click();
        }

        public void ClickChangeShippingAddressLink()
        {
            ChangeShippingAddressLink.Click();
        }

        public void ClickAddNewAddressButton()
        {
            AddNewAddressButton.Click();
        }

        public void EnterNickname(string nickname)
        {
            NicknameInputField.SendKeys(nickname);
        }

        public void EnterCompanyName(string companyName)
        {
            CompanyNameInputField.SendKeys(companyName);
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            PhoneNumberInputField.SendKeys(phoneNumber);
        }

        public void EnterFirstAddress(string firstAddress)
        {
            FirstAddressInputField.SendKeys(firstAddress);
        }

        public void EnterCity(string city)
        {
            CityInputField.SendKeys(city);
        }

        public void EnterZipCode(string zipCode)
        {
            ZipCodeInputField.SendKeys(zipCode);
        }

        public void EnterCounty(string county)
        {
            CountyInputField.SendKeys(county);
        }

        public void SelectCountryFromCountriesDropdownMenu(string countryValue)
        {
            new WrapperWebElement(By.XPath($"//*[@id='countryNew']/option[@value='{countryValue}']")).Click();
        }

        public void SelectStateFromStatesDropdownMenu(string stateValue)
        {
            new WrapperWebElement(By.XPath($"//*[@id='stateNew']/option[@value='{stateValue}']")).Click();
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public void ClickChangeBillingAddressLink()
        {
            ChangeBillingAddressLink.Click();
        }

        public bool IsOrderConfirmationContainerDisplayed()
        {
            return OrderConfirmationContainer.Displayed;
        }

        public void ClickMakeRecurringOrderButton()
        {
            MakeRecurringOrderButton.Click();
        }

        public bool IsRecurringOrderModalDisplayed()
        {
            WaitHelper.WaitUntilElementIsDisplayed(RecurringOrderModal);
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

        public void ClickRecurringOrderFrequencyDropdownMenu()
        {
            RecurringOrderFrequencyDropdownMenu.Click();
        }

        public IList<string> GetRecurringOrderFrequencyDropdownMenuElementsText()
        {
            var recurringOrderFrequencyDropdownMenuElementsList =  WebDriverFactory.Driver.FindElements(By.XPath("//*[@id='CC-scheduledOrder-scheduleMode']//option"));
            var recurringOrderFrequencyDropdownMenuElementsTextList = new List<string>();
            for (var i = 0; i < recurringOrderFrequencyDropdownMenuElementsList.Count; i++)
            {
                recurringOrderFrequencyDropdownMenuElementsTextList.Add(recurringOrderFrequencyDropdownMenuElementsList[i].Text);
            }

            return recurringOrderFrequencyDropdownMenuElementsTextList;
        }

        public void SelectFrequencyFromFrequencyDropdownMenu(string frequencyName)
        {
            new WrapperWebElement(By.XPath($"//*[@id='CC-scheduledOrder-scheduleMode']//option[text()='{frequencyName}']")).Click();
        }

        public bool AreRecurringOrderDaysOfWeekListElementsDisplayed()
        {
            bool isDisplayed = false;
            for (var i = 0; i < RecurringOrderLists.DaysOfWeekList.Count; i++)
            {
                isDisplayed = new WrapperWebElement(By.XPath($"//*[@class='form-group'][.//*[text()='Choose day(s) of week:']]//*[text()='{RecurringOrderLists.DaysOfWeekList[i]}']")).Displayed;
            }

            return isDisplayed;
        }

        public bool AreRecurringOrderWeeksOfMonthListElementsDisplayed()
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
    }
}