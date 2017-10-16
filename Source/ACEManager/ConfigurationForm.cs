using System;
using System.Windows.Forms;

namespace ACEManager
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            PopulateForm();
        }

        private void PopulateForm()
        {
            if (ACEManager.Config.EnableAutoRestart)
                this.chkBxAutoRestart.Checked = true;
            if (ACEManager.Config.SaveLogFile)
                this.chkBxSaveLogFile.Checked = true;
            txtBxAceServerPath.Text = ACEManager.Config.AceServerPath;
            txtBxAceServerExe.Text = ACEManager.Config.AceServerExecutable;
            txtBxAceServerArgs.Text = ACEManager.Config.AceServerArguments;
            txtBxLocalLogPath.Text = ACEManager.Config.LocalLogPath;
            txtBxLogDataFormat.Text = ACEManager.Config.LogDataFormat;
            txtBxLogFilenameFormat.Text = ACEManager.Config.LogFilenameFormat;
            txtBxDBHost.Text = ACEManager.Config.DatabaseHost;
            txtBxDBPort.Text = ACEManager.Config.DatabasePort.ToString();
            txtBxDBUsername.Text = ACEManager.Config.DatabaseUsername;
            txtBxDBPassword.Text = ACEManager.Config.DatabasePassword;
            txtBxLocalDataPath.Text = ACEManager.Config.DataRepository;
            txtBxACEWorldGithubUrl.Text = ACEManager.Config.GithubURL;
            txtBxBackupPath.Text = ACEManager.Config.BackupPath;
        }

        private void SaveSettings()
        {
            ACEManager.Config.EnableAutoRestart = this.chkBxAutoRestart.Checked;
            ACEManager.Config.SaveLogFile = this.chkBxSaveLogFile.Checked;
            ACEManager.Config.AceServerPath = txtBxAceServerPath.Text;
            ACEManager.Config.AceServerExecutable = txtBxAceServerExe.Text;
            ACEManager.Config.AceServerArguments = txtBxAceServerArgs.Text;
            ACEManager.Config.LocalLogPath = txtBxLocalLogPath.Text;
            ACEManager.Config.LogDataFormat = txtBxLogDataFormat.Text;
            ACEManager.Config.LogFilenameFormat = txtBxLogFilenameFormat.Text;
            ACEManager.Config.DatabaseHost = txtBxDBHost.Text;
            ACEManager.Config.DatabasePort = Int32.Parse(txtBxDBPort.Text);
            ACEManager.Config.DatabaseUsername = txtBxDBUsername.Text;
            ACEManager.Config.DatabasePassword = txtBxDBPassword.Text;
            ACEManager.Config.DataRepository = txtBxLocalDataPath.Text;
            ACEManager.Config.GithubURL = txtBxACEWorldGithubUrl.Text;
            ACEManager.Config.BackupPath = txtBxBackupPath.Text;
            ACEManager.ConfigurationUpdateRequired = true;
            ConfigManager.Save(ACEManager.Config);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }
    }
}
