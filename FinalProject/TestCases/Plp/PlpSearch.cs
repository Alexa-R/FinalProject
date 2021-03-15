using System.Configuration;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Plp
{
    public class PlpSearch : BaseTest
    {
        [Test]
        public void TextAboveFacetsIndicateNumberOfMatchingResults()
        {
            var searchString = "shampoo";
            var searchResultLabelPattern = @"\d{1,}" + $" PRODUCT RESULTS FOR '{searchString.ToUpper()}'";

            Pages.BasePage.CheckUserLoggedIn();
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(searchString);
            StringAssert.IsMatch(searchResultLabelPattern, Pages.SearchResultPage.GetSearchResultsLabelText());
        }
    }
}