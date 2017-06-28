using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
