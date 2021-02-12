using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Pdp
{
    [TestFixture]
    public class RatingAndReviews : BaseTest
    {
        private int _numberOfReviewStars;
        private string _reviewTitle;
        private string _reviewContent;
        private string _reviewUsername;
        private string _reviewEmail;

        [Test]
        public void AbilityToAddReview()
        {
            var searchString = "Mix Master";
            _numberOfReviewStars = 5;
            _reviewTitle = $"Review title {RandomHelper.GetRandomString(12)}";
            _reviewContent = $"Review content {RandomHelper.GetRandomString(12)}";
            _reviewUsername = $"{RandomHelper.GetRandomString(8)}";
            _reviewEmail = $"{RandomHelper.GetRandomString(12)}@mail.ru";

            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(searchString);
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