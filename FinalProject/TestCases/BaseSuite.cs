using System;
using FinalProject.Helpers;
using NUnit.Framework;

namespace FinalProject.TestCases
{
    [SetUpFixture]
    public class BaseSuite
    {
        private ExtentReportsHelper Extent;

        [OneTimeSetUp]
        public void SetUpReporter()
        {
            Extent = ExtentReportsHelper.GetExtentReportsHelper();
        }

        [OneTimeTearDown]
        public void CloseReporterAndSendMessage()
        {
            try
            {
                Extent.Close();

                var senderNickname = "Lizy Flower";
                var from = "lizy.flower22@gmail.com";
                var to = "lizy.flower22@gmail.com";
                var subject = "Test results!";
                var body = "Test run is over! The report is attached to the letter.";
                var attachmentPath = "ExtentReports.html";
                GMailHelper.SendMessageWithAttachment(senderNickname, from, to, subject, body, attachmentPath);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}