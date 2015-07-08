using System;
using System.IO;

namespace Util
{
    public class Logger
    {
        private static string LOG_PATH = "C:\\tmp\\foobartender.log";
        private static Logger instance;

        private Logger()
        {
            Log("=========================================================");
            Log("Logger started");
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void Log(string message)
        {
            StreamWriter sw = File.AppendText(LOG_PATH);
            try
            {
                string logLine = String.Format("{0:G}: {1}.", DateTime.Now, message);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }

        public void Exception(object classInstance, Exception exception)
        {
            var message = "Exception in " +
                          (classInstance == null ? "static class'" : classInstance.GetType().FullName + "'s");
            message += " method:" + exception.TargetSite + " message:" + exception.Message;
            message += "\nStack trace:\n" + exception.StackTrace;
            Log(message);
        }

        public void Warning(string message)
        {
            Log("WARNING:" + message);
        }

        public void ExpectedException(object obj, Exception ex)
        {
            Log("Expected exception in " + (obj ?? "NULL") + " with message : " + ex.Message);
        }
    }
}