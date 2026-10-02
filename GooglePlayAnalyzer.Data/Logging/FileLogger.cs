using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Data.Logging
{
    public static class FileLogger
    {
        private const string LogFilePath = "application.log";

        public static void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }
        public static void LogError(string message, Exception ex = null)
        {
            string details = ex != null ? $" | Details: {ex.Message}" : "";
            WriteLog("ERROR", message + details);
        }
        private static void WriteLog(string level, string message)
        {
            try
            {
                string log = $"[{level}] [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(LogFilePath, log + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}
