using System;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;

namespace ACEManager
{
    public struct Config
    {
        /// <summary>
        /// Path to the ACE Server executable.
        /// </summary>
        [DefaultValue("..\\..\\..\\..\\Source\\ACEmulator\\Source\\ACE\\bin\\x64\\Debug\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AceServerPath { get; set; }

        /// <summary>
        /// Filename for the ACE Server executable.
        /// </summary>
        [DefaultValue("ACE.exe")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AceServerExecutable { get; set; }

        /// <summary>
        /// Arguments for launching the ACE Server executable.
        /// </summary>
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AceServerArguments { get; set; }

        /// <summary>
        /// Boolean to determine if saving log is required.
        /// </summary>
        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool SaveLogFile { get; set; }

        /// <summary>
        /// Path to the log folder, where logs are kept.
        /// </summary>
        [DefaultValue(@"ACEManagerLog_")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LocalLogPath { get; set; }

        /// <summary>
        /// Formatting for the line dates, in the log filename.
        /// </summary>
        [DefaultValue("yyyy-M-dd_HH-mm-ss")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LogFilenameDateFormat { get; set; }

        /// <summary>
        /// Formatting for the dates for each line, in the log file.
        /// </summary>
        [DefaultValue("yyyy-M-dd_HH-mm-ss.ffff")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LogLineDateFormat { get; set; }

        /// <summary>
        /// Boolean that determines if the server should be auto-restarted.
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool EnableAutoRestart { get; set; }

        /// <summary>
        /// Path to the Database repository. NOTE: May be overridden by a command line arguement.
        /// </summary>
        [DefaultValue("Database\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DataRepository { get; set; }

        /// <summary>
        /// Path to the Backup repository. NOTE: May be overridden by a command line arguement.
        /// </summary>
        [DefaultValue("Backups\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string BackupPath { get; set; }

        /// <summary>
        /// Have you reached advanced mode?
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool AdvancedMode { get; set; }

        /// <summary>
        /// Have you reached advanced mode?
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool HardModeReached { get; set; }

        /// <summary>
        /// Alerts have been had?
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool YouveBeenWarned { get; set; }

        /** Database Specific settings: **/

        /// <summary>
        ///  URL to the current ACE-World Git repository.
        /// </summary>
        [DefaultValue("https://api.github.com/repos/ACEmulator/ACE-World/releases/latest")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string GithubURL { get; set; }

        /// <summary>
        /// Database host address.
        /// </summary>
        [DefaultValue("127.0.0.1")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DatabaseHost { get; set; }

        /// <summary>
        /// Database Port Number (usually 3306)
        /// </summary>
        [DefaultValue(3306)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int DatabasePort { get; set; }

        /// <summary>
        /// Username for connecting to the database server.
        /// </summary>
        [DefaultValue("root")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DatabaseUsername { get; set; }

        /// <summary>
        /// Password for connecting to the database server.
        /// </summary>
        public string DatabasePassword { get; set; }

        /// <summary>
        /// Authenticaion Database Name.
        /// </summary>
        [DefaultValue("ace_auth")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthDatabaseName { get; set; }

        /// <summary>
        /// Shard Database Name.
        /// </summary>
        [DefaultValue("ace_shard")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardDatabaseName { get; set; }

        /// <summary>
        /// World Database Name.
        /// </summary>
        [DefaultValue("ace_world")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldDatabaseName { get; set; }

        /// <summary>
        /// Determines if the application should delete archives or not.
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool SaveOldWorldArchives { get; set; }

        /// <summary>
        /// Directory within the DataRepository that holds the database schema.
        /// </summary>
        [DefaultValue("Base\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string BaseSqlPath { get; set; }

        /// <summary>
        /// Directory within the DataRepository that holds the database updates.
        /// </summary>
        [DefaultValue("Updates\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string UpdatesSqlPath { get; set; }

        /// <summary>
        /// Directory within the UpdatesSqlPath, that holds the Authentication updates.
        /// </summary>
        [DefaultValue("Authentication\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationUpdatesPath { get; set; }

        /// <summary>
        /// Directory within the UpdatesSqlPath, that holds the Shard updates.
        /// </summary>
        [DefaultValue("Shard\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardUpdatesPath { get; set; }

        /// <summary>
        /// Directory within the UpdatesSqlPath, that holds the World updates.
        /// </summary>
        [DefaultValue("World\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldUpdatesPath { get; set; }

        /// <summary>
        /// Raw URL to current AuthenticationBase SQL file.
        /// </summary>
        [DefaultValue("https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/AuthenticationBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationBaseSqlUrl { get; set; }

        /// <summary>
        /// Raw URL to current Authentication Updates SQL file(s).
        /// </summary>
        [DefaultValue("https://api.github.com/repositories/79078680/contents/Database/Updates/Authentication")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationUpdatesSqlUrl { get; set; }

        /// <summary>
        /// Filename for the authentication database schema.
        /// </summary>
        [DefaultValue("AuthenticationBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationBaseSqlFilename { get; set; }

        /// <summary>
        /// Raw URL to current ShardBase SQL file.
        /// </summary>
        [DefaultValue("https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/ShardBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardBaseSqlUrl { get; set; }

        /// <summary>
        /// Raw URL to current Shard Updates SQL file(s).
        /// </summary>
        [DefaultValue("https://api.github.com/repositories/79078680/contents/Database/Updates/Shard")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardUpdatesSqlUrl { get; set; }

        /// <summary>
        /// Filename for the shard database schema.
        /// </summary>
        [DefaultValue("ShardBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardBaseSqlFilename { get; set; }

        /// <summary>
        /// Raw URL to current WorldBase SQL file.
        /// </summary>
        [DefaultValue("https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/WorldBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldBaseSqlUrl { get; set; }

        /// <summary>
        /// Raw URL to current Authentication World SQL file(s).
        /// </summary>
        [DefaultValue("https://api.github.com/repositories/79078680/contents/Database/Updates/World")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldUpdatesSqlUrl { get; set; }

        /// <summary>
        /// Filename for the World database schema.
        /// </summary>
        [DefaultValue("WorldBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldBaseSqlFilename { get; set; }

        /// <summary>
        /// Path to the file from wich the last authentication database backup was taken. May be empty if no backups have been taken.
        /// </summary>
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthLastBackupPath { get; set; }

        /// <summary>
        /// Path to the file from wich the last shard database backup was taken. May be empty if no backups have been taken.
        /// </summary>
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardLastBackupPath { get; set; }

        /// <summary>
        /// Path to the file from wich the last world database backup was taken. May be empty if no backups have been taken.
        /// </summary>
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldLastBackupPath { get; set; }

        /// <summary>
        /// Path to the last used userfile.
        /// </summary>
        public string UserFilePath { get; set; }
    }

    public static class ConfigManager
    {
        /// <summary>
        /// State Variable used to run the program.
        /// </summary>
        public static bool ConfigurationLoaded { get; private set; } = false;

        /// <summary>
        /// Local Path used for Loading Data into a Database
        /// </summary>
        public static string DataPath { get; private set; }

        /// <summary>
        /// Local Path used for Saving Data from a Database
        /// </summary>
        public static string BackupPath { get; private set; }

        /// <summary>
        /// Initial configuration upon starting the application.
        /// </summary>
        public static Config StartingConfiguration { get; set; }

        /// <summary>
        /// Path to the configuration file.
        /// </summary>
        public static string ConfigFilePath { get; private set; }

        /// <summary>
        /// Sets the Database Loading Path
        /// </summary>
        public static bool SetDataPath(string newPath)
        {
            if (newPath.Length > 0)
            {
                DataPath = Path.GetFullPath(newPath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the Database Saving Path
        /// </summary>
        public static bool SetBackupPath(string newPath)
        {
            if (newPath.Length > 0)
            {
                BackupPath = Path.GetFullPath(newPath);
                return true;
            }
            return false;
        }

        public static void ThrowConfigError(Exception exception)
        {
            var errMsg = $"An exception occured while loading the configuration file!{Environment.NewLine}Exception: {exception.Message}";
            Console.WriteLine(errMsg);
            ACEManager.Log.AddLogLine(errMsg);
        }

        public static void Initialize()
        {
            ConfigFilePath = @"Config.json";
            
            if (!File.Exists(ConfigFilePath))
            {
                ApplyDefaults();
                Save(StartingConfiguration);
            }
            else
            {
                // Testing to see if we can successfully convert data with json, from the config
                try
                {
                    StartingConfiguration = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigFilePath));
                }
                catch (Exception exception)
                {
                    if (ACEManager.Log != null)
                    {
                        ACEManager.Log.AddLogLine($"Config Load Error: { exception.Message}");
                    }
                    // Allow this to be sent to console, as a command line failure incase log cannot be saved
                    ThrowConfigError(exception);
                    throw;
                }
                finally
                {
                    ConfigurationLoaded = true;
                }

                // Testing to see if we can save data in the path saved in the config
                if (StartingConfiguration.DataRepository.Length > 0)
                {
                    // test if directory is exists
                    if (!Directory.Exists(Path.GetFullPath(StartingConfiguration.DataRepository)))
                    {
                        string newPath = Path.GetFullPath(StartingConfiguration.DataRepository);

                        if (ACEManager.Log != null)
                        {
                            ACEManager.Log.AddLogLine($"Config Load Error: Invalid DataRepository Path in config! {newPath} is invalid.");
                        }
                    }
                    // Directory exists, now we test permissions
                    else
                    {
                        string absolutePath = "";
                        try
                        {
                            absolutePath = Path.GetFullPath(StartingConfiguration.DataRepository);
                        }
                        catch (Exception exception)
                        {
                            if (ACEManager.Log != null)
                            {
                                ACEManager.Log.AddLogLine($"Config Load Error: { exception.Message}");
                            }
                            ConfigurationLoaded = false;
                            ThrowConfigError(exception);
                            throw;
                        }
                        finally
                        {
                            // exists, can we write?
                            PermissionSet perms = new PermissionSet(PermissionState.None);
                            FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, absolutePath);
                            perms.AddPermission(writePermission);

                            if (!perms.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
                            {
                                // You don't have write permissions
                                Console.WriteLine("Could not load or create the data directory, cannot write too the directory!");
                                ConfigurationLoaded = false;
                            }
                            else
                            {
                                DataPath = absolutePath;
                            }
                        }
                    }
                }
                else
                {
                    Exception exception = new Exception("Config Error: Invalid Path!");
                    ThrowConfigError(exception);
                    ConfigurationLoaded = false;
                }
            }
        }

        /// <summary>
        /// Initialize data for missing configs.
        /// </summary>
        public static void ApplyDefaults()
        {
            StartingConfiguration = new Config() {
                AceServerPath = "%SYSTEMROOT%//ACEmulator//",
                AceServerExecutable = "ACE.exe",
                AceServerArguments = string.Empty,
                AdvancedMode = false,
                AuthDatabaseName = "ace_auth",
                AuthenticationBaseSqlFilename = "AuthenticationBase.sql",
                AuthenticationBaseSqlUrl = "https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/AuthenticationBase.sql",
                AuthenticationUpdatesPath = "Updates\\Authentication\\",
                AuthenticationUpdatesSqlUrl = "https://api.github.com/repositories/79078680/contents/Database/Updates/Authentication",
                AuthLastBackupPath = string.Empty,
                BackupPath = "Backups\\",
                BaseSqlPath = "Base\\",
                DatabaseHost = "127.0.0.1",
                DatabasePassword = "",
                DatabasePort = 3306,
                DatabaseUsername = "root",
                DataRepository = "Database\\",
                EnableAutoRestart = false,
                GithubURL = "https://api.github.com/repos/ACEmulator/ACE-World/releases/latest",
                UpdatesSqlPath = "Updates\\",
                SaveOldWorldArchives = false,
                ShardBaseSqlFilename = "ShardBase.sql",
                ShardBaseSqlUrl = "https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/ShardBase.sql",
                ShardDatabaseName = "ace_shard",
                ShardUpdatesPath = "Updates\\Shard\\",
                ShardUpdatesSqlUrl = "https://api.github.com/repositories/79078680/contents/Database/Updates/Shard",
                ShardLastBackupPath = string.Empty,
                WorldBaseSqlFilename = "WorldBase.sql",
                WorldBaseSqlUrl = "https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/WorldBase.sql",
                WorldDatabaseName = "ace_world",
                WorldUpdatesPath = "Updates\\World\\",
                WorldUpdatesSqlUrl = "https://api.github.com/repositories/79078680/contents/Database/Updates/World",
                WorldLastBackupPath = string.Empty,
                SaveLogFile = true,
                LocalLogPath = @"ACEManagerLog_",
                LogLineDateFormat = "yyyy-M-dd_HH-mm-ss.ffff",
                LogFilenameDateFormat = "yyyy-M-dd_HH-mm-ss" };
            ConfigurationLoaded = true;
        }

        /// <summary>
        /// Saves a configuration into the ConfigFilePath value.
        /// </summary>
        /// <param name="newConfig"></param>
        public static void Save(Config newConfig)
        {
            try
            {
                File.WriteAllText(ConfigFilePath, JsonConvert.SerializeObject(newConfig, Formatting.Indented));
            }
            catch (Exception exception)
            {
                if (ACEManager.Log != null)
                {
                    ACEManager.Log.AddLogLine($"Config Load Error: { exception.Message}");
                }
                Console.WriteLine("An exception occured while saving the configuration file!");
                Console.WriteLine($"Exception: {exception.Message}");
                throw;
            }
        }
    }
}