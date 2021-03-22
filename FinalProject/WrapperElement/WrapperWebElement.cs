using System;
using System.Collections.ObjectModel;
using System.Drawing;
using FinalProject.Helpers;
using FinalProject.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.WrapperElement
{
    public class WrapperWebElement : IWebElement
    {
        public static TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(500);
        public static TimeSpan Timeout = TimeSpan.FromSeconds(15);
        private readonly By _by;
        private IWebElement _webElementImplementation;

        private IWebElement WebElementImplementation
        {
            get
            {
                IWebElement result;

                if (_webElementImplementation == null)
                {
                    result = GetElementWhenExists(_by);
                }
                else
                {
                    result = _webElementImplementation;
                }

                return result;
            }
        }

        public WrapperWebElement(By @by)
        {
            _by = @by;
        }

        public IWebElement FindElement(By @by)
        {
            return WebElementImplementation.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return WebElementImplementation.FindElements(@by);
        }

        public void Clear() => WaitHelper.GetExplicitWait()
            .Until(d =>
            {
                try
                {
                    WebElementImplementation.Clear();

                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Unable to clear the element! Exception message: " + ex.Message);

                    return false;
                }
            });

        public void SendKeys(string text) => WaitHelper.GetExplicitWait(exceptionTypes: new[] {typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException)})
            .Until(d =>
            {
                WebElementImplementation.SendKeys(text);

                return true;
            });

        public void Submit() => WaitHelper.GetExplicitWait(exceptionTypes: new[] {typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException)})
            .Until(d =>
            {
                try
                {
                    WebElementImplementation.Submit();

                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Unable to submit the element! Exception message: " + ex.Message);

                    return false;
                }
            });

        public void Click() => WaitHelper.GetExplicitWait(exceptionTypes: new[] {typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException)})
            .Until(d =>
            {
                try
                {
                    WebElementImplementation.Click();

                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Unable to click on the element! Exception message: " + ex.Message);

                    return false;
                }

            });

        public string GetAttribute(string attributeName) => WaitHelper.GetExplicitWait()
            .Until(d => WebElementImplementation.GetAttribute(attributeName));

        public string GetProperty(string propertyName) => WaitHelper.GetExplicitWait()
            .Until(d => WebElementImplementation.GetProperty(propertyName));

        public string GetCssValue(string propertyName) => WaitHelper.GetExplicitWait()
            .Until(d => WebElementImplementation.GetCssValue(propertyName));

        public string TagName => WaitHelper.GetExplicitWait().Until(d => WebElementImplementation.TagName);

        public string Text => WaitHelper.GetExplicitWait()
            .Until(d =>
        {
            try
            {
                return WebElementImplementation.Text;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Unable to get the element's text! Exception message: " + ex.Message);

                return null;
            }
        });

        public bool Enabled => WaitHelper.GetExplicitWait().Until(d => WebElementImplementation.Enabled);

        public bool Selected => WaitHelper.GetExplicitWait().Until(d => WebElementImplementation.Selected);

        public Point Location => WaitHelper.GetExplicitWait().Until(d => WebElementImplementation.Location);

        public Size Size => WaitHelper.GetExplicitWait().Until(d => WebElementImplementation.Size);
        
        public bool Displayed 
        {
            get
            { 
                try
                {
                    WaitForElementIsDisplayed();

                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Element is not displayed! Exception message: " + ex.Message);
                    
                    return false;
                }
            }
        }
        
        public void WaitForElementDisappear(int? timeout = null) =>
            WaitForElementExistence(timeout == null ? Timeout : TimeSpan.FromMilliseconds((int)timeout), DefaultPollingInterval, false);

        public void WaitForElementIsDisplayed(int? timeout = null) =>
            WaitHelper.GetExplicitWait(timeout == null ? Timeout : TimeSpan.FromMilliseconds((int)timeout), exceptionTypes: new[] { typeof(NoSuchElementException) })
                .Until(d =>
                {
                    try
                    {
                        return WebElementImplementation.Displayed;
                    }
                    catch(Exception)
                    {
                        return false;
                    }
                });

        public void WaitForElementIsStale(int? timeout = null) =>
            WaitHelper.GetExplicitWait(timeout == null ? Timeout : TimeSpan.FromMilliseconds((int)timeout))
                .Until(ExpectedConditions.StalenessOf(WebElementImplementation));

        public void WaitForInvisibilityOfElementWithText(string text, int? timeout = null) =>
            WaitHelper.GetExplicitWait(timeout == null ? Timeout : TimeSpan.FromMilliseconds((int)timeout))
                .Until(ExpectedConditions.InvisibilityOfElementWithText(_by, text));

        private IWebElement GetElementWhenExists(By @by, int timeout = default)
        {
            IsExists(timeout, true);

            return _webElementImplementation = WebDriverFactory.Driver.FindElement(@by);
        }

        private bool IsExists(int timeout, bool shouldExists) => IsExists(TimeSpan.FromSeconds(timeout), shouldExists);

        private bool IsExists(TimeSpan timeout, bool shouldExists)
        {
            try
            {
                WaitForElementExistence(timeout, shouldExists: shouldExists);

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Element cannot be found! Exception message: " + ex.Message);

                return false;
            }
        }

        private void WaitForElementExistence(TimeSpan? timeout = null, TimeSpan? pollingInterval = null, bool shouldExists = true) =>
            WaitHelper.GetExplicitWait(timeout ?? Timeout, pollingInterval ?? DefaultPollingInterval)
                .Until(d => d.FindElements(_by).Count != 0 == shouldExists);
    }
}