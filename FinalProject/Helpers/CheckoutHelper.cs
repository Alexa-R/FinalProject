using FinalProject.PageObjects;

namespace FinalProject.Helpers
{
    public static class CheckoutHelper
    {
        public static void AddNewAddress()
        {
            Pages.CheckoutPage.ClickAddNewAddressButton();
            Pages.CheckoutPage.EnterNickname("JaneSmith");
            Pages.CheckoutPage.EnterCompanyName("Company");
            Pages.CheckoutPage.EnterPhoneNumber("1234567");
            Pages.CheckoutPage.EnterFirstAddress("77 Massachusetts Avenue");
            Pages.CheckoutPage.SelectCountryFromCountriesDropdownMenu("US");
            Pages.CheckoutPage.SelectStateFromStatesDropdownMenu("MA");
            Pages.CheckoutPage.EnterCounty("Middlesex");
            Pages.CheckoutPage.EnterCity("Cambridge");
            Pages.CheckoutPage.EnterZipCode("02139");
            Pages.CheckoutPage.ClickSaveButton();
        }
    }
}