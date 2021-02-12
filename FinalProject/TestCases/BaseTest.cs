using System.Configuration;
using FinalProject.WrapperFactory;
using NUnit.Framework;

namespace FinalProject.TestCases
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void SetUpTest()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WebDriverFactory.Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDownTest()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
