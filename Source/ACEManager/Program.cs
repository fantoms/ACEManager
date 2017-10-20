using System;
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
        /// Database Maintenance form to create, update, or delete database tables.
        /// </summary>
        public static DatabaseMaintenanceForm DatabaseMaintenanceForm;

        /// <summary>
        /// Commahnd Line Arguments, configured durring application initialization.
        /// </summary>
        public static Options CommandLineOptions;

        /// <summary>
        /// Event registered boolean set to true when configuration has been updated from the ConfigurationForm.
        /// </summary>
        public static bool ConfigurationUpdateRequired;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
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
                MessageBox.Show("Configuration Errors! Check your Config!\n" + exception.Message, "Unknown Error", MessageBoxButtons.OK);
                Log.AddLogLine(exception.ToString());
            }

            // Bomb out (exit) if the config had issues loading.
            if (!ConfigManager.ConfigurationLoaded)
                Environment.Exit(1);

            // Copy initial config for comparison on exit. This is used to save settings.
            Config = ConfigManager.StartingConfiguration;

            // Register the exit event to save the program log.
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CommandLineOptions = new Options();

            // Replace config settings with command line override:
            // If there is an issue parsing the command line arguments, we will bail out and Exit the app.
            if (!CommandAutomation.ParseCommandLine(args))
                Environment.Exit(1);

            // Instance the forms
            AboutForm = new AboutForm();
            ConfigurationForm = new ConfigurationForm();
            // This needs to be explicitly after the command line parse to override 
            DatabaseMaintenanceForm = new DatabaseMaintenanceForm();

            if (CommandLineOptions.ActionToPerform != CommandLineAction.DoNothing)
            {
                // run action and close
                CommandAutomation.RunActions();
            }
            else
            {
                // Run main
                Application.Run(new ServerControlForm());
                // Finish
                if (!Config.Equals(ConfigManager.StartingConfiguration))
                    ConfigManager.Save(Config);
            }
            
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
