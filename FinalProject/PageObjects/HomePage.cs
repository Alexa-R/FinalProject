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
            LogHelper.Info("Loading of the Home Page");
            while (true)
            {
                try
                {
                    RecommendationsCarousel.WaitForElementIsDisplayed();
                }
                catch (WebDriverTimeoutException)
                {
                    WebDriverFactory.Driver.Navigate().Refresh();
                    RecommendationsCarousel.WaitForElementIsDisplayed();
                    continue;
                }
                break;
            }
        }

        public void ClickFirstActiveRecommendProductThumbnailAddToBagButton()
        {
            LogHelper.Info("Clicking on the Add To Bag Button of the First Active Recommendation Product Thumbnail");
            FirstActiveRecommendProductThumbnailAddToBagButton.Click();
            WaitUntilPageIsLoaded();
        }

        public void AddItemToCart()
        {
            LogHelper.Info("Adding an item to the cart");
            WaitUntilHomePageIsLoaded();
            ClickFirstActiveRecommendProductThumbnailAddToBagButton();
        }
    }
}