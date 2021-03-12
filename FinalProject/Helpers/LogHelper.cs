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
        }
    }
}