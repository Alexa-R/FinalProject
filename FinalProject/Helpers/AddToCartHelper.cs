using FinalProject.PageObjects;

namespace FinalProject.Helpers
{
    public static class AddToCartHelper
    {
        public static void AddItemToCartFromHomePage()
        {
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.HomePage.ClickFirstActiveRecommendProductThumbnailAddToBagButton();
        }
    }
}