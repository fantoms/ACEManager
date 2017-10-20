using Plossum.CommandLine;
using System;

namespace ACEManager
{
    public enum CommandLineAction
    {
        // NOT DANGEROUS:
        DoNothing = 0,
        DownloadFromGithub = 1,
        Backup = 2,
        // LESS DANGEROUS, DOES OVERWRITE ACTIVE DATA ON SERVER:
        LoadFromLastBackup = 3,
        // MORE DANGEROUS FUNCTs, BECAUSE WE HAVE A BACKUPS, WILL OVERWRITE DATA:
        BackupLoadWorldUpdates = 4,
        DownloadBackupReset = 5,
        // MOST DANGEROUS, CAN LOSE DATA (NO BACKUPS):
        DownloadReset = 6,
        LoadWorldUpdates = 7,
        Reset = 8
    }

    /// <summary>
    /// Command line options used too change the opperations and behavior of this application.
    /// </summary>
    [CommandLineManager(ApplicationName = "ACEManager")]
    public class Options
    {
        [CommandLineOption(Description = "Data path to load Database files FROM.", Name = "dp", Aliases = "set-data-path")]
        public string DataPath { get; set; }

        [CommandLineOption(Description = "Backup path to save Database files IN.", Name = "bp", Aliases = "set-backup-path")]
        public string BackupPath { get; set; }

        [CommandLineOption(Description = "Database Selection, default is 0. Make sure you select a value between 1 and 4. 1 = Authentication, 2 = Shard, 3 = World, 4 = All.",
            MinValue = 0, MaxValue = 4, Name = "d", Aliases = "database", DefaultAssignmentValue = 0, RequireExplicitAssignment = true)]
        public int DatabaseID { get; set; }

        [CommandLineOption(Description = "Actions are a fickle beast, do not attempt to riegn the dragon from the command line. Check the docuementation - thanks!",
            MinValue = 0, MaxValue = 8, Name = "a", Aliases = "action", DefaultAssignmentValue = 0, RequireExplicitAssignment = true)]
        public int ActionID { get; set; }

        public CommandLineAction ActionToPerform
        {
            get { return (CommandLineAction)ActionID; }
            private set
            {
                if (Enum.IsDefined(typeof(CommandLineAction), value))
                {
                    ActionID = (int)value;
                }
                else
                    ActionID = (int)CommandLineAction.DoNothing;
            }
        }

        public DefaultACEDatabase DatabaseName
        {
            get { return (DefaultACEDatabase)DatabaseID; }
            private set
            {
                if (Enum.IsDefined(typeof(DefaultACEDatabase), value))
                {
                    DatabaseID = (int)value;
                }
                else
                    DatabaseID = (int)DefaultACEDatabase.None;
            }
        }
    }
}
