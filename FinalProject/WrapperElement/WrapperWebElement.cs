using System;
using System.Collections.ObjectModel;
using System.Drawing;
using FinalProject.Helpers;
using FinalProject.WrapperFactory;
using OpenQA.Selenium;

namespace FinalProject.WrapperElement
{
    public class WrapperWebElement : IWebElement
    {
        private IWebElement _webElementImplementation;

        public WrapperWebElement(By @by)
        {
            try
            {
                WaitHelper.WaitUntilElementExists(@by, TimeSpan.FromSeconds(10));
            }
            catch (WebDriverTimeoutException)
            {
            }
            _webElementImplementation = WebDriverFactory.Driver.FindElement(@by);
        }

        public IWebElement FindElement(By @by)
        {
            return _webElementImplementation.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _webElementImplementation.FindElements(@by);
        }

        public void Clear()
        {
            WaitHelper.WaitUntilElementIsDisplayed(_webElementImplementation);
            _webElementImplementation.Clear();
        }

        public void SendKeys(string text)
        {
            WaitHelper.WaitUntilElementToBeClickable(_webElementImplementation);
            _webElementImplementation.SendKeys(text);
        }

        public void Submit()
        {
            WaitHelper.WaitUntilElementToBeClickable(_webElementImplementation);
            _webElementImplementation.Submit();
        }

        public void Click()
        {
            WaitHelper.WaitUntilElementToBeClickable(_webElementImplementation);
            _webElementImplementation.Click();
        }

        public string GetAttribute(string attributeName)
        {
            WaitHelper.WaitUntilElementIsDisplayed(_webElementImplementation);
            return _webElementImplementation.GetAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
            WaitHelper.WaitUntilElementIsDisplayed(_webElementImplementation);
            return _webElementImplementation.GetProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElementImplementation.GetCssValue(propertyName);
        }

        public string TagName => _webElementImplementation.TagName;

        public string Text => _webElementImplementation.Text;

        public bool Enabled => _webElementImplementation.Enabled;

        public bool Selected => _webElementImplementation.Selected;

        public Point Location => _webElementImplementation.Location;

        public Size Size => _webElementImplementation.Size;

        public bool Displayed => _webElementImplementation.Displayed;
    }
}