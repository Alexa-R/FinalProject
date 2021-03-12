using FinalProject.Helpers;
using FinalProject.WrapperElement;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class SearchResultPage : BasePage
    {
        private WrapperWebElement SortDropdownMenu => new WrapperWebElement(By.XPath("//*[@class='sort-dropdwown-container']"));
        private WrapperWebElement FirstActiveProductThumbnailAddToBagButton => new WrapperWebElement(By.XPath("//*[@class='prod_thumbnail']//button[not(contains(@class,'disabled'))][.//*[text()='Add to bag']]"));
        private WrapperWebElement SearchResultsLabel => new WrapperWebElement(By.XPath("//*[contains(@class,'searchResults')]"));
        private WrapperWebElement Thumbnail => new WrapperWebElement(By.XPath("//*[@class='prod_thumbnail']"));

        public void SelectBrandInFilterBar(string filterBrandName)
        {
            LogHelper.Info($"Clicking on the {filterBrandName} brand In Filter Bar");
            new WrapperWebElement(By.XPath($"//*[@id='refinementNameDesktop{filterBrandName}']")).Click();
        }

        public string GetSortDropdownMenuText()
        {
            LogHelper.Info("Getting the Sort Dropdown Menu Text");
            return SortDropdownMenu.Text;
        }

        public string GetSearchResultsLabelText()
        {
            LogHelper.Info("Getting the Search Results Label");
            return SearchResultsLabel.Text;
        }

        public void ClickFirstActiveProductThumbnailAddToBagButton()
        {
            LogHelper.Info("Clicking on the Add To Bag Button of the First Active Product Thumbnail");
            FirstActiveProductThumbnailAddToBagButton.Click();
        }

        public void WaitUntilThumbnailReload()
        {
            LogHelper.Info("Reloading of the Thumbnail");
            Thumbnail.WaitForElementIsStale();
        }
    }
}