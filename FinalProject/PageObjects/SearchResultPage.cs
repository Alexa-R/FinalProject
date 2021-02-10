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
            new WrapperWebElement(By.XPath($"//*[@id='refinementNameDesktop{filterBrandName}']")).Click();
        }

        public string GetSortDropdownMenuText()
        {
            return SortDropdownMenu.Text;
        }

        public string GetSearchResultsLabelText()
        {
            return SearchResultsLabel.Text;
        }

        public void ClickFirstActiveProductThumbnailAddToBagButton()
        {
            FirstActiveProductThumbnailAddToBagButton.Click();
        }
        
        public void WaitUntilThumbnailReload()
        {
           WaitHelper.WaitUntilElementStaleness(Thumbnail);
        }
    }
}