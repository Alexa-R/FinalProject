using FinalProject.Helpers;
using FinalProject.WrapperElement;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class LoginPopup
    {
        private WrapperWebElement EmailInputField => new WrapperWebElement(By.XPath("//*[@id='login-email']"));
        private WrapperWebElement PasswordInputField => new WrapperWebElement(By.XPath("//*[@id='login-password']"));
        private WrapperWebElement LoginButton => new WrapperWebElement(By.XPath("//*[@id='tigi-login-modal']//button[text()='Log In']"));
        private WrapperWebElement EmailValidationMessage => new WrapperWebElement(By.XPath("//*[@class='modal-with-aside__field'][.//*[@id='login-email']]//*[@role='alert']"));

        public void EnterEmail(string mail)
        {
            LogHelper.Info($"Entering of the Email '{mail}'");
            EmailInputField.SendKeys(mail);
        }

        public void EnterPassword(string password)
        {
            LogHelper.Info($"Entering of the Password '{password}'");
            PasswordInputField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LogHelper.Info("Clicking on the Login Button");
            LoginButton.Click();
        }

        public string GetEmailValidationMessageText()
        {
            LogHelper.Info("Getting the Email Validation Message");
            return EmailValidationMessage.Text;
        }
    }
}