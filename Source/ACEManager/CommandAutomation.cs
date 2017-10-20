using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACEManager
{
    /// <summary>
    /// This class was created in a interpreted script pattern, too automate functions of the GUI.
    /// </summary>
    public static class CommandAutomation
    {
        /// <summary>
        /// Parse incoming strings from the command line paramaters/arguements. This will set the action to be performed and change configuration variables.
        /// </summary>
        public static bool ParseCommandLine(string[] args)
        {
            CommandLineParser parser = new CommandLineParser(ACEManager.CommandLineOptions);
            try
            {
                parser.Parse();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                ACEManager.Log.AddLogLine(error.ToString());
                if (error.InnerException != null)
                {
                    Console.WriteLine(error.InnerException.Message);
                    ACEManager.Log.AddLogLine(error.InnerException.Message);
                }
                return false;
            }
            return true;
        }

        public static void RunActions()
        {
            DefaultACEDatabase db = ACEManager.CommandLineOptions.DatabaseName;
            
            // Reset config
            if (ACEManager.CommandLineOptions.DataPath != null) ConfigManager.SetDataPath(ACEManager.CommandLineOptions.DataPath);
            if (ACEManager.CommandLineOptions.BackupPath != null) ConfigManager.SetBackupPath(ACEManager.CommandLineOptions.BackupPath);

            var message = "DB: " + Enum.GetName(typeof(DefaultACEDatabase), db) + " Running: " + Enum.GetName(typeof(CommandLineAction), ACEManager.CommandLineOptions.ActionToPerform);
            ACEManager.Log.AddLogLine(message);
            Console.WriteLine(message);
            ACEManager.DatabaseMaintenanceForm.PopulateFormControls();
            switch (ACEManager.CommandLineOptions.ActionToPerform)
            {
                case CommandLineAction.DoNothing:
                    break;
                case CommandLineAction.DownloadFromGithub:
                    ACEManager.DatabaseMaintenanceForm.BtnDownloadUpdates_Click(null, null);
                    break;
                case CommandLineAction.Backup:
                    switch (db)
                    {
                        case DefaultACEDatabase.None:
                        case DefaultACEDatabase.All:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupAllData_Click(null, null);
                            break;
                        case DefaultACEDatabase.Authentication:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupAuth_Click(null, null);
                            break;
                        case DefaultACEDatabase.Shard:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupShard_Click(null, null);
                            break;
                        case DefaultACEDatabase.World:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupWorld_Click(null, null);
                            break;
                    }
                    break;
                case CommandLineAction.Reset:
                    switch (db)
                    {
                        case DefaultACEDatabase.None:
                            message = "Sorry, no database selected. Please pass in a database to use this action.";
                            ACEManager.Log.AddLogLine(message);
                            Console.WriteLine(message);
                            break;
                        case DefaultACEDatabase.All:
                            ACEManager.DatabaseMaintenanceForm.BtnResetAllData_Click(null, null);
                            break;
                        case DefaultACEDatabase.Authentication:
                            ACEManager.DatabaseMaintenanceForm.BtnResetAuth_Click(null, null);
                            break;
                        case DefaultACEDatabase.Shard:
                            ACEManager.DatabaseMaintenanceForm.BtnResetShard_Click(null, null);
                            break;
                        case DefaultACEDatabase.World:
                            ACEManager.DatabaseMaintenanceForm.BtnResetWorld_Click(null, null);
                            break;
                    }
                    break;
                case CommandLineAction.LoadFromLastBackup:
                    switch (db)
                    {
                        case DefaultACEDatabase.None:
                            message = "Sorry, no database selected. Please pass in a database to use this action.";
                            ACEManager.Log.AddLogLine(message);
                            Console.WriteLine(message);
                            break;
                        case DefaultACEDatabase.All:
                            ACEManager.DatabaseMaintenanceForm.LoadAllBackups();
                            break;
                        case DefaultACEDatabase.Authentication:
                            ACEManager.DatabaseMaintenanceForm.BtnLoadLastAuthBackup_Click(null, null);
                            break;
                        case DefaultACEDatabase.Shard:
                            ACEManager.DatabaseMaintenanceForm.BtnLoadLastShardBackup_Click(null, null);
                            break;
                        case DefaultACEDatabase.World:
                            ACEManager.DatabaseMaintenanceForm.BtnLoadLastWorldBackup_Click(null, null);
                            break;
                    }
                    break;
                case CommandLineAction.BackupLoadWorldUpdates:
                    // Backup the world database before overwritting?
                    ACEManager.DatabaseMaintenanceForm.BtnBackupWorld_Click(null, null);
                    ACEManager.DatabaseMaintenanceForm.BtnDownloadUpdates_Click(null, null);
                    ACEManager.DatabaseMaintenanceForm.BtnWorldUpdates_Click(null, null);
                    break;
                case CommandLineAction.LoadWorldUpdates:
                    ACEManager.DatabaseMaintenanceForm.BtnDownloadUpdates_Click(null, null);
                    ACEManager.DatabaseMaintenanceForm.BtnWorldUpdates_Click(null, null);
                    break;
                case CommandLineAction.DownloadBackupReset:
                    ACEManager.DatabaseMaintenanceForm.BtnDownloadUpdates_Click(null, null);
                    switch (db)
                    {
                        case DefaultACEDatabase.None:
                            message = "Sorry, no database selected. Please pass in a database to use this action.";
                            ACEManager.Log.AddLogLine(message);
                            Console.WriteLine(message);
                            break;
                        case DefaultACEDatabase.All:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupAllData_Click(null, null);
                            ACEManager.DatabaseMaintenanceForm.BtnResetAllData_Click(null, null);
                            break;
                        case DefaultACEDatabase.Authentication:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupAuth_Click(null, null);
                            ACEManager.DatabaseMaintenanceForm.BtnResetAuth_Click(null, null);
                            break;
                        case DefaultACEDatabase.Shard:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupShard_Click(null, null);
                            ACEManager.DatabaseMaintenanceForm.BtnResetShard_Click(null, null);
                            break;
                        case DefaultACEDatabase.World:
                            ACEManager.DatabaseMaintenanceForm.BtnBackupWorld_Click(null, null);
                            ACEManager.DatabaseMaintenanceForm.BtnResetWorld_Click(null, null);
                            break;
                    }
                    break;
                case CommandLineAction.DownloadReset:
                    ACEManager.DatabaseMaintenanceForm.BtnDownloadUpdates_Click(null, null);
                    switch (db)
                    {
                        case DefaultACEDatabase.None:
                            message = "Sorry, no database selected. Please pass in a database to use this action.";
                            ACEManager.Log.AddLogLine(message);
                            Console.WriteLine(message);
                            break;
                        case DefaultACEDatabase.All:
                            ACEManager.DatabaseMaintenanceForm.BtnResetAllData_Click(null, null);
                            break;
                        case DefaultACEDatabase.Authentication:
                            ACEManager.DatabaseMaintenanceForm.BtnResetAuth_Click(null, null);
                            break;
                        case DefaultACEDatabase.Shard:
                            ACEManager.DatabaseMaintenanceForm.BtnResetShard_Click(null, null);
                            break;
                        case DefaultACEDatabase.World:
                            ACEManager.DatabaseMaintenanceForm.BtnResetWorld_Click(null, null);
                            break;
                    }
                    break;
            }
            message = "Actions finished!";
            ACEManager.Log.AddLogLine(message);
            Console.WriteLine(message);
        }
    }
}
