using System;
using FinalProject.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Helpers
{
    public static class WaitHelper
    {
        public static TimeSpan Timeout = TimeSpan.FromSeconds(15);
        public static TimeSpan PollingInterval = TimeSpan.FromMilliseconds(500);

        public static WebDriverWait GetExplicitWait(TimeSpan timeout = default, TimeSpan pollingInterval = default)
        {
            var wait = new WebDriverWait(WebDriverFactory.Driver, timeout.Ticks == 0 ? Timeout : timeout)
            {
                PollingInterval = pollingInterval.Ticks == 0 ? PollingInterval : pollingInterval
            };

            return wait;
        }

        public static void WaitUntilElementIsDisplayed(IWebElement element, TimeSpan timeout = default, TimeSpan pollingInterval = default)
        {
            GetExplicitWait(timeout, pollingInterval).Until((d) => element.Displayed);
        }
        
        public static void WaitUntilElementToBeClickable(IWebElement element, TimeSpan timeout = default, TimeSpan pollingInterval = default)
        {
            GetExplicitWait(timeout, pollingInterval).Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitUntilElementStaleness(IWebElement element, TimeSpan timeout = default, TimeSpan pollingInterval = default)
        {
            GetExplicitWait(timeout, pollingInterval).Until(ExpectedConditions.StalenessOf(element));
        }

        public static void WaitUntilElementExists(By @by, TimeSpan timeout = default, TimeSpan pollingInterval = default)
        {
            GetExplicitWait(timeout, pollingInterval).Until(ExpectedConditions.ElementExists(@by));
        }

        public static void WaitUntilInvisibilityOfElementWithText(By @by, string text, TimeSpan timeout = default, TimeSpan pollingInterval = default)
        {
            GetExplicitWait(timeout, pollingInterval).Until(ExpectedConditions.InvisibilityOfElementWithText(@by, text));
        }
    }
}