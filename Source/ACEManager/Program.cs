using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACEManager
{
    public static class Program
    {
        /// <summary>
        /// LameLog is a simple text logger.
        /// </summary>
        public static LameLog Log = new LameLog();

        public static Config Config;

        public static AboutForm About;

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

            About = new AboutForm();
            Application.Run(new FormServerControl());

            // Finish
            if (!Config.Equals(ConfigManager.StartingConfiguration))
                ConfigManager.Save(Config);

            Log.AddLogLine("...Exiting.");
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            Log.SaveLog();
        }
    }
}
