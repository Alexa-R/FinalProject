using System;
using FinalProject.Helpers;
using NUnit.Framework;

namespace FinalProject.TestCases
{
    [SetUpFixture]
    public class BaseSuite
    {
        protected ExtentReportsHelper Extent;
        protected bool IsReportClosed;

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
                IsReportClosed = true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        [OneTimeTearDown]
        public void SendMessage()
        {
            if (ExtentReportsHelper.AreTestsPassed && IsReportClosed)
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
    }
}