using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.IO.Compression;
using MySql.Data.MySqlClient;
using System.Security;
using System.Security.Permissions;
using System.Collections.ObjectModel;

namespace ACEManager
{
    public partial class DatabaseMaintenanceForm : Form
    {
        /// <summary>
        /// Url to download the latest version of ACE-World.
        /// </summary>
        private string GithubDownload { get; set; }

        /// <summary>
        /// Url to download the latest version of ACE-World.
        /// </summary>
        private string GithubFilename { get; set; }

        /// <summary>
        /// Latest Name of the ACE-World
        /// </summary>
        private string GithubName { get; set; }

        /// <summary>
        /// Latest Tag Name of the ACE-World
        /// </summary>
        private string GithubTag { get; set; }

        /// <summary>
        /// Date of publish for the latest ACE-World release
        /// </summary>
        private string GithubDate { get; set; }

        /// <summary>
        /// Error information from the database.
        /// </summary>
        public static string ErrorResult { get; private set; }

        private static bool DisableWarnings { get; set; }

        private static readonly ReadOnlyCollection<string> DefaultDbNames = new ReadOnlyCollection<string>(new[] { "ace_auth", "ace_shard", "ace_world" });

        public DatabaseMaintenanceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is an event delegate for use with the Database class to receieve Errors from the Database.
        /// </summary>
        public void Database_MySqlError(object sender, MySqlScriptErrorEventArgs e)
        {
            ErrorResult = e.Exception.Message;
            LogText("Error in script:" + ErrorResult);
        }

        /// <summary>
        /// This is an event delegate for use with the Database class to show Lame Progress from the Database.
        /// </summary>
        public void Database_StatementExecuted(object sender, MySqlScriptEventArgs e)
        {
            LogText("Loading...");
        }

        /// <summary>
        /// This is an event delegate for use with the Database class to report when the functions have fininished.
        /// </summary>
        public void Database_StatementCompleted(object sender, EventArgs e)
        {
            LogText("Scripts completed!");
        }

        private void DatabaseMaintenanceForm_Load(object sender, EventArgs e)
        {
            if (!ACEManager.Config.YouveBeenWarned)
            {
                if (!YouveBeenWarned())
                {
                    this.Close();
                    return;
                }
            }
            PopulateFormControls();
        }

        /// <summary>
        /// Loads in the initial settings from configuration.
        /// </summary>
        public void PopulateFormControls()
        {
            if (ACEManager.Config.AdvancedMode == true)
            {
                chkBxAdvanced.Checked = true;
            }
            txtBxDBAuthName.Text = ACEManager.Config.AuthDatabaseName;
            txtBxDBShardName.Text = ACEManager.Config.ShardDatabaseName;
            txtBxDBWorldName.Text = ACEManager.Config.WorldDatabaseName;
        }

        /// <summary>
        /// Retrieves the latest zip file from Github. Make sure the GithubUrl is set!
        /// </summary>
        private void GetLatestACEWorldData()
        {
            GetWebContent(GithubDownload, Path.Combine(ConfigManager.DataPath, GithubFilename));
        }

        /// <summary>
        /// Retrieves the latest Database Schemas from Github.
        /// </summary>
        private void GetBaseSql()
        {
            GetWebContent(ACEManager.Config.AuthenticationBaseSqlUrl, Path.GetFullPath(Path.Combine(ConfigManager.DataPath, ACEManager.Config.BaseSqlPath, ACEManager.Config.AuthenticationBaseSqlFilename)));
            GetWebContent(ACEManager.Config.ShardBaseSqlUrl, Path.GetFullPath(Path.Combine(ConfigManager.DataPath, ACEManager.Config.BaseSqlPath, ACEManager.Config.ShardBaseSqlFilename)));
            GetWebContent(ACEManager.Config.WorldBaseSqlUrl, Path.GetFullPath(Path.Combine(ConfigManager.DataPath, ACEManager.Config.BaseSqlPath, ACEManager.Config.WorldBaseSqlFilename)));
        }

        /// <summary>
        /// Retrieves the latest Updates from Github.
        /// </summary>
        private void GetAllUpdates()
        {
            // Create missing folders, if needed.
            if (!CheckBackupPath())
            {
                LogText("Error in data repository, click download data again!");
                return;
            }

            var authfiles = JArray.Parse(GetWebString(ACEManager.Config.AuthenticationUpdatesSqlUrl));
            foreach (var item in authfiles)
            {
                GetWebContent(item["download_url"].ToString(), Path.Combine(ConfigManager.DataPath, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.AuthenticationUpdatesPath, item["name"].ToString()));
            }
            var shardfiles = JArray.Parse(GetWebString(ACEManager.Config.ShardUpdatesSqlUrl));
            foreach (var item in shardfiles)
            {
                GetWebContent(item["download_url"].ToString(), Path.Combine(ConfigManager.DataPath, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.ShardUpdatesPath, item["name"].ToString()));
            }
            var worldfiles = JArray.Parse(GetWebString(ACEManager.Config.WorldUpdatesSqlUrl));
            foreach (var item in worldfiles)
            {
                GetWebContent(item["download_url"].ToString(), Path.Combine(ConfigManager.DataPath, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.WorldUpdatesPath, item["name"].ToString()));
            }
        }

        /// <summary>
        /// Creates a webClient that connects too Github and extracts relevant download metadata.
        /// </summary>
        private void GetACEWorldMetaData()
        {
            // attempt to download the latest ACE-World json data
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    WebClient w = new WebClient();
                    // Header is required for github
                    w.Headers.Add("User-Agent", "ACEManager");
                    var json = JObject.Parse(w.DownloadString(ACEManager.Config.GithubURL));
                    // Extract relevant details
                    GithubDownload = (string)json["assets"][0]["browser_download_url"];
                    GithubName = (string)json["name"];
                    GithubTag = (string)json["tag_name"];
                    GithubDate = (string)json["published_at"];
                    GithubFilename = (string)json["assets"][0]["name"];
                }
            }
            catch (Exception error)
            {
                LogText(error.Message);
            }
        }

        /// <summary>
        /// Saves the current text for the text box, present in this form.
        /// </summary>
        private void SaveSettings()
        {
            ACEManager.Config.AdvancedMode = chkBxAdvanced.Checked;
            ACEManager.Config.AuthDatabaseName = txtBxDBAuthName.Text;
            ACEManager.Config.ShardDatabaseName = txtBxDBShardName.Text;
            ACEManager.Config.WorldDatabaseName = txtBxDBWorldName.Text;
            ConfigManager.Save(ACEManager.Config);
        }

        /// <summary>
        /// Retreieves a string from a web location.
        /// </summary>
        private string GetWebString(string updateUrl)
        {
            LogText($"Remote: {updateUrl}");
            LogText("Downloading...");
            string result = "";
            // attempt to download the latest ACE-World json data
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    WebClient w = new WebClient();
                    // Header is required for github
                    w.Headers.Add("User-Agent", "ACEManager");
                    result = w.DownloadString(updateUrl);
                }
            }
            catch (Exception error)
            {
                LogText(error.Message);
            }
            return result;
        }

        /// <summary>
        /// Retreives a file from a web location.
        /// </summary>
        private bool GetWebContent(string url, string destinationFilePath)
        {
            LogText($"Remote: {url} Local: {destinationFilePath}");
            LogText("Downloading...");
            // attempt to download the latest ACE-World json data
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    WebClient w = new WebClient();
                    // Header is required for github
                    w.Headers.Add("User-Agent", "ACEManager");
                    w.DownloadFile(url, destinationFilePath);
                }
            }
            catch (Exception error)
            {
                LogText(error.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Attempts to create a database, with a name collected a Form Textbox.
        /// </summary>
        private bool CreateDatabase(string databaseName)
        {
            LogText($"Creating database {databaseName}...");
            // Allow user to cancel:
            if (WarnUser("This will create a new database named `" + databaseName + "`, if the database name does not exist!") == false)
            {
                LogText("Canceled action!");
                return false;
            }
            // Database.Reset();
            var dbQuery = "CREATE DATABASE IF NOT EXISTS `" + databaseName + "` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
            var result = Database.ExecuteQuery(dbQuery, "");
            if (result.Length > 0)
            {
                LogText(result);
            }
            return true;
        }

        /// <summary>
        /// Attempts to Drop a database, with a name collected a Form Textbox.
        /// </summary>
        private bool DropDatabase(string databaseName)
        {
            LogText($"DELETING database {databaseName}...");
            // Allow user to cancel:
            if (WarnUser("This will DROP / REMOVE / DELETE a database named `" + databaseName + "`, if the database exists!") == false)
            {
                LogText("Canceled action!");
                return false;
            }

            var dbQuery = "DROP DATABASE IF EXISTS `" + databaseName + "`;";
            var result = Database.ExecuteQuery(dbQuery, databaseName);
            if (result.Length > 0)
            {
                LogText(result);
            }
            return true;
        }

        /// <summary>
        /// Attempts to Load base database schema, with a name collected a Form Textbox.
        /// </summary>
        private bool LoadBase(string databaseName, string baseFilename)
        {
            LogText($"Loading base for {databaseName}...");
            if (WarnUser($"This will load the BASE schema for the `{databaseName}` database") == false)
            {
                LogText("Canceled action!");
                return false;
            }
            var sqlFile = Path.Combine(ConfigManager.DataPath, ACEManager.Config.BaseSqlPath, baseFilename);
            // find the base file:
            if (!File.Exists(sqlFile))
            {
                LogText($"Cannot locate the {baseFilename} Base SQL file, please click download!");
            }
            else
            {
                // open fild into string
                string sqlInputFile = File.ReadAllText(sqlFile);
                if (!DefaultDbNames.Contains(databaseName))
                    if (DefaultDbNames.Any(sqlInputFile.Contains))
                    {
                        sqlInputFile = sqlInputFile.Replace("ace_auth", databaseName);
                        sqlInputFile = sqlInputFile.Replace("ace_shard", databaseName);
                        sqlInputFile = sqlInputFile.Replace("ace_world", databaseName);
                    }
                var result = Database.ExecuteQuery(sqlInputFile, databaseName);

                if (result.Length > 0)
                {
                    LogText(result);
                }
            }
            return true;
        }

        /// <summary>
        /// Attempts to Load all updates present from a directory, into a name database with the name collected from a Form Textbox.
        /// </summary>
        private bool LoadUpdates(string databaseName, string updatePath)
        {
            LogText($"Loading updates for {databaseName}...");
            if (WarnUser($"This will load UPDATES for the `{databaseName}` database") == false)
            {
                LogText("Canceled action!");
                return false;
            }
            // Database.Reset();
            try
            {
                var updateRepo = Path.Combine(ConfigManager.DataPath, ACEManager.Config.UpdatesSqlPath, updatePath);
                var files = from file in Directory.EnumerateFiles(updateRepo) where !file.Contains(".txt") select new { File = file };

                if (files.Count() == 0)
                {
                    LogText("No updates for this database are available.");
                    // not a failure, just no updates
                    return true;
                }
                else
                {
                    LogText($"Found {files.Count()}");
                }

                foreach (var file in files)
                {
                    var sqlFile = file.File;
                    // find the base file:
                    if (!File.Exists(sqlFile))
                    {
                        LogText($"Cannot locate any updates for {updateRepo}, please click download!");
                        return false;
                    }
                    else
                    {
                        // open fild into string
                        string sqlInputFile = File.ReadAllText(sqlFile);
                        if (!DefaultDbNames.Contains(databaseName))
                            if (DefaultDbNames.Any(sqlInputFile.Contains))
                            {
                                sqlInputFile = sqlInputFile.Replace("ace_auth", databaseName);
                                sqlInputFile = sqlInputFile.Replace("ace_shard", databaseName);
                                sqlInputFile = sqlInputFile.Replace("ace_world", databaseName);
                            }
                        var result = Database.ExecuteScript(sqlInputFile, databaseName);
                        if (result.Length > 0)
                        {
                            LogText(result);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                LogText(error.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Attempts to Load all world data present from a directory, into a name database with the name collected from a Form Textbox.
        /// </summary>
        private bool LoadWorld()
        {
            LogText($"Loading ACE-World!");
            // Allow user to cancel:
            if (WarnUser("This will reset your world, if the database exists!") == false)
            {
                LogText("Canceled action!");
                return false;
            }
            string databaseName;
            if (txtBxDBWorldName.TextLength > 0)
            {
                databaseName = txtBxDBWorldName.Text;
            }
            else
            {
                return false;
            }

            try
            {
                var updateRepo = Path.Combine(ConfigManager.DataPath, "ACE-World\\");
                var files = from file in Directory.EnumerateFiles(updateRepo) where !file.Contains(".txt") select new { File = file };
                foreach (var file in files)
                {
                    string sqlFile = file.File;
                    // find the base file:
                    if (!File.Exists(sqlFile))
                    {
                        LogText($"Cannot locate ACE-World Data, please click download!");
                        return false;
                    }
                    else
                    {
                        // open fild into string
                        LogText("Loading ACE-World, may take quite awhile (please wait)!...");
                        string sqlInputFile = File.ReadAllText(sqlFile);
                        if (!DefaultDbNames.Contains(databaseName))
                            if (DefaultDbNames.Any(sqlInputFile.Contains))
                            {
                                sqlInputFile = sqlInputFile.Replace("ace_world", databaseName);
                            }
                        var result = Database.ExecuteScript(sqlInputFile, databaseName);
                        if (result.Length > 0)
                        {
                            LogText(result);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                LogText(error.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Attempts to extract a file from a directory, into a relative path. If ACEManager.Config.SaveOldWorldArchives is false, then the archive will also be deleted.
        /// </summary>
        private void ExtractZip(string filePath, string destinationPath)
        {
            LogText($"Extracting Zip {filePath}...");
            if (Directory.Exists(destinationPath)) Directory.Delete(destinationPath, true);
            Directory.CreateDirectory(destinationPath);
            if (!File.Exists(filePath))
            {
                LogText("ERROR: Zip missing!");
                return;
            }

            try
            {
                ZipFile.ExtractToDirectory(filePath, destinationPath);
            }
            catch (Exception error)
            {
                LogText(error.Message);
                return;
            }
            finally
            {
                // delete the zip to save space
                if (!ACEManager.Config.SaveOldWorldArchives)
                {
                    LogText($"Deleting archive {filePath}");
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// Saves the text to screen and the LameLog object.
        /// </summary>
        /// <param name="message">String containing message to log.</param>
        public void LogText(string message)
        {
            var logData = Environment.NewLine + message;
            ACEManager.Log.AddLogLine(message);
            txtBxDBLog.AppendText(logData);
        }

        /// <summary>
        /// Initial Warning Message that let's users know this tool is dangerous.
        /// </summary>
        /// <returns>true if user acces, false if user denies</returns>
        private bool YouveBeenWarned()
        {
            string message = "This software is in an experimental stage. If you use this, note that there is a chance your database will be lost or broken.\nIf this does not suite your taste, please wait until proper testing can be performed and do not use this product.";
            if (WarnUser(message))
            {
                ACEManager.Config.YouveBeenWarned = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Initial Warning Message that let's users know ADVANCED MODE IS THWARGLEY.
        /// </summary>
        private bool HardMode()
        {
            string message = "This software is in an experimental stage. If you use this, note that there is a chance your database will be lost or broken.\nYou've chosen to turn on the advanced settings, so please note that you can break your database with the wrong click!";
            if (WarnUser(message))
            {
                ACEManager.Config.HardModeReached = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Presents a hairy dialog warning that will let users accept or deny various warning messages.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool WarnUser(string message = "")
        {
            if (DisableWarnings) return true;
            var result = MessageBox.Show("WARNING! You are about to change one or more databases and/or overwrite files:-\n\n" + (message.Length > 0 ? message + "\n\n" : string.Empty) + "Are you certain that you want too proceed?!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (result == DialogResult.Yes || result == DialogResult.OK)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks the backup path from the config and creates folders when necessary. NOTE: Config may be overridden by a command Line Paramenter.
        /// </summary>
        private bool CheckBackupPath()
        {
            string backupRepository;
            if (ACEManager.Config.BackupPath?.Length > 0)
            {
                backupRepository = Path.GetFullPath(ACEManager.Config.BackupPath);
            }
            else
                backupRepository = "";

            // Testing to see if we can save data in the path saved in the config
            if (backupRepository?.Length > 0)
            {
                // test if directory is exists
                if (!Directory.Exists(backupRepository))
                {
                    LogText($"Creating backup directory: {backupRepository}");
                    Directory.CreateDirectory(backupRepository);
                }
                else
                {
                    string absolutePath = Path.GetFullPath(backupRepository);
                    // exists, can we write?
                    PermissionSet perms = new PermissionSet(PermissionState.None);
                    FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, absolutePath);
                    perms.AddPermission(writePermission);
                    if (!perms.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
                    {
                        // You don't have write permissions
                        LogText("Could not load or create the data directory, cannot write too the directory!");
                        return false;
                    }
                }
            }
            else
            {
                LogText("Config Error: Invalid Path!");
                return false;
            }
            // finally set the path and return success (true)
            // this means, the path exists and we can write too it
            ConfigManager.SetBackupPath(backupRepository);
            return true;
        }

        /// <summary>
        /// Checks the data path from the config and creates folders when necessary. NOTE: Config may be overridden by a command Line Paramenter.
        /// </summary>
        private bool CheckDataPath()
        {
            if (ConfigManager.DataPath == null && ACEManager.Config.DataRepository?.Length > 0)
            {
                ConfigManager.SetDataPath(ACEManager.Config.DataRepository);
            }

            string dataRepository = ConfigManager.DataPath;
            // Testing to see if we can save data in the path saved in the config
            if (dataRepository?.Length > 0)
            {
                CreateDataFolders(dataRepository);
                string absolutePath = Path.GetFullPath(dataRepository);
                // exists, can we write?
                PermissionSet perms = new PermissionSet(PermissionState.None);
                FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, absolutePath);
                perms.AddPermission(writePermission);
                if (!perms.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
                {
                    // You don't have write permissions
                    LogText("Could not load or create the data directory, cannot write too the directory!");
                    return false;
                }
            }
            else
            {
                LogText("Config Error: Invalid Path!");
                return false;
            }
            return true;
        }

        private void CreateDataFolders(string dataRepository)
        {
            if (!Directory.Exists(dataRepository)) Directory.CreateDirectory(dataRepository);
            if (!Directory.Exists(Path.Combine(dataRepository, ACEManager.Config.BaseSqlPath))) Directory.CreateDirectory(Path.Combine(dataRepository, ACEManager.Config.BaseSqlPath));
            if (!Directory.Exists(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath))) Directory.CreateDirectory(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath));
            if (!Directory.Exists(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.AuthenticationUpdatesPath))) Directory.CreateDirectory(Path.GetFullPath(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.AuthenticationUpdatesPath)));
            if (!Directory.Exists(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.ShardUpdatesPath))) Directory.CreateDirectory(Path.GetFullPath(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.ShardUpdatesPath)));
            if (!Directory.Exists(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.WorldUpdatesPath))) Directory.CreateDirectory(Path.GetFullPath(Path.Combine(dataRepository, ACEManager.Config.UpdatesSqlPath, ACEManager.Config.WorldUpdatesPath)));
        }

        private bool DownloadUpdates()
        {
            LogText("Downloading all data from github...");
            if (CheckDataPath())
            {
                try
                {
                    GetACEWorldMetaData();
                    GetLatestACEWorldData();
                    GetBaseSql();
                    GetAllUpdates();
                    ExtractZip(Path.Combine(ConfigManager.DataPath, GithubFilename), Path.Combine(ConfigManager.DataPath, "ACE-World\\"));
                }
                catch (Exception error)
                {
                    LogText(error.Message);
                    return false;
                }
                return true;
            }
            else
            {
                LogText($"Error! Could not download into {ACEManager.Config.DataRepository}");
                return false;
            }
        }

        private bool ClearDatabase(string databaseName, bool disableWarnings)
        {
            // Warn user
            if (!disableWarnings)
            {
                LogText($"Clearing {databaseName}...");
                // Allow user to cancel:
                if (WarnUser("This will CLEAR / TRUNCATE `" + databaseName + "` tables, if any exist!") == false)
                {
                    LogText("Canceled action!");
                    return false;
                }
            }

            string result = Database.TruncateTables(databaseName);
            if (result.Length > 0)
            {
                LogText(result);
            }

            if (!disableWarnings)
                DisableWarnings = false;
            return true;
        }

        private bool BackupDatabase(string databaseName, int defaultDatabase)
        {
            // Check the Backup dirctory permission
            if (!CheckBackupPath()) return false;
            var newFilePath = Path.GetFullPath(Path.Combine(ConfigManager.BackupPath, databaseName + "." + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + ".sqldump"));
            var result = Database.ExecuteBackup(newFilePath, databaseName);
            if (result.Length > 0)
            {
                LogText(result);
                switch (defaultDatabase)
                {
                    case (int)DefaultACEDatabase.Authentication:
                        ACEManager.Config.AuthLastBackupPath = newFilePath;
                        break;
                    case (int)DefaultACEDatabase.Shard:
                        ACEManager.Config.ShardLastBackupPath = newFilePath;
                        break;
                    case (int)DefaultACEDatabase.World:
                        ACEManager.Config.WorldLastBackupPath = newFilePath;
                        break;
                    default:
                        Console.WriteLine("Error in switch statement!");
                        return false;
                }
                ConfigManager.Save(ACEManager.Config);
            }
            return true;
        }

        private bool RestoreDatabase(string restorePath, string databaseName, bool disableWarnings)
        {
            if (!disableWarnings)
            {
                // Allow user to cancel:
                if (WarnUser("This will reset `" + databaseName + "`, if the database exists!") == false)
                {
                    LogText("Canceled action!");
                    return false;
                }
            }
            // Check the Backup dirctory permission
            if (!CheckBackupPath()) return false;
            var result = Database.ExecuteRestore(restorePath, databaseName);
            if (result.Length > 0)
            {
                LogText(result);
            }
            return true;
        }

        private bool ResetAuth(string databaseName, bool disableWarnings)
        {
            if (!disableWarnings)
            {
                LogText($"Resetting {databaseName}...");
                // Allow user to cancel:
                if (WarnUser("This will reset `" + databaseName + "`, if the database exists!") == false)
                {
                    LogText("Canceled action!");
                    return false;
                }
                DisableWarnings = true;
            }
            if (!DropDatabase(databaseName)) return false;
            if (!CreateDatabase(databaseName)) return false;
            if (!LoadBase(databaseName, ACEManager.Config.AuthenticationBaseSqlFilename)) return false;
            if (!LoadUpdates(databaseName, ACEManager.Config.AuthenticationUpdatesPath)) return false;
            if (!disableWarnings)
                DisableWarnings = false;
            return true;
        }

        private bool ResetShard(string databaseName, bool disableWarnings)
        {
            if (!disableWarnings)
            {
                LogText($"Resetting {databaseName}...");
                // Allow user to cancel:
                if (WarnUser("This will reset `" + databaseName + "`, if the database exists!") == false)
                {
                    LogText("Canceled action!");
                    return false;
                }
                DisableWarnings = true;
            }
            if (!DropDatabase(databaseName)) return false;
            if (!CreateDatabase(databaseName)) return false;
            if (!LoadBase(databaseName, ACEManager.Config.ShardBaseSqlFilename)) return false;
            if (!LoadUpdates(databaseName, ACEManager.Config.ShardUpdatesPath)) return false;
            if (!disableWarnings)
                DisableWarnings = false;
            return true;
        }

        private bool ResetWorld(string databaseName, bool disableWarnings)
        {
            if (!disableWarnings)
            {
                LogText($"Resetting {databaseName}...");
                // Allow user to cancel:
                if (WarnUser("This will reset `" + databaseName + "`, if the database exists!") == false)
                {
                    LogText("Canceled action!");
                    return false;
                }
                DisableWarnings = true;
            }
            if (!DropDatabase(databaseName)) return false;
            if (!CreateDatabase(databaseName)) return false;
            if (!LoadBase(databaseName, ACEManager.Config.WorldBaseSqlFilename)) return false;
            if (!LoadWorld()) return false;
            if (!LoadUpdates(databaseName, ACEManager.Config.WorldUpdatesPath)) return false;
            if (!disableWarnings)
                DisableWarnings = false;
            return true;
        }

        private void DisableButtons()
        {
            btnAuthUpdates.Enabled = false;
            btnBackupAuth.Enabled = false;
            btnBackupShard.Enabled = false;
            btnBackupWorld.Enabled = false;
            btnClearAuthData.Enabled = false;
            btnClearShardData.Enabled = false;
            btnClearWorldData.Enabled = false;
            btnCreateAuthDB.Enabled = false;
            btnCreateShard.Enabled = false;
            btnCreateWorldDB.Enabled = false;
            btnDownloadAllData.Enabled = false;
            btnDropAuthDB.Enabled = false;
            btnDropShardDB.Enabled = false;
            btnDropWorldDB.Enabled = false;
            btnLoadAnAuthBackup.Enabled = false;
            btnLoadAShardBacup.Enabled = false;
            btnLoadAuthBackup.Enabled = false;
            btnLoadAuthBase.Enabled = false;
            btnLoadAWorldBackup.Enabled = false;
            btnLoadLastShardBackup.Enabled = false;
            btnLoadLastWorldBackup.Enabled = false;
            btnLoadShardBase.Enabled = false;
            btnLoadWorldBase.Enabled = false;
            btnResetAllData.Enabled = false;
            btnResetAuthDB.Enabled = false;
            btnResetShardDB.Enabled = false;
            btnRestWorldDB.Enabled = false;
            btnShardUpdates.Enabled = false;
            btnWorldUpdates.Enabled = false;
            btnBackupAllData.Enabled = false;
            btnResetFromALocation.Enabled = false;
            btnResetFromDev.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }

        private void EnableButtons()
        {
            btnAuthUpdates.Enabled = true;
            btnBackupAuth.Enabled = true;
            btnBackupShard.Enabled = true;
            btnBackupWorld.Enabled = true;
            btnClearAuthData.Enabled = true;
            btnClearShardData.Enabled = true;
            btnClearWorldData.Enabled = true;
            btnCreateAuthDB.Enabled = true;
            btnCreateShard.Enabled = true;
            btnCreateWorldDB.Enabled = true;
            btnDownloadAllData.Enabled = true;
            btnDropAuthDB.Enabled = true;
            btnDropShardDB.Enabled = true;
            btnDropWorldDB.Enabled = true;
            btnLoadAnAuthBackup.Enabled = true;
            btnLoadAShardBacup.Enabled = true;
            btnLoadAuthBackup.Enabled = true;
            btnLoadAuthBase.Enabled = true;
            btnLoadAWorldBackup.Enabled = true;
            btnLoadLastShardBackup.Enabled = true;
            btnLoadLastWorldBackup.Enabled = true;
            btnLoadShardBase.Enabled = true;
            btnLoadWorldBase.Enabled = true;
            btnResetAllData.Enabled = true;
            btnResetAuthDB.Enabled = true;
            btnResetShardDB.Enabled = true;
            btnRestWorldDB.Enabled = true;
            btnShardUpdates.Enabled = true;
            btnWorldUpdates.Enabled = true;
            btnBackupAllData.Enabled = true;
            btnResetFromALocation.Enabled = true;
            btnResetFromDev.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
        }

        /// <summary>
        /// Called from command line to load all backups, from config.
        /// </summary>
        public void LoadAllBackups()
        {
            DisableWarnings = true;
            BtnLoadLastAuthBackup_Click(null, null);
            BtnLoadLastShardBackup_Click(null, null);
            BtnLoadLastWorldBackup_Click(null, null);
            DisableWarnings = false;
        }

        public string OpenFileDialog()
        {
            if (!CheckBackupPath())
            {
                var errMsg = "Error in Backup Path, check your config.";
                LogText(errMsg);
                return errMsg;
            }

            OpenFileDialog fileSelect = new OpenFileDialog();
            fileSelect.InitialDirectory = ConfigManager.BackupPath?.Length > 0 ? ConfigManager.BackupPath : "C:\\";
            fileSelect.Filter = "sql files (*.sql)|*.sql|sql dumps (*.sqldump|*.sqldump|All files (*.*)|*.*";
            fileSelect.FilterIndex = 4;
            fileSelect.RestoreDirectory = true;

            string filePath = "";
            if (fileSelect.ShowDialog() == DialogResult.OK)
            {
                filePath = fileSelect.FileName;
            }
            return filePath;
        }

        public bool OpenFolderDialog()
        {
            if (!CheckDataPath())
            {
                var errMsg = "Error in Backup Path, check your config.";
                LogText(errMsg);
                return false;
            }
            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            folderSelect.SelectedPath = ConfigManager.DataPath?.Length > 0 ? ConfigManager.DataPath : "C:\\";
            if (folderSelect.ShowDialog() == DialogResult.OK)
            {
                ConfigManager.SetDataPath(folderSelect.SelectedPath);
                return true;
            }
            else
                return false;
        }

        private void ChkBxAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxAdvanced.CheckState == CheckState.Checked)
            {
                if (!ACEManager.Config.HardModeReached)
                {
                    if (!HardMode())
                    {
                        chkBxAdvanced.Checked = false;
                        return;
                    }
                }
                this.Height = 646;
                txtBxDBLog.Height = 582;
                aceLogo.Location = new System.Drawing.Point(12, 473);
                grpDBSettings.Location = new System.Drawing.Point(154, 473);
                grpSetupIndividualDatabases.Visible = true;
                grpBackupRestore.Visible = true;
                grpCreatDelete.Visible = true;
                btnResetFromDev.Visible = true;
                btnResetFromALocation.Visible = true;
                ACEManager.Config.AdvancedMode = true;
            }
            else
            {
                this.Height = 300;
                txtBxDBLog.Height = 238;
                aceLogo.Location = new System.Drawing.Point(12, 129);
                grpDBSettings.Location = new System.Drawing.Point(154, 129);
                grpSetupIndividualDatabases.Visible = false;
                grpBackupRestore.Visible = false;
                grpCreatDelete.Visible = false;
                btnResetFromDev.Visible = false;
                btnResetFromALocation.Visible = false;
                ACEManager.Config.AdvancedMode = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        public void BtnDownloadUpdates_Click(object sender, EventArgs e)
        {
            DisableButtons();
            if (DownloadUpdates())
                LogText("Downloads Finished.");
            EnableButtons();
        }

        public void BtnCreateAuthDB_Click(object sender, EventArgs e)
        {
            if (txtBxDBAuthName.TextLength > 0)
            {
                DisableButtons();
                if (CreateDatabase(txtBxDBAuthName.Text))
                    LogText("Create Authentication Finished.");
                EnableButtons();
            }
        }

        private void BtnCreateShard_Click(object sender, EventArgs e)
        {
            if (txtBxDBShardName.TextLength > 0)
            {
                DisableButtons();
                if (CreateDatabase(txtBxDBShardName.Text))
                    LogText("Create Shard Finished.");
                EnableButtons();
            }
        }

        private void BtnCreateWorldDB_Click(object sender, EventArgs e)
        {
            if (txtBxDBWorldName.TextLength > 0)
            {
                DisableButtons();
                if (CreateDatabase(txtBxDBWorldName.Text))
                    LogText("Create World Finished.");
                EnableButtons();
            }
        }

        private void BtnDropAuthDB_Click(object sender, EventArgs e)
        {
            if (txtBxDBAuthName.TextLength > 0)
            {
                DisableButtons();
                if (DropDatabase(txtBxDBAuthName.Text))
                    LogText("Drop Authentication Finished.");
                EnableButtons();
            }
        }

        private void BtnDropShardDB_Click(object sender, EventArgs e)
        {
            if (txtBxDBShardName.TextLength > 0)
            {
                DisableButtons();
                if (DropDatabase(txtBxDBShardName.Text))
                    LogText("Drop Shard Finished.");
                EnableButtons();
            }
        }

        private void BtnDropWorldDB_Click(object sender, EventArgs e)
        {
            if (txtBxDBWorldName.TextLength > 0)
            {
                DisableButtons();
                if (DropDatabase(txtBxDBWorldName.Text))
                    LogText("Drop World Finished.");
                EnableButtons();
            }
        }
        private void BtnLoadAuthBase_Click(object sender, EventArgs e)
        {
            if (txtBxDBAuthName.TextLength > 0)
            {
                DisableButtons();
                if (LoadBase(txtBxDBAuthName.Text, ACEManager.Config.AuthenticationBaseSqlFilename))
                    LogText("Load Authentication Base Finished.");
                EnableButtons();
            }
        }

        private void BtnLoadShardBase_Click(object sender, EventArgs e)
        {
            if (txtBxDBShardName.TextLength > 0)
            {
                DisableButtons();
                if (LoadBase(txtBxDBShardName.Text, ACEManager.Config.ShardBaseSqlFilename))
                    LogText("Load Shard Base Finished.");
                EnableButtons();
            }
        }

        private void BtnLoadWorldBase_Click(object sender, EventArgs e)
        {
            if (txtBxDBWorldName.TextLength > 0)
            {
                DisableButtons();
                if (LoadBase(txtBxDBWorldName.Text, ACEManager.Config.WorldBaseSqlFilename))
                    LogText("Load World Base Finished.");
                EnableButtons();
            }
        }

        private void BtnAuthUpdates_Click(object sender, EventArgs e)
        {
            if (txtBxDBAuthName.TextLength > 0)
            {
                DisableButtons();
                if (LoadUpdates(txtBxDBAuthName.Text, ACEManager.Config.AuthenticationUpdatesPath))
                    LogText("Updates Finished.");
                EnableButtons();
            }
        }

        private void BtnShardUpdates_Click(object sender, EventArgs e)
        {
            if (txtBxDBShardName.TextLength > 0)
            {
                DisableButtons();
                if (LoadUpdates(txtBxDBShardName.Text, ACEManager.Config.ShardUpdatesPath))
                    LogText("Updates Finished.");
                EnableButtons();
            }
        }

        public void BtnWorldUpdates_Click(object sender, EventArgs e)
        {
            if (txtBxDBWorldName.TextLength > 0)
            {
                DisableButtons();
                if (LoadWorld())
                {
                    LogText("Load World Finished.");
                    if (LoadUpdates(txtBxDBWorldName.Text, ACEManager.Config.WorldUpdatesPath))
                        LogText("Updates Finished.");
                }
                // Load World!?!?!
                EnableButtons();
            }
        }

        public void BtnResetAuth_Click(object sender, EventArgs e)
        {
            if (txtBxDBAuthName.TextLength > 0)
            {
                DisableButtons();
                var databaseName = txtBxDBAuthName.Text;
                if (ResetAuth(databaseName, DisableWarnings))
                    LogText("Reset Authentication Finished!");
                else
                    LogText("Failure durring Authentication setup!");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the database settings.");
            }
        }

        public void BtnResetShard_Click(object sender, EventArgs e)
        {
            if (txtBxDBShardName.TextLength > 0)
            {
                DisableButtons();
                var databaseName = txtBxDBShardName.Text;
                if (ResetShard(databaseName, DisableWarnings))
                    LogText("Reset Shard Finished");
                else
                    LogText("Failure durring Shard setup!");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the database settings.");
            }
        }

        public void BtnResetWorld_Click(object sender, EventArgs e)
        {
            if (txtBxDBWorldName.TextLength > 0)
            {
                DisableButtons();
                var databaseName = txtBxDBWorldName.Text;
                if (ResetWorld(databaseName, DisableWarnings))
                    LogText("Reset World Finished!");
                else
                    LogText("Failure durring World setup!");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the database settings.");
            }
        }

        public void BtnResetAllData_Click(object sender, EventArgs e)
        {
            LogText($"Resetting All!!!!");
            // Allow user to cancel:
            if (WarnUser("This will reset everything!") == false)
            {
                LogText("Canceled action!");
                return;
            }
            DisableWarnings = true;
            DisableButtons();
            BtnResetAuth_Click(null, null);
            BtnResetShard_Click(null, null);
            BtnResetWorld_Click(null, null);
            EnableButtons();
            DisableWarnings = false;
            LogText("Done resetting and loading all data!");
        }

        private void BtnClearAuthData_Click(object sender, EventArgs e)
        {
            if (txtBxDBAuthName.TextLength > 0)
            {
                DisableButtons();
                var databaseName = txtBxDBAuthName.Text;
                if (ClearDatabase(databaseName, DisableWarnings))
                    LogText("Completed!");
                else
                    LogText($"Failure durring data clear for {databaseName}.");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the authenitcation database settings.");
            }
        }

        private void BtnClearShardData_Click(object sender, EventArgs e)
        {
            if (txtBxDBShardName.TextLength > 0)
            {
                DisableButtons();
                var databaseName = txtBxDBShardName.Text;
                if (ClearDatabase(databaseName, DisableWarnings))
                    LogText("Completed!");
                else
                    LogText($"Failure durring data clear for {databaseName}.");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the shard database settings.");
            }
        }

        private void BtnClearWorldData_Click(object sender, EventArgs e)
        {
            if (txtBxDBWorldName.TextLength > 0)
            {
                DisableButtons();
                var databaseName = txtBxDBWorldName.Text;
                if (ClearDatabase(databaseName, DisableWarnings))
                    LogText("Completed!");
                else
                    LogText($"Failure durring data clear for {databaseName}.");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the world database settings.");
            }
        }

        public void BtnBackupAuth_Click(object sender, EventArgs e)
        {
            if (txtBxDBAuthName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBAuthName.Text;
                LogText($"Backing up {databaseName}.");
                if (BackupDatabase(databaseName, (int)DefaultACEDatabase.Authentication))
                    LogText("Backup Completed!");
                else
                    LogText($"Failure durring backup.");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the authentication database settings.");
            }
        }

        public void BtnBackupShard_Click(object sender, EventArgs e)
        {
            if (txtBxDBShardName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBShardName.Text;
                LogText($"Backing up {databaseName}.");
                if (BackupDatabase(databaseName, (int)DefaultACEDatabase.Shard))
                    LogText("Backup Completed!");
                else
                    LogText($"Failure durring backup.");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the shard database settings.");
            }
        }

        public void BtnBackupWorld_Click(object sender, EventArgs e)
        {
            if (txtBxDBWorldName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBWorldName.Text;
                LogText($"Backing up {databaseName}.");
                if (BackupDatabase(databaseName, (int)DefaultACEDatabase.World))
                    LogText("Backup Completed!");
                else
                    LogText($"Failure durring backup.");
                EnableButtons();
            }
            else
            {
                LogText("Please enter a database name inside of the world database settings.");
            }
        }

        public void BtnBackupAllData_Click(object sender, EventArgs e)
        {
            LogText($"Backing up all of the databases!");

            DisableButtons();
            BtnBackupAuth_Click(null, null);
            BtnBackupShard_Click(null, null);
            BtnBackupWorld_Click(null, null);
            EnableButtons();
            LogText("Done backing up all of the databases!");
        }

        private void BtnLoadAnAuthBackup_Click(object sender, EventArgs e)
        {
            var filePath = OpenFileDialog();
            if (filePath.Length > 0 && txtBxDBAuthName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBAuthName.Text;
                LogText($"Restoring {filePath} into {databaseName}.");
                if (RestoreDatabase(filePath, databaseName, DisableWarnings)) 
                    LogText("Restore Completed!");
                else
                    LogText($"Failure durring restore.");
                EnableButtons();
            }
        }

        private void BtnLoadAShardBacup_Click(object sender, EventArgs e)
        {
            var filePath = OpenFileDialog();
            if (filePath.Length > 0 && txtBxDBShardName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBShardName.Text;
                LogText($"Restoring {filePath} into {databaseName}.");
                if (RestoreDatabase(filePath, databaseName, DisableWarnings))
                    LogText("Restore Completed!");
                else
                    LogText($"Failure durring restore.");
                EnableButtons();
            }
        }

        private void BtnLoadAWorldBackup_Click(object sender, EventArgs e)
        {
            var filePath = OpenFileDialog();
            if (filePath.Length > 0 && txtBxDBWorldName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBWorldName.Text;
                LogText($"Restoring {filePath} into {databaseName}.");
                if (RestoreDatabase(filePath, databaseName, DisableWarnings))
                    LogText("Restore Completed!");
                else
                    LogText($"Failure durring restore.");
                EnableButtons();
            }
        }

        public void BtnLoadLastAuthBackup_Click(object sender, EventArgs e)
        {
            var filePath = ACEManager.Config.AuthLastBackupPath;
            if (filePath.Length > 0 && txtBxDBAuthName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBAuthName.Text;
                LogText($"Restoring {filePath} into {databaseName}.");
                if (RestoreDatabase(filePath, databaseName, DisableWarnings))
                    LogText("Restore Completed!");
                else
                    LogText($"Failure durring restore.");
                EnableButtons();
            }
        }

        public void BtnLoadLastShardBackup_Click(object sender, EventArgs e)
        {
            var filePath = ACEManager.Config.ShardLastBackupPath;
            if (filePath.Length > 0 && txtBxDBShardName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBShardName.Text;
                LogText($"Restoring {filePath} into {databaseName}.");
                if (RestoreDatabase(filePath, databaseName, DisableWarnings))
                    LogText("Restore Completed!");
                else
                    LogText($"Failure durring restore.");
                EnableButtons();
            }
        }

        public void BtnLoadLastWorldBackup_Click(object sender, EventArgs e)
        {
            var filePath = ACEManager.Config.WorldLastBackupPath;
            if (filePath.Length > 0 && txtBxDBWorldName.TextLength > 0)
            {
                // check backup directory from config?
                DisableButtons();
                var databaseName = txtBxDBWorldName.Text;
                LogText($"Restoring {filePath} into {databaseName}.");
                if (RestoreDatabase(filePath, databaseName, DisableWarnings))
                    LogText("Restore Completed!");
                else
                    LogText($"Failure durring restore.");
                EnableButtons();
            }
        }

        private void BtnResetFromDev_Click(object sender, EventArgs e)
        {
            if (ACEManager.Config.AceServerPath?.Length > 0) {
                var testPath = Path.GetFullPath(Path.Combine(ACEManager.Config.AceServerPath, "..\\..\\..\\..\\..\\Database\\"));
                // test the path from server argument ..//..//Database
                if (Directory.Exists(testPath))
                {
                    var captureDataPath = ConfigManager.DataPath;
                    ConfigManager.SetDataPath(testPath);
                    try
                    {
                        BtnResetAllData_Click(null, null);
                    }
                    catch (Exception error)
                    {
                        LogText("Unknown Issue: " + error.Message);
                    }
                    ConfigManager.SetDataPath(captureDataPath);
                }
                else
                    LogText($"Troubles loading path {testPath}");
            }
            else
            {
                LogText("Invalid Server path in config.");
            }
        }

        private void BtnResetFromALocation_Click(object sender, EventArgs e)
        {
            var captureDataPath = ConfigManager.DataPath;
            if (OpenFolderDialog())
                try
                {
                    BtnResetAllData_Click(null, null);
                }
                catch (Exception error)
                {
                    LogText("Unknown Issue: " + error.Message);
                }
                finally
                {
                    ConfigManager.SetDataPath(captureDataPath);
                }
            else
                LogText("Canceled reset.");    
        }
    }
}
