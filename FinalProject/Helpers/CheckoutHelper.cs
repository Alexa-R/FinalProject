using FinalProject.PageObjects;

namespace FinalProject.Helpers
{
    public static class CheckoutHelper
    {
        private static string companyName = "TestCompany";
        private static string phoneNumber = "1234567";
        private static string firstAddress = "77 Massachusetts Avenue";
        private static string countryValue = "US";
        private static string stateValue = "MA";
        private static string county = "Middlesex";
        private static string city = "Cambridge";
        private static string zipCode = "02139";

        public static void AddNewShippingAddress()
        { 
            var nickname = RandomHelper.GetRandomString(12); 
            Pages.CheckoutPage.ClickAddNewAddressButton();
            Pages.CheckoutPage.EnterNickname(nickname);
            Pages.CheckoutPage.EnterCompanyName(companyName);
            Pages.CheckoutPage.EnterPhoneNumber(phoneNumber);
            Pages.CheckoutPage.EnterFirstAddress(firstAddress);
            Pages.CheckoutPage.SelectCountryFromCountriesDropdownMenu(countryValue);
            Pages.CheckoutPage.SelectStateFromStatesDropdownMenu(stateValue);
            Pages.CheckoutPage.EnterCounty(county);
            Pages.CheckoutPage.EnterCity(city);
            Pages.CheckoutPage.EnterZipCode(zipCode);
            Pages.CheckoutPage.ClickSaveButton();
            Pages.CheckoutPage.ClickAddressRadioButton(nickname);
        }

        public static void AddNewBillingAddress()
        {
            var nickname = RandomHelper.GetRandomString(12);
            Pages.CheckoutPage.ClickAddNewAddressButton();
            Pages.CheckoutPage.EnterNickname(nickname);
            Pages.CheckoutPage.EnterCompanyName(companyName);
            Pages.CheckoutPage.EnterPhoneNumber(phoneNumber);
            Pages.CheckoutPage.EnterFirstAddress(firstAddress);
            Pages.CheckoutPage.SelectCountryFromCountriesDropdownMenu(countryValue);
            Pages.CheckoutPage.SelectStateFromStatesDropdownMenu(stateValue);
            Pages.CheckoutPage.EnterCounty(county);
            Pages.CheckoutPage.EnterCity(city);
            Pages.CheckoutPage.EnterZipCode(zipCode);
            Pages.CheckoutPage.ClickSaveButton();
            Pages.CheckoutPage.ClickAddressRadioButton(nickname);
        }
    }
}