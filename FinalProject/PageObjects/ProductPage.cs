using FinalProject.Helpers;
using FinalProject.WrapperElement;
using OpenQA.Selenium;

namespace FinalProject.PageObjects
{
    public class ProductPage
    {
        private WrapperWebElement MainProductImage => new WrapperWebElement(By.XPath("//*[@id='cc_img__resize_wrapper-product-image-wi23000061']"));
        private WrapperWebElement WriteReviewButton => new WrapperWebElement(By.XPath("//*[contains(@aria-controls,'write-review')]"));
        private WrapperWebElement ProductHeader => new WrapperWebElement(By.XPath("//h1[contains(@class,'product-data__name')]"));
        private WrapperWebElement ReviewTitleInputField => new WrapperWebElement(By.XPath("//input[contains(@id,'yotpo_input_review_title')]"));
        private WrapperWebElement ReviewContentTextArea => new WrapperWebElement(By.XPath("//textarea[contains(@id,'yotpo_input_review_content')]"));
        private WrapperWebElement ReviewUsernameInputField => new WrapperWebElement(By.XPath("//input[contains(@id,'yotpo_input_review_username')]"));
        private WrapperWebElement ReviewEmailInputField => new WrapperWebElement(By.XPath("//input[contains(@id,'yotpo_input_review_email')]"));
        private WrapperWebElement ReviewPostButton => new WrapperWebElement(By.XPath("//*[contains(@id,'write-review-tabpanel')]//*[@data-button-type='submit']"));
        private WrapperWebElement FirstReviewStarsRating => new WrapperWebElement(By.XPath("//*[contains(@class,'yotpo-review yotpo-regular-box')][2]//*[@class='yotpo-review-stars ']"));
        private WrapperWebElement FirstReviewTitle => new WrapperWebElement(By.XPath("//*[contains(@class,'yotpo-review yotpo-regular-box')][2]//*[@role='heading']"));
        private WrapperWebElement FirstReviewContent => new WrapperWebElement(By.XPath("//*[contains(@class,'yotpo-review yotpo-regular-box')][2]//*[@class='content-review']"));
        private WrapperWebElement FirstReviewUsername => new WrapperWebElement(By.XPath("//*[contains(@class,'yotpo-review yotpo-regular-box')][2]//*[contains(@class,'user-name')]"));
        
        public void WaitUntilProductImageIsDisplayed()
        {
            WaitHelper.WaitUntilElementIsDisplayed(MainProductImage);
        }

        public void ClickWriteReviewButton()
        {
            WriteReviewButton.Click();
        }

        public string GetProductHeaderText()
        {
            return ProductHeader.Text;
        }

        public void ClickReviewStar(int starIndex)
        {
            new WrapperWebElement(By.XPath($"//*[contains(@id,'write-review-tabpanel')]//*[@class='stars-wrapper']//span[{starIndex}]")).Click();
        }

        public void EnterReviewTitle(string reviewTitle)
        {
            ReviewTitleInputField.SendKeys(reviewTitle);
        }

        public void EnterReviewContent(string reviewContent)
        {
            ReviewContentTextArea.SendKeys(reviewContent);
        }

        public void EnterReviewUsername(string reviewUsername)
        {
            ReviewUsernameInputField.SendKeys(reviewUsername);
        }

        public void EnterReviewEmail(string reviewEmail)
        {
            ReviewEmailInputField.SendKeys(reviewEmail);
        }

        public void ClickReviewPostButton()
        {
            ReviewPostButton.Click();
        }

        public string GetFirstReviewStarsRatingText()
        {
            return FirstReviewStarsRating.Text;
        }

        public string GetFirstReviewTitleText()
        {
            return FirstReviewTitle.Text;
        }

        public string GetFirstReviewContentText()
        {
            return FirstReviewContent.Text;
        }

        public string GetFirstReviewUsernameText()
        {
            return FirstReviewUsername.Text;
        }
    }
}