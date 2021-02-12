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
        }

        public void ClickFirstActiveRecommendProductThumbnailAddToBagButton()
        {
            FirstActiveRecommendProductThumbnailAddToBagButton.Click();
            WaitUntilPageIsLoaded();
        }

        public void AddItemToCart()
        {
            WaitUntilHomePageIsLoaded();
            ClickFirstActiveRecommendProductThumbnailAddToBagButton();
        }
    }
}