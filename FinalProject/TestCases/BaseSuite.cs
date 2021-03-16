using System;
using FinalProject.Helpers;
using NUnit.Framework;

namespace FinalProject.TestCases
{
    [TestFixture]
    public class BaseSuite
    {
        protected ExtentReportsHelper Extent;

        [OneTimeSetUp]
        public void SetUpReporter()
        {
            Extent = ExtentReportsHelper.GetExtentReportsHelper();
        }

        [OneTimeTearDown]
        public void CloseReporter()
        {
            try
            {
                Extent.Close();
                if (ExtentReportsHelper.AreTestsPassed)
                {
                    GMailHelper.SendTextMessage();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}