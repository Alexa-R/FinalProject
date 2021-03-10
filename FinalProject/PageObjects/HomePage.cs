using FinalProject.Helpers;
using FinalProject.WrapperElement;
using FinalProject.WrapperFactory;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class HomePage : BasePage
    {
        private WrapperWebElement FirstActiveRecommendProductThumbnailAddToBagButton => new WrapperWebElement(By.XPath("//*[contains(@class,'prod_thumbnail')]//button[not(contains(@class,'disabled'))][.//*[text()='Add to bag']]"));
        private WrapperWebElement RecommendationsCarousel => new WrapperWebElement(By.XPath("//*[@id='wi2100088-oc3-recommendations-carousel-id']"));
        
        public void WaitUntilHomePageIsLoaded()
        {
            try
            {
                RecommendationsCarousel.WaitForElementIsDisplayed();
            }
            catch (WebDriverTimeoutException)
            {
                WebDriverFactory.Driver.Navigate().Refresh();
                RecommendationsCarousel.WaitForElementIsDisplayed();
            }

            LogHelper.Info("HomePage is loaded");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("HomePage is loaded");
        }

        public void ClickFirstActiveRecommendProductThumbnailAddToBagButton()
        {
            FirstActiveRecommendProductThumbnailAddToBagButton.Click();
            WaitUntilPageIsLoaded();
            LogHelper.Info("Add To Bag Button of the First Active Recommendation Product Thumbnail is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Add To Bag Button of the First Active Recommendation Product Thumbnail is clicked");
        }

        public void AddItemToCart()
        {
            WaitUntilHomePageIsLoaded();
            ClickFirstActiveRecommendProductThumbnailAddToBagButton();
            LogHelper.Info("Item is added to cart");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Item is added to cart");
        }
    }
}