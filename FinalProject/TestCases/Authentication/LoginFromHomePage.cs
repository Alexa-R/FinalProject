﻿using System.Configuration;
using FinalProject.Constants;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Authentication
{
    public class LoginFromHomePage : BaseTest
    {
        [Test]
        public void VerifyUserIsAbleToLogin()
        {
            var welcomeMessagePattern = $"WELCOME, " + @"\w{1,}";
            
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Assert.IsTrue(Pages.BasePage.IsSelectedAccountButtonDisplayed());
            StringAssert.IsMatch(welcomeMessagePattern, Pages.BasePage.GetUserMenuButtonText());
            Assert.IsTrue(Pages.BasePage.IsBagButtonDisplayed());
        }

        [Test]
        public void VerifyErrorMessageForInvalidEmailAddress()
        {
            var invalidEmail = "invalidEmail";

            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.ClickUserMenuButton();
            Pages.BasePage.ClickLinkInUserPopupMenu(UserPopupMenuLinksNamesConstants.Logout);

            if (Pages.BasePage.IsLoginPopupDisplayed() == false)
            {
                Pages.BasePage.ClickLoginButton();
            }

            Pages.BasePage.WaitUntilLoginPopupIsDisplayed();
            Pages.LoginPopup.EnterEmail(invalidEmail);
            Pages.LoginPopup.EnterPassword(ConfigurationManager.AppSettings["Password"]);
            Pages.LoginPopup.ClickLoginButton();
            Assert.AreEqual("Please enter a valid Email Address.", Pages.LoginPopup.GetEmailValidationMessageText());
        }
    }
}