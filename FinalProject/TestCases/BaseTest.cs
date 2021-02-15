using System;
using System.Configuration;
using FinalProject.Constants;
using FinalProject.PageObjects;
using FinalProject.WrapperFactory;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FinalProject.TestCases
{
    public class BaseTest : BaseSuite
    {
        [SetUp]
        public void SetUpTest()
        {
            Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WebDriverFactory.Driver.Manage().Window.Maximize();
            LoginAsUser();
        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                
                switch (status)
                {
                    case TestStatus.Failed:
                        Extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        break;
                    case TestStatus.Skipped:
                        Extent.SetTestStatusSkipped();
                        break;
                    default:
                        Extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception exc)
            {
                throw (exc);
            }
            finally
            {
                WebDriverFactory.CloseAllDrivers();
            }
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