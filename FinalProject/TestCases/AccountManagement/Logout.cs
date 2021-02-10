using FinalProject.Constants;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.AccountManagement
{
    [TestFixture]
    public class Logout : BaseTest
    {
        [Test]
        public void VerifyUserIsAbleToLogout()
        {
            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.ClickUserMenuButton();
            Pages.BasePage.ClickLinkInUserPopupMenu(UserPopupMenuLinksNamesConstants.Logout);
            Assert.IsTrue(Pages.BasePage.IsLoginButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsLanguagesDropdownMenuDisplayed());
        }
    }
}