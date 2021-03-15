using System;
using Allure.Commons;
using log4net;

namespace FinalProject.Helpers
{
    public static class LogHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message)
        {
            Logger.Info(message);
            ExtentReportsHelper.GetExtentReportsHelper().SetStepStatusInfo(message);

            var step = new StepResult()
            {
                name = message
            };
            AllureLifecycle.Instance.StartStep(Guid.NewGuid().ToString(), step);
            AllureLifecycle.Instance.StopStep();
        }

        public static void Error(string message)
        {
            Logger.Error(message);
        }
    }
}