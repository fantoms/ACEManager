using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACEManager
{
    static class Program
    {
        /// <summary>
        /// LameLog is a simple text logger.
        /// </summary>
        public static LameLog Log = new LameLog();

        private static Config StartingConfig { get; set; } 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.AddLogLine("Starting...");

            // Attempt to load config
            //  If load fails, attempt to build a new one or fail
            try
            {
                ConfigManager.Initialize();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Unknown Error", MessageBoxButtons.OK);
                Log.AddLogLine(exception.ToString());
            }

            if (!ConfigManager.ConfigurationLoaded)
                Environment.Exit(1);

            // Saving initial config for comparison on exit. This is used to save settings.
            StartingConfig = ConfigManager.Configuration;

            // Register the exit event to save the program log.
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormServerControl());

            // Finish
            if (!StartingConfig.Equals(ConfigManager.Configuration))
                ConfigManager.Save();

            Log.AddLogLine("...Exiting.");
        }

        async static void SaveProgramLog()
        {
            await Log.SaveLog();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            SaveProgramLog();
        }
    }
}
