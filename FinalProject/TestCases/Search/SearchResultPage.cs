using FinalProject.Helpers;
using FinalProject.PageObjects;
using NUnit.Framework;

namespace FinalProject.TestCases.Search
{
    public class SearchResultPage : BaseTest
    {
        [Test]
        public void VerifySiteRedirectsToPdpWhenOneProductIsReturnedAsSearchResult()
        {
            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            var searchString = "GL 2/0 DARKEST NATURAL BROWN";
            Pages.BasePage.FindItemInSearchInputField(searchString);
            Assert.That(Pages.ProductPage.GetProductHeaderText(), Contains.Substring(searchString).IgnoreCase);
        }
    }
}