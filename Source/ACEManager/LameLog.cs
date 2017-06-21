using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ACEManager
{
    /// <summary>
    /// Save readable text data into text "log" files.
    /// </summary>
    public class LameLog
    {
        public const string LogFilenameFormat = "yyyy-M-dd_HH-mm-ss";
        public const string LogFilenameExt = ".log";
        public const string LogDataFormat = "yyyy-M-dd_HH-mm-ss.ffff";

        private TupleList<DateTime, string> logStringsByTime = new TupleList<DateTime, string>();

        public LameLog() { }

        private static readonly object _objectLock = new object();

        public void AddLogLine(string logLine)
        {
            lock (_objectLock)
            {
                if (ConfigManager.StartingConfiguration.SaveLogFile)
                    logStringsByTime.Add(DateTime.Now, logLine);
                else
                    Console.WriteLine(logLine);
            }
        }

        public void SaveLog()
        {
            if (!ConfigManager.StartingConfiguration.SaveLogFile)
            {
                Console.WriteLine("Avoiding log save due to configuration setting.");
                return;
            }
            {
                // attempt at saving log to log location...
                var logLocation = Path.GetTempPath();
                var logFilenameFormat = LogFilenameFormat;
                var logDataFormat = LogDataFormat;

                // What IF: No CONFIG?!
                if (!string.IsNullOrEmpty(ConfigManager.StartingConfiguration.LocalLogPath))
                {
                    logLocation = ConfigManager.StartingConfiguration.LocalLogPath;
                }

                if (!string.IsNullOrEmpty(ConfigManager.StartingConfiguration.LogFilenameFormat))
                {
                    logFilenameFormat = ConfigManager.StartingConfiguration.LogFilenameFormat;
                }

                if (!string.IsNullOrEmpty(ConfigManager.StartingConfiguration.LogDataFormat))
                {
                    logDataFormat = ConfigManager.StartingConfiguration.LogDataFormat;
                }

                var logFileName = DateTime.Now.ToString(logFilenameFormat) + LogFilenameExt;

                try
                {
                    var logFile = File.OpenWrite(logLocation + logFileName);
                    foreach (Tuple<DateTime, string> kvp in this.logStringsByTime)
                    {
                        byte[] line = Encoding.ASCII.GetBytes($"{kvp.Item1.ToString(logDataFormat)} : {kvp.Item2}\r\n");
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
    }
}
