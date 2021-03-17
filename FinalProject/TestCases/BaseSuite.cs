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
                    var senderNickname = "Lizy Flower";
                    var from = "lizy.flower22@gmail.com";
                    var to = "lizy.flower22@gmail.com";
                    var subject = "Test results!";
                    var body = "All tests have passed status!";
                    var attachmentPath = "ExtentReports.html";
                    GMailHelper.SendMessageWithAttachment(senderNickname, from, to, subject, body, attachmentPath);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}