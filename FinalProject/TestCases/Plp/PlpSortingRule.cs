using FinalProject.Constants.ShopMenuConstants;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Plp
{
    public class PlpSortingRule : BaseTest
    {
        [Test]
        public void DefaultSortOrderIsBestSeller()
        {
            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.ClickShopMenuLink();
            Pages.BasePage.ClickSubcategoryInShopMenu(ShopMenuCategoriesConstants.HairCare, ShopMenuHairCareSubcategories.Shampoos);
            Assert.AreEqual("BEST SELLERS", Pages.SearchResultPage.GetSortDropdownMenuText());
        }
    }
}