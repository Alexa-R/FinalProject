using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Pdp
{
    [TestFixture]
    public class RatingAndReviews : BaseTest
    {
        private int _numberOfReviewStars = 5;
        private string _reviewTitle = "Review title";
        private string _reviewContent = "Review content";
        private string _reviewUsername = "James";
        private string _reviewEmail = "test@mail.ru";

        [Test]
        public void AbilityToAddReview()
        {
            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField("Mix Master");
            Pages.ProductPage.WaitUntilProductImageIsDisplayed();
            Pages.ProductPage.ClickWriteReviewButton();
            Pages.ProductPage.ClickReviewStar(_numberOfReviewStars);
            Pages.ProductPage.EnterReviewTitle(_reviewTitle);
            Pages.ProductPage.EnterReviewContent(_reviewContent);
            Pages.ProductPage.EnterReviewUsername(_reviewUsername);
            Pages.ProductPage.EnterReviewEmail(_reviewEmail);
            Pages.ProductPage.ClickReviewPostButton();
            Assert.That(Pages.ProductPage.GetFirstReviewStarsRatingText(), Contains.Substring(_numberOfReviewStars.ToString()).IgnoreCase);
            Assert.AreEqual(_reviewTitle.ToUpper(), Pages.ProductPage.GetFirstReviewTitleText());
            Assert.AreEqual(_reviewContent, Pages.ProductPage.GetFirstReviewContentText());
            Assert.AreEqual(_reviewUsername, Pages.ProductPage.GetFirstReviewUsernameText());
        }
    }
}