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
            EmailInputField.SendKeys(mail);
        }

        public void EnterPassword(string password)
        {
            PasswordInputField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public string GetEmailValidationMessageText()
        {
            return EmailValidationMessage.Text;
        }
    }
}