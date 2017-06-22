using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACEManager
{
    public static class ACEManager
    {
        /// <summary>
        /// LameLog is a simple text logger.
        /// </summary>
        public static LameLog Log = new LameLog();

        /// <summary>
        /// The main Configuration of the program.
        /// </summary>
        public static Config Config;

        /// <summary>
        /// About Form to show license and credits.
        /// </summary>
        public static AboutForm AboutForm;

        /// <summary>
        /// Main configuration GUI that changes the application settings.
        /// </summary>
        public static ConfigurationForm ConfigurationForm;

        /// <summary>
        /// Event registered boolean set to true when configuration has been updated from the ConfigurationForm.
        /// </summary>
        public static bool ConfigurationUpdated;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
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

            // Copy initial config for comparison on exit. This is used to save settings.
            Config = ConfigManager.StartingConfiguration;

            // Register the exit event to save the program log.
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Instance the forms
            AboutForm = new AboutForm();
            ConfigurationForm = new ConfigurationForm();

            // Run main
            Application.Run(new ServerControlForm());

            // Finish
            if (!Config.Equals(ConfigManager.StartingConfiguration))
                ConfigManager.Save(Config);

            // Finally append exit to log
            Log.AddLogLine("...Exiting.");
        }

        /// <summary>
        /// Saves the log when the application exits.
        /// </summary>
        private static void OnProcessExit(object sender, EventArgs e)
        {
            Log.SaveLog();
        }
    }
}
