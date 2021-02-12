using System.Configuration;
using FinalProject.Constants;
using FinalProject.PageObjects;
using FinalProject.WrapperFactory;
using NUnit.Framework;

namespace FinalProject.TestCases
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void SetUpTest()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WebDriverFactory.Driver.Manage().Window.Maximize();
            LoginAsUser();
        }

        [TearDown]
        public void TearDownTest()
        {
            WebDriverFactory.CloseAllDrivers();
        }

        private void LoginAsUser()
        {
            if (Pages.BasePage.IsUserMenuButtonDisplayed())
            {
                Pages.BasePage.ClickUserMenuButton();
                Pages.BasePage.ClickLinkInUserPopupMenu(UserPopupMenuLinksNamesConstants.Logout);
            }

            if (Pages.BasePage.IsLoginPopupDisplayed() == false)
            {
                Pages.BasePage.ClickLoginButton();
            }

            Pages.BasePage.WaitUntilLoginPopupIsDisplayed();
            Pages.LoginPopup.EnterEmail(ConfigurationManager.AppSettings["Login"]);
            Pages.LoginPopup.EnterPassword(ConfigurationManager.AppSettings["Password"]);
            Pages.LoginPopup.ClickLoginButton();
        }
    }
}
