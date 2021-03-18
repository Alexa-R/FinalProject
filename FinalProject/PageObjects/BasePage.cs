using System.Configuration;
using FinalProject.Constants;
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
            LogHelper.Info("Clicking on the Login Button");
            LoginButton.Click();
        }

        public bool IsLoginButtonDisplayed()
        {
            LogHelper.Info("Checking on the display of the Login Button");
            return LoginButton.Displayed;
        }

        public bool IsLanguagesDropdownMenuDisplayed()
        {
            LogHelper.Info("Checking on the display of the Languages Dropdown Menu");
            return LanguagesDropdownMenu.Displayed;
        }

        public void WaitUntilLoginPopupIsDisplayed()
        {
            LogHelper.Info("Waiting for the Login Popup display");
            LoginPopup.WaitForElementIsDisplayed();
        }

        public void ClickUserMenuButton()
        {
            LogHelper.Info("Clicking on the User Menu Button");
            UserMenuButton.Click();
        }

        public string GetUserMenuButtonText()
        {
            LogHelper.Info("Getting the User Menu Button text");
            return UserMenuButton.Text;
        }

        public bool IsUserMenuButtonDisplayed()
        {
            LogHelper.Info("Waiting for the User Menu Button display");
            return UserMenuButton.Displayed;
        }

        public void ClickLinkInUserPopupMenu(string linkName)
        {
            LogHelper.Info($"Clicking on the {linkName} link in user popup menu");
            new WrapperWebElement(By.XPath($"//li[@class='menu-item-label']/a[text()='{linkName}']")).Click();
        }

        public bool IsLoginPopupDisplayed()
        {
            LogHelper.Info("Checking on the display of the Login Popup");
            return LoginPopup.Displayed;
        }

        public void ClickBagButton()
        {
            LogHelper.Info("Clicking on the Bag Button");
            BagButton.Click();

            if (CheckoutButton.Displayed == false)
            {
                BagButton.Click();
            }
        }

        public bool IsBagButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the Bag Button");
            return BagButton.Displayed;
        }

        public bool IsSelectedAccountButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the Selected Account Button");
            return SelectedAccountButton.Displayed;
        }

        public void ClickCheckoutButton()
        {
            LogHelper.Info("Clicking on the Checkout Button");
            CheckoutButton.Click();
        }

        public void ClickViewBagButton()
        {
            LogHelper.Info("Clicking on the View Bag Button");
            ViewBagButton.Click();
        }

        public void ClickShopMenuLink()
        {
            LogHelper.Info("Clicking on the Shop Menu Link");
            ShopMenuLink.Click();
        }

        public void ClickSubcategoryInShopMenu(string categoryName, string subcategoryName)
        {
            LogHelper.Info($"Clicking on the {subcategoryName} subcategory in {categoryName} category");
            new WrapperWebElement(By.XPath($"//*[@class='shop-menu']//*[@class='shop-links-list'][.//a[text()='{categoryName}']]//a[text()='{subcategoryName}']")).Click();
        }

        public void FindItemInSearchInputField(string item)
        {
            LogHelper.Info($"Searching for '{item}' in search input field");
            SearchInputField.SendKeys(item);
            SearchInputField.SendKeys(Keys.Enter);
        }

        public void WaitUntilPageIsLoaded()
        {
            LogHelper.Info("Loading of the page");
            Spinner.WaitForElementDisappear(30000);
        }

        public void LogIn(string login, string password)
        {
            if (Pages.BasePage.IsLoginPopupDisplayed() == false)
            {
                Pages.BasePage.ClickLoginButton();
            }

            Pages.BasePage.WaitUntilLoginPopupIsDisplayed();
            Pages.LoginPopup.EnterEmail(login);
            Pages.LoginPopup.EnterPassword(password);
            Pages.LoginPopup.ClickLoginButton();
        }

        public void CheckUserLoggedIn()
        {
            if (Pages.BasePage.IsUserMenuButtonDisplayed())
            {
                Pages.BasePage.ClickUserMenuButton();
                Pages.BasePage.ClickLinkInUserPopupMenu(UserPopupMenuLinksNamesConstants.Logout);
            }
        }
    }
}