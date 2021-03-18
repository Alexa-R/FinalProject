using System.Configuration;
using FinalProject.Constants.ShopMenuConstants;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Plp
{
    public class PlpSortingRule : BaseTest
    {
        [Test]
        public void DefaultSortOrderIsBestSeller()
        {
            Pages.BasePage.CheckUserLoggedIn();
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.ClickShopMenuLink();
            Pages.BasePage.ClickSubcategoryInShopMenu(ShopMenuCategoriesConstants.HairCare, ShopMenuHairCareSubcategories.Shampoos);
            Assert.AreEqual("BEST SELLERS", Pages.SearchResultPage.GetSortDropdownMenuText());
        }
    }
}