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
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.ClickShopMenuLink();
            Pages.BasePage.ClickSubcategoryInShopMenu(ShopMenuCategoriesConstants.HairCare, ShopMenuHairCareSubcategories.Shampoos);
            Assert.AreEqual("BEST SELLERS", Pages.SearchResultPage.GetSortDropdownMenuText());
        }
    }
}