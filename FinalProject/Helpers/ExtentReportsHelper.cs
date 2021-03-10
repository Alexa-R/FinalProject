using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Reflection;

namespace FinalProject.Helpers
{
    public class ExtentReportsHelper
    {
        private static ExtentReportsHelper _extentReportsHelper;
        private static ExtentReports _extent;
        private static ExtentV3HtmlReporter _reporter;
        private static ExtentTest _test;

        private ExtentReportsHelper() { }

        public static ExtentReportsHelper GetExtentReportsHelper()
        {
            if (_extentReportsHelper == null)
            {
                _extentReportsHelper = new ExtentReportsHelper();
                _extent = new ExtentReports();
                _reporter = new ExtentV3HtmlReporter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ExtentReports.html"));
                _reporter.Config.DocumentTitle = "Automation Testing Report";
                _reporter.Config.ReportName = "Final Project Report";
                _reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                _extent.AttachReporter(_reporter);
                _extent.AddSystemInfo("Machine", Environment.MachineName);
                _extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            }

            return _extentReportsHelper;
        }

        public void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public void SetStepStatusPass(string stepDescription)
        {
            _test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            _test.Log(Status.Warning, stepDescription);
        }

        public void SetTestStatusPass()
        {
            _test.Pass("Test Executed Sucessfully!");
        }

        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";

            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }

            _test.Fail(printMessage);
        }

        public void SetTestStatusSkipped()
        {
            _test.Skip("Test skipped!");
        }

        public void Close()
        {
            _extent.Flush();
        }
    }
}