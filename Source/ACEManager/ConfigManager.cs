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
        [DefaultValue("..\\..\\..\\..\\Source\\ACEmulator\\Source\\ACE\\bin\\x64\\Debug\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AceServerPath { get; set; }

        [DefaultValue("ACE.exe")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AceServerExecutable { get; set; }

        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AceServerArguments { get; set; }

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool SaveLogFile { get; set; }

        [DefaultValue(@"ACEManagerLog_")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LocalLogPath { get; set; }

        [DefaultValue("yyyy-M-dd_HH-mm-ss")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LogFilenameFormat { get; set; }

        [DefaultValue("yyyy-M-dd_HH-mm-ss.ffff")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LogDataFormat { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool EnableAutoRestart { get; set; }

        [DefaultValue("127.0.0.1")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DatabaseHost { get; set; }

        [DefaultValue(3306)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int DatabasePort { get; set; }

        [DefaultValue("root")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DatabaseUsername { get; set; }

        public string DatabasePassword { get; set; }

        [DefaultValue("ace_auth")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthDatabaseName { get; set; }

        [DefaultValue("ace_shard")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardDatabaseName { get; set; }

        [DefaultValue("ace_world")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldDatabaseName { get; set; }

        [DefaultValue("Database\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DataRepository { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool AdvancedMode { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool SaveOldWorldArchives { get; set; }

        [DefaultValue("Base\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string BaseSqlPath { get; set; }

        [DefaultValue("Updates\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string UpdatesSqlPath { get; set; }

        [DefaultValue("Authentication\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationUpdatesPath { get; set; }

        [DefaultValue("Shard\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardUpdatesPath { get; set; }

        [DefaultValue("World\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldUpdatesPath { get; set; }

        /// <summary>
        ///  URL to the current ACE-World Git repository.
        /// </summary>
        [DefaultValue("https://api.github.com/repos/ACEmulator/ACE-World/releases/latest")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string GithubURL { get; set; }

        /// <summary>
        /// Raw URL to current AuthenticationBase SQL file.
        /// </summary>
        [DefaultValue("https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/AuthenticationBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationBaseSqlUrl { get; set; }

        [DefaultValue("https://api.github.com/repositories/79078680/contents/Database/Updates/Authentication")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationUpdatesSqlUrl { get; set; }

        [DefaultValue("AuthenticationBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthenticationBaseSqlFilename { get; set; }

        /// <summary>
        /// Raw URL to current ShardBase SQL file.
        /// </summary>
        [DefaultValue("https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/ShardBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardBaseSqlUrl { get; set; }

        [DefaultValue("https://api.github.com/repositories/79078680/contents/Database/Updates/Shard")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardUpdatesSqlUrl { get; set; }

        [DefaultValue("ShardBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardBaseSqlFilename { get; set; }

        /// <summary>
        /// Raw URL to current WorldBase SQL file.
        /// </summary>
        [DefaultValue("https://raw.githubusercontent.com/ACEmulator/ACE/master/Database/Base/WorldBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldBaseSqlUrl { get; set; }

        [DefaultValue("https://api.github.com/repositories/79078680/contents/Database/Updates/World")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldUpdatesSqlUrl { get; set; }

        [DefaultValue("WorldBase.sql")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldBaseSqlFilename { get; set; }

        [DefaultValue("Backups\\")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string BackupPath { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool HardModeReached { get; set; }

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool YouveBeenWarned { get; set; }

        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string AuthLastBackupPath { get; set; }

        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ShardLastBackupPath { get; set; }

        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string WorldLastBackupPath { get; set; }
    }

    public static class ConfigManager
    {
        public static bool ConfigurationLoaded { get; set; } = false;
        public static bool DataPathAvailable { get; set; } = false;
        public static string DataPath { get; private set; }
        public static string BackupPath { get; private set; }
        public static Config StartingConfiguration { get; set; }

        public static string ConfigFile { get; private set; }

        public static bool SetDataPath(string newPath)
        {
            if (newPath.Length > 0)
            {
                DataPath = Path.GetFullPath(newPath);
                return true;
            }
            return false;
        }

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
            ConfigFile = @"Config.json";
            
            if (!File.Exists(ConfigFile))
            {
                ApplyDefaults();
                Save(StartingConfiguration);
            }
            else
            {
                // Testing to see if we can successfully convert data with json, from the config
                try
                {
                    StartingConfiguration = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigFile));
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

                        DataPathAvailable = false;
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
                                DataPathAvailable = false;
                            }
                            else
                            {
                                DataPath = absolutePath;
                                DataPathAvailable = true;
                            }
                        }
                    }
                }
                else
                {
                    Exception exception = new Exception("Config Error: Invalid Path!");
                    ThrowConfigError(exception);
                    DataPathAvailable = false;
                    ConfigurationLoaded = false;
                }
            }
        }

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
                LogDataFormat = "yyyy-M-dd_HH-mm-ss.ffff",
                LogFilenameFormat = "yyyy-M-dd_HH-mm-ss" };
            ConfigurationLoaded = true;
        }

        public static void Save(Config newConfig)
        {
            try
            {
                File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(newConfig, Formatting.Indented));
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