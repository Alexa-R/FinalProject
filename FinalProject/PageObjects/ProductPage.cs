using FinalProject.Helpers;
using FinalProject.WrapperElement;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class ProductPage : BasePage
    {
        private WrapperWebElement MainProductImage => new WrapperWebElement(By.XPath("//*[@id='cc_img__resize_wrapper-product-image-wi23000061']"));
        private WrapperWebElement WriteReviewButton => new WrapperWebElement(By.XPath("//*[contains(@aria-controls,'write-review')]"));
        private WrapperWebElement ProductHeader => new WrapperWebElement(By.XPath("//h1[contains(@class,'product-data__name')]"));
        private WrapperWebElement ReviewTitleInputField => new WrapperWebElement(By.XPath("//input[contains(@id,'yotpo_input_review_title')]"));
        private WrapperWebElement ReviewContentTextArea => new WrapperWebElement(By.XPath("//textarea[contains(@id,'yotpo_input_review_content')]"));
        private WrapperWebElement ReviewUsernameInputField => new WrapperWebElement(By.XPath("//input[contains(@id,'yotpo_input_review_username')]"));
        private WrapperWebElement ReviewEmailInputField => new WrapperWebElement(By.XPath("//input[contains(@id,'yotpo_input_review_email')]"));
        private WrapperWebElement ReviewPostButton => new WrapperWebElement(By.XPath("//*[contains(@id,'write-review-tabpanel')]//*[@data-button-type='submit']"));
        private WrapperWebElement FirstReviewTitle => new WrapperWebElement(By.XPath("//*[@class='yotpo-review yotpo-regular-box' and @data-review-id='0']//*[@role='heading']"));
        private WrapperWebElement FirstReviewContent => new WrapperWebElement(By.XPath("//*[@class='yotpo-review yotpo-regular-box' and @data-review-id='0']//*[@class='content-review']"));
        private WrapperWebElement FirstReviewUsername => new WrapperWebElement(By.XPath("//*[@class='yotpo-review yotpo-regular-box' and @data-review-id='0']//*[contains(@class,'user-name')]"));
        
        public void WaitUntilProductImageIsDisplayed()
        {
            LogHelper.Info("Checking the display of the Main Product Image");
            MainProductImage.WaitForElementIsDisplayed();
        }

        public void ClickWriteReviewButton()
        {
            LogHelper.Info("Clicking on the Write Review Button");
            WriteReviewButton.Click();

            if (ReviewTitleInputField.Displayed == false)
            {
                WriteReviewButton.Click();
            }
        }

        public string GetProductHeaderText()
        {
            LogHelper.Info("Getting the Product Header");
            return ProductHeader.Text;
        }

        public void ClickReviewStar(int starIndex)
        {
            LogHelper.Info($"Clicking on the {starIndex} Review Star");
            new WrapperWebElement(By.XPath($"//*[contains(@id,'write-review-tabpanel')]//*[@class='stars-wrapper']//span[{starIndex}]")).Click();
        }

        public void EnterReviewTitle(string reviewTitle)
        {
            LogHelper.Info("Entering of the Review Title");
            ReviewTitleInputField.SendKeys(reviewTitle);
        }

        public void EnterReviewContent(string reviewContent)
        {
            LogHelper.Info("Entering of the Review Content");
            ReviewContentTextArea.SendKeys(reviewContent);
        }

        public void EnterReviewUsername(string reviewUsername)
        {
            LogHelper.Info("Entering of the Review Username");
            ReviewUsernameInputField.SendKeys(reviewUsername);
        }

        public void EnterReviewEmail(string reviewEmail)
        {
            LogHelper.Info("Entering of the Review Email");
            ReviewEmailInputField.SendKeys(reviewEmail);
        }

        public void ClickReviewPostButton()
        {
            LogHelper.Info("Clicking on the Review Post Button");
            ReviewPostButton.Click();
        }

        public string GetFirstReviewTitleText()
        {
            LogHelper.Info("Getting the First Review Title");
            return FirstReviewTitle.Text;
        }

        public string GetFirstReviewContentText()
        {
            LogHelper.Info("Getting the First Review Content");
            return FirstReviewContent.Text;
        }

        public string GetFirstReviewUsernameText()
        {
            LogHelper.Info("Getting the First Review Username");
            return FirstReviewUsername.Text;
        }
    }
}