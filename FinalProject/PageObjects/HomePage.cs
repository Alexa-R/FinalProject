using System;
using FinalProject.Helpers;
using FinalProject.WrapperElement;
using FinalProject.WrapperFactory;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class HomePage
    {
        private WrapperWebElement FirstActiveRecommendProductThumbnailAddToBagButton => new WrapperWebElement(By.XPath("//*[contains(@class,'prod_thumbnail')]//button[not(contains(@class,'disabled'))][.//*[text()='Add to bag']]"));

        public void WaitUntilHomePageIsLoaded()
        {
            var recommendationsCarouselXpath = "//*[@id='wi2100088-oc3-recommendations-carousel-id']";

            try
            {
                WaitHelper.WaitUntilElementExists(By.XPath(recommendationsCarouselXpath), TimeSpan.FromSeconds(5));
            }
            catch (WebDriverTimeoutException)
            {
                WebDriverFactory.Driver.Navigate().Refresh();
                WaitHelper.WaitUntilElementExists(By.XPath(recommendationsCarouselXpath), TimeSpan.FromSeconds(5));
            }
        }

        public void ClickFirstActiveRecommendProductThumbnailAddToBagButton()
        {
            FirstActiveRecommendProductThumbnailAddToBagButton.Click();
        }
    }
}