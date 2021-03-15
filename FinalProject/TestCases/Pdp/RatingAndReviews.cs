using System.Configuration;
using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Pdp
{
    public class RatingAndReviews : BaseTest
    {
        private string _searchString;
        private int _numberOfReviewStars;
        private string _reviewTitle;
        private string _reviewContent;
        private string _reviewUsername;
        private string _reviewEmail;

        [Test]
        public void AbilityToAddReview()
        {
            _searchString = "Mix Master";
            _numberOfReviewStars = 5;
            _reviewTitle = $"ReviewTitle{RandomHelper.GetRandomString(12)}";
            _reviewContent = $"ReviewContent{RandomHelper.GetRandomString(12)}";
            _reviewUsername = $"{RandomHelper.GetRandomString(8)}";
            _reviewEmail = $"{RandomHelper.GetRandomString(12)}@mail.ru";

            Pages.BasePage.CheckUserLoggedIn();
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(_searchString);
            Pages.ProductPage.WaitUntilProductImageIsDisplayed();
            Pages.ProductPage.ClickWriteReviewButton();
            Pages.ProductPage.ClickReviewStar(_numberOfReviewStars);
            Pages.ProductPage.EnterReviewTitle(_reviewTitle);
            Pages.ProductPage.EnterReviewContent(_reviewContent);
            Pages.ProductPage.EnterReviewUsername(_reviewUsername);
            Pages.ProductPage.EnterReviewEmail(_reviewEmail);
            Pages.ProductPage.ClickReviewPostButton(); 
            Assert.AreEqual(_reviewTitle.ToUpper(), Pages.ProductPage.GetFirstReviewTitleText());
            Assert.AreEqual(_reviewContent, Pages.ProductPage.GetFirstReviewContentText());
            Assert.AreEqual(_reviewUsername, Pages.ProductPage.GetFirstReviewUsernameText());
        }
    }
}