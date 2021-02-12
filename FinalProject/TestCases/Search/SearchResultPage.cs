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
            var searchString = "GL 2/0 DARKEST NATURAL BROWN";

            LoginHelper.LoginAsUser();
            Pages.HomePage.WaitUntilHomePageIsLoaded();
            Pages.BasePage.FindItemInSearchInputField(searchString);
            Assert.That(Pages.ProductPage.GetProductHeaderText(), Contains.Substring(searchString).IgnoreCase);
        }
    }
}