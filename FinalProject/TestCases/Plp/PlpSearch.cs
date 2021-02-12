using FinalProject.Helpers;
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

            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(searchString);
            var searchResultLabelPattern = @"\d{1,}" + $" PRODUCT RESULTS FOR '{searchString.ToUpper()}'";
            StringAssert.IsMatch(searchResultLabelPattern, Pages.SearchResultPage.GetSearchResultsLabelText());
        }
    }
}