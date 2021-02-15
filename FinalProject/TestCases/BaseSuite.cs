using System;
using FinalProject.Helpers;
using NUnit.Framework;

namespace FinalProject.TestCases
{
    [TestFixture]
    public class BaseSuite
    {
        protected ExtentReportsHelper Extent;

        [SetUp]
        public void SetUpReporter()
        {
            Extent = ExtentReportsHelper.GetExtentReportsHelper();
        }

        [TearDown]
        public void CloseReporter()
        {
            try
            {
                Extent.Close();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}