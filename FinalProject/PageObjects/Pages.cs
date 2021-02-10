using FinalProject.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;

namespace FinalProject.PageObjects
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriverFactory.Driver, page);

            return page;
        }

        public static BasePage BasePage => GetPage<BasePage>();

        public static LoginPopup LoginPopup => GetPage<LoginPopup>();

        public static HomePage HomePage => GetPage<HomePage>();
        
        public static CheckoutPage CheckoutPage => GetPage<CheckoutPage>();

        public static SearchResultPage SearchResultPage => GetPage<SearchResultPage>();

        public static ProductPage ProductPage => GetPage<ProductPage>();

        public static CartPage CartPage => GetPage<CartPage>();
    }
}
