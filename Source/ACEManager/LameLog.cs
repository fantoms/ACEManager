using System;
using System.IO;
using System.Text;

namespace ACEManager
{
    /// <summary>
    /// Save readable text data into text "log" files.
    /// </summary>
    public class LameLog
    {
        // Set's constants to be overriden by config defaults
        public const string LogFilenameDateFormat = "yyyy-M-dd_HH-mm-ss";
        public const string LogFilenameExt = ".log";
        public const string LogDataFormat = "yyyy-M-dd_HH-mm-ss.ffff";

        private TupleList<DateTime, string> logStringsByTime = new TupleList<DateTime, string>();

        public LameLog() { }

        private static readonly object _objectLock = new object();

        public void AddLogLine(string logLine)
        {
            lock (_objectLock)
            {
                if (ACEManager.Config.SaveLogFile)
                    logStringsByTime.Add(DateTime.Now, logLine);
                else
                    Console.WriteLine(logLine);
            }
        }

        public void SaveLog()
        {
            if (!ACEManager.Config.SaveLogFile)
            {
                Console.WriteLine("Avoiding log save due to configuration setting.");
                return;
            }
            {
                // attempt at saving log to log location...
                var logLocation = Path.GetTempPath();
                var logFilenameDateFormat = LogFilenameDateFormat;
                var logDataFormat = LogDataFormat;

                // What IF: No CONFIG?!
                if (!string.IsNullOrEmpty(ACEManager.Config.LocalLogPath))
                {
                    logLocation = ACEManager.Config.LocalLogPath;
                }

                if (!string.IsNullOrEmpty(ACEManager.Config.LogFilenameDateFormat))
                {
                    logFilenameDateFormat = ACEManager.Config.LogFilenameDateFormat;
                }

                if (!string.IsNullOrEmpty(ACEManager.Config.LogLineDateFormat))
                {
                    logDataFormat = ACEManager.Config.LogLineDateFormat;
                }

                var logFileName = DateTime.Now.ToString(logFilenameDateFormat) + LogFilenameExt;

                try
                {
                    var logFile = File.OpenWrite(logLocation + logFileName);
                    foreach (Tuple<DateTime, string> kvp in this.logStringsByTime)
                    {                        
                        byte[] line = Encoding.ASCII.GetBytes($"{kvp.Item1.ToString(logDataFormat)} : {StripNewlines(kvp.Item2)} {Environment.NewLine}");
                        logFile.Write(line, 0, line.Length);
                    }
                    logFile.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error saving log file: " + e.ToString());
                }
            }
        }

        public static string StripNewlines(string inputString)
        {
            int length = inputString.Length;
            char[] result = new char[length];
            int count = 0;

            for (int i = 0; i < length; i++)
            {
                char c = inputString[i];
                if (c != '\r' && c != '\n')
                    result[count++] = c;
            }
            return new String(result, 0, count);
        }
    }
}
