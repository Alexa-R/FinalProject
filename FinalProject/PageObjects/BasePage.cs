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
        }

        public bool IsLoginButtonDisplayed()
        {
            return LoginButton.Displayed;
        }

        public bool IsLanguagesDropdownMenuDisplayed()
        {
            return LanguagesDropdownMenu.Displayed;
        }

        public void ClickUserMenuButton()
        {
            UserMenuButton.Click();
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
        }

        public bool IsLoginPopupDisplayed()
        {
            return LoginPopup.Displayed;
        }

        public void ClickBagButton()
        {
            BagButton.Click();
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
        }

        public void ClickViewBagButton()
        {
            ViewBagButton.Click();
        }

        public void ClickShopMenuLink()
        {
            ShopMenuLink.Click();
        }

        public void ClickSubcategoryInShopMenu(string categoryName, string subcategoryName)
        {
            new WrapperWebElement(By.XPath($"//*[@class='shop-menu']//*[@class='shop-links-list'][.//a[text()='{categoryName}']]//a[text()='{subcategoryName}']")).Click();
        }

        public void SearchItemInSearchInputField(string item)
        {
            SearchInputField.SendKeys(item);
            SearchInputField.SendKeys(Keys.Enter);
        }

        public void WaitUntilPageIsLoaded()
        {
            Spinner.WaitForElementDisappear();
        }
    }
}