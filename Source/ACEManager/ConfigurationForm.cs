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
            if (Program.Config.EnableAutoRestart)
                this.chkBxAutoRestart.Checked = true;
            if (Program.Config.SaveLogFile)
                this.chkBxSaveLogFile.Checked = true;
            txtBxAceServerPath.Text = Program.Config.AceServerPath;
            txtBxAceServerExe.Text = Program.Config.AceServerExecutable;
            txtBxAceServerArgs.Text = Program.Config.AceServerArguments;
            txtBxLocalLogPath.Text = Program.Config.LocalLogPath;
            txtBxLogDataFormat.Text = Program.Config.LogDataFormat;
            txtBxLogFilenameFormat.Text = Program.Config.LogFilenameFormat;
        }

        private void SaveSettings()
        {
            Program.Config.EnableAutoRestart = this.chkBxAutoRestart.Checked;
            Program.Config.SaveLogFile = this.chkBxSaveLogFile.Checked;
            Program.Config.AceServerPath = txtBxAceServerPath.Text;
            Program.Config.AceServerExecutable = txtBxAceServerExe.Text;
            Program.Config.AceServerArguments = txtBxAceServerArgs.Text;
            Program.Config.LocalLogPath = txtBxLocalLogPath.Text;
            Program.Config.LogDataFormat = txtBxLogDataFormat.Text;
            Program.Config.LogFilenameFormat = txtBxLogFilenameFormat.Text;
            Program.ConfigurationUpdated = true;
            ConfigManager.Save(Program.Config);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }
    }
}
