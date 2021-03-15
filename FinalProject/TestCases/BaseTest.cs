using System;
using System.Configuration;
using FinalProject.Helpers;
using FinalProject.WrapperFactory;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FinalProject.TestCases
{
    [AllureNUnit]
    public class BaseTest : BaseSuite
    {
        [SetUp]
        public void SetUpTest()
        {
            Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            WebDriverFactory.InitBrowser("Chrome");
            LogHelper.Info("Browser started.");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            LogHelper.Info($"Browser navigated to the url [{ConfigurationManager.AppSettings["URL"]}].");
            WebDriverFactory.Driver.Manage().Window.Maximize();
            LogHelper.Info("Browser maximized.");
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
                LogHelper.Info("Browser closed.");
            }
        }
    }
}