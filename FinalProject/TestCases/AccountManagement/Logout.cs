using System.Configuration;
using FinalProject.Constants;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.AccountManagement
{
    public class Logout : BaseTest
    {
        [Test]
        public void VerifyUserIsAbleToLogout()
        {
            Pages.BasePage.CheckUserLoggedIn();
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.ClickUserMenuButton();
            Pages.BasePage.ClickLinkInUserPopupMenu(UserPopupMenuLinksNamesConstants.Logout);
            Assert.IsTrue(Pages.BasePage.IsLoginButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsLanguagesDropdownMenuDisplayed());
        }
    }
}