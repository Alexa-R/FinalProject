using FinalProject.Helpers;
using FinalProject.WrapperElement;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class BasePage
    {
        private WrapperWebElement LoginButton => new WrapperWebElement(By.XPath("//*[@id='headerBar']//button[text()='Log In']"));
        private WrapperWebElement LanguagesDropdownMenu => new WrapperWebElement(By.XPath("//*[@id='headerBar']//g-country-selector"));
        private WrapperWebElement SelectedAccountButton => new WrapperWebElement(By.XPath("//*[@id='wi2100057-account-selector-1-id']"));
        private WrapperWebElement UserMenuButton => new WrapperWebElement(By.XPath("//button[.//*[contains(@class,'user-menu')]]"));
        private WrapperWebElement BagButton => new WrapperWebElement(By.XPath("//*[@class='tigi-header__bag-icon']"));
        private WrapperWebElement LoginPopup => new WrapperWebElement(By.XPath("//*[@id='tigi-login-modal']"));
        private WrapperWebElement CheckoutButton => new WrapperWebElement(By.XPath("//*[@class='minicart-popup__links']//a[contains(@href,'checkout')]"));
        private WrapperWebElement ViewBagButton => new WrapperWebElement(By.XPath("//*[@class='minicart-popup__links']//a[contains(@href,'cart')]"));
        private WrapperWebElement ShopMenuLink => new WrapperWebElement(By.XPath("//*[@id='headerBar']//a[text()='Shop']"));
        private WrapperWebElement SearchInputField => new WrapperWebElement(By.XPath("//input[@type='search']"));
        private WrapperWebElement Spinner => new WrapperWebElement(By.XPath("//*[@id='cc-spinner']"));

        public void ClickLoginButton()
        {
            LoginButton.Click();
            LogHelper.Info("Login Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Login Button is clicked");
        }

        public bool IsLoginButtonDisplayed()
        {
            return LoginButton.Displayed;
        }

        public bool IsLanguagesDropdownMenuDisplayed()
        {
            return LanguagesDropdownMenu.Displayed;
        }

        public void WaitUntilLoginPopupIsDisplayed()
        {
            LoginPopup.WaitForElementIsDisplayed();
            LogHelper.Info("Login Popup is displayed");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Login Button is clicked");
        }

        public void ClickUserMenuButton()
        {
            UserMenuButton.Click();
            LogHelper.Info("User Menu Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("User Menu Button is clicked");
        }

        public string GetUserMenuButtonText()
        {
            return UserMenuButton.Text;
        }

        public bool IsUserMenuButtonDisplayed()
        {
            return UserMenuButton.Displayed;
        }

        public void ClickLinkInUserPopupMenu(string linkName)
        {
            new WrapperWebElement(By.XPath($"//li[@class='menu-item-label']/a[text()='{linkName}']")).Click();
            LogHelper.Info($"{linkName} link in user popup menu is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{linkName} link in user popup menu is clicked");
        }

        public bool IsLoginPopupDisplayed()
        {
            return LoginPopup.Displayed;
        }

        public void ClickBagButton()
        {
            BagButton.Click();

            if (CheckoutButton.Displayed == false)
            {
                BagButton.Click();
            }

            LogHelper.Info("Bag Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Bag Button is clicked");
        }

        public bool IsBagButtonDisplayed()
        {
            return BagButton.Displayed;
        }

        public bool IsSelectedAccountButtonDisplayed()
        {
            return SelectedAccountButton.Displayed;
        }

        public void ClickCheckoutButton()
        {
            CheckoutButton.Click();
            LogHelper.Info("Checkout Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Checkout Button is clicked");
        }

        public void ClickViewBagButton()
        {
            ViewBagButton.Click();
            LogHelper.Info("View Bag Button is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("View Bag Button is clicked");
        }

        public void ClickShopMenuLink()
        {
            ShopMenuLink.Click();
            LogHelper.Info("Shop Menu Link is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Shop Menu Link is clicked");
        }

        public void ClickSubcategoryInShopMenu(string categoryName, string subcategoryName)
        {
            new WrapperWebElement(By.XPath($"//*[@class='shop-menu']//*[@class='shop-links-list'][.//a[text()='{categoryName}']]//a[text()='{subcategoryName}']")).Click();
            LogHelper.Info($"{subcategoryName} subcategory in {categoryName} category is clicked");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{subcategoryName} subcategory in {categoryName} category is clicked");
        }

        public void FindItemInSearchInputField(string item)
        {
            SearchInputField.SendKeys(item);
            SearchInputField.SendKeys(Keys.Enter);
            LogHelper.Info($"{item} is searched");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass($"{item} is searched");
        }

        public void WaitUntilPageIsLoaded()
        {
            Spinner.WaitForElementDisappear();
            LogHelper.Info("Page is loaded");
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusPass("Page is loaded");
        }
    }
}