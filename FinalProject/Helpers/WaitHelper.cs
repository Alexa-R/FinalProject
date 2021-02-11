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

        public static WebDriverWait GetExplicitWait(TimeSpan timeout = default, TimeSpan pollingInterval = default, Type[] exceptionTypes = null)
        {
            var wait = new WebDriverWait(WebDriverFactory.Driver, timeout.Ticks == 0 ? Timeout : timeout)
            {
                PollingInterval = pollingInterval.Ticks == 0 ? PollingInterval : pollingInterval
            };

            wait.IgnoreExceptionTypes(exceptionTypes ?? new[]{ typeof(StaleElementReferenceException) });
            
            return wait;
        }
    }
}