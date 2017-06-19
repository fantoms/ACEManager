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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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

            // Register the exit event to save the program log.
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormServerControl());
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
