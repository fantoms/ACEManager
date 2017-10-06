namespace ACEManager
{
    public partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.groupBoxConfig = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblAutoRestart = new System.Windows.Forms.Label();
            this.lblSaveLog = new System.Windows.Forms.Label();
            this.lblDataFormat = new System.Windows.Forms.Label();
            this.lblFilenameFormat = new System.Windows.Forms.Label();
            this.lblLocalLogPath = new System.Windows.Forms.Label();
            this.lblAceArgs = new System.Windows.Forms.Label();
            this.lblAceExe = new System.Windows.Forms.Label();
            this.lblAceServerPath = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkBxSaveLogFile = new System.Windows.Forms.CheckBox();
            this.txtBxLogDataFormat = new System.Windows.Forms.TextBox();
            this.txtBxLogFilenameFormat = new System.Windows.Forms.TextBox();
            this.chkBxAutoRestart = new System.Windows.Forms.CheckBox();
            this.txtBxLocalLogPath = new System.Windows.Forms.TextBox();
            this.txtBxAceServerArgs = new System.Windows.Forms.TextBox();
            this.txtBxAceServerExe = new System.Windows.Forms.TextBox();
            this.txtBxAceServerPath = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblWorldUpdatesUrl = new System.Windows.Forms.Label();
            this.lblWorldBaseUrl = new System.Windows.Forms.Label();
            this.lblShardUpdatesUrl = new System.Windows.Forms.Label();
            this.lblShardBaseUrl = new System.Windows.Forms.Label();
            this.lblAuthUpdatesUrl = new System.Windows.Forms.Label();
            this.lblAuthBaseUrl = new System.Windows.Forms.Label();
            this.lbACEWorldGithubUrl = new System.Windows.Forms.Label();
            this.lblLocalDataPath = new System.Windows.Forms.Label();
            this.lblDBPassword = new System.Windows.Forms.Label();
            this.lblDBUser = new System.Windows.Forms.Label();
            this.lblDBPort = new System.Windows.Forms.Label();
            this.lblDBHost = new System.Windows.Forms.Label();
            this.txtBxWorldUpdatesUrl = new System.Windows.Forms.TextBox();
            this.txtBxWorldBaseUrl = new System.Windows.Forms.TextBox();
            this.txtBxShardUpdatesUrl = new System.Windows.Forms.TextBox();
            this.txtBxShardBaseUrl = new System.Windows.Forms.TextBox();
            this.txtBxAuthUpdatesUrl = new System.Windows.Forms.TextBox();
            this.txtBxAuthBaseUrl = new System.Windows.Forms.TextBox();
            this.txtBxACEWorldGithubUrl = new System.Windows.Forms.TextBox();
            this.txtBxLocalDataPath = new System.Windows.Forms.TextBox();
            this.txtBxDBHost = new System.Windows.Forms.TextBox();
            this.txtBxDBPort = new System.Windows.Forms.TextBox();
            this.txtBxDBUsername = new System.Windows.Forms.TextBox();
            this.txtBxDBPassword = new System.Windows.Forms.TextBox();
            this.groupBoxDatabase = new System.Windows.Forms.GroupBox();
            this.groupBoxConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConfig
            // 
            this.groupBoxConfig.Controls.Add(this.splitContainer1);
            this.groupBoxConfig.Location = new System.Drawing.Point(385, 12);
            this.groupBoxConfig.Name = "groupBoxConfig";
            this.groupBoxConfig.Size = new System.Drawing.Size(367, 252);
            this.groupBoxConfig.TabIndex = 0;
            this.groupBoxConfig.TabStop = false;
            this.groupBoxConfig.Text = "Config";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblAutoRestart);
            this.splitContainer1.Panel1.Controls.Add(this.lblSaveLog);
            this.splitContainer1.Panel1.Controls.Add(this.lblDataFormat);
            this.splitContainer1.Panel1.Controls.Add(this.lblFilenameFormat);
            this.splitContainer1.Panel1.Controls.Add(this.lblLocalLogPath);
            this.splitContainer1.Panel1.Controls.Add(this.lblAceArgs);
            this.splitContainer1.Panel1.Controls.Add(this.lblAceExe);
            this.splitContainer1.Panel1.Controls.Add(this.lblAceServerPath);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.chkBxSaveLogFile);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxLogDataFormat);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxLogFilenameFormat);
            this.splitContainer1.Panel2.Controls.Add(this.chkBxAutoRestart);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxLocalLogPath);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxAceServerArgs);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxAceServerExe);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxAceServerPath);
            this.splitContainer1.Size = new System.Drawing.Size(361, 233);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // lblAutoRestart
            // 
            this.lblAutoRestart.AutoSize = true;
            this.lblAutoRestart.Location = new System.Drawing.Point(3, 4);
            this.lblAutoRestart.Name = "lblAutoRestart";
            this.lblAutoRestart.Size = new System.Drawing.Size(105, 13);
            this.lblAutoRestart.TabIndex = 7;
            this.lblAutoRestart.Text = "Enable Auto-Restart:";
            // 
            // lblSaveLog
            // 
            this.lblSaveLog.AutoSize = true;
            this.lblSaveLog.Location = new System.Drawing.Point(3, 27);
            this.lblSaveLog.Name = "lblSaveLog";
            this.lblSaveLog.Size = new System.Drawing.Size(75, 13);
            this.lblSaveLog.TabIndex = 6;
            this.lblSaveLog.Text = "Save Log File:";
            // 
            // lblDataFormat
            // 
            this.lblDataFormat.AutoSize = true;
            this.lblDataFormat.Location = new System.Drawing.Point(3, 103);
            this.lblDataFormat.Name = "lblDataFormat";
            this.lblDataFormat.Size = new System.Drawing.Size(89, 13);
            this.lblDataFormat.TabIndex = 5;
            this.lblDataFormat.Text = "Log Data Format:";
            // 
            // lblFilenameFormat
            // 
            this.lblFilenameFormat.AutoSize = true;
            this.lblFilenameFormat.Location = new System.Drawing.Point(3, 78);
            this.lblFilenameFormat.Name = "lblFilenameFormat";
            this.lblFilenameFormat.Size = new System.Drawing.Size(108, 13);
            this.lblFilenameFormat.TabIndex = 4;
            this.lblFilenameFormat.Text = "Log Filename Format:";
            // 
            // lblLocalLogPath
            // 
            this.lblLocalLogPath.AutoSize = true;
            this.lblLocalLogPath.Location = new System.Drawing.Point(3, 52);
            this.lblLocalLogPath.Name = "lblLocalLogPath";
            this.lblLocalLogPath.Size = new System.Drawing.Size(82, 13);
            this.lblLocalLogPath.TabIndex = 3;
            this.lblLocalLogPath.Text = "Local Log Path:";
            // 
            // lblAceArgs
            // 
            this.lblAceArgs.AutoSize = true;
            this.lblAceArgs.Location = new System.Drawing.Point(4, 181);
            this.lblAceArgs.Name = "lblAceArgs";
            this.lblAceArgs.Size = new System.Drawing.Size(116, 13);
            this.lblAceArgs.TabIndex = 2;
            this.lblAceArgs.Text = "Ace Server Arguments:";
            // 
            // lblAceExe
            // 
            this.lblAceExe.AutoSize = true;
            this.lblAceExe.Location = new System.Drawing.Point(4, 155);
            this.lblAceExe.Name = "lblAceExe";
            this.lblAceExe.Size = new System.Drawing.Size(119, 13);
            this.lblAceExe.TabIndex = 1;
            this.lblAceExe.Text = "Ace Server Executable:";
            // 
            // lblAceServerPath
            // 
            this.lblAceServerPath.AutoSize = true;
            this.lblAceServerPath.Location = new System.Drawing.Point(4, 129);
            this.lblAceServerPath.Name = "lblAceServerPath";
            this.lblAceServerPath.Size = new System.Drawing.Size(88, 13);
            this.lblAceServerPath.TabIndex = 0;
            this.lblAceServerPath.Text = "Ace Server Path:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // chkBxSaveLogFile
            // 
            this.chkBxSaveLogFile.AutoSize = true;
            this.chkBxSaveLogFile.Location = new System.Drawing.Point(3, 26);
            this.chkBxSaveLogFile.Name = "chkBxSaveLogFile";
            this.chkBxSaveLogFile.Size = new System.Drawing.Size(154, 17);
            this.chkBxSaveLogFile.TabIndex = 7;
            this.chkBxSaveLogFile.Text = " (Required to save log files)";
            this.chkBxSaveLogFile.UseVisualStyleBackColor = true;
            // 
            // txtBxLogDataFormat
            // 
            this.txtBxLogDataFormat.Location = new System.Drawing.Point(3, 100);
            this.txtBxLogDataFormat.Name = "txtBxLogDataFormat";
            this.txtBxLogDataFormat.Size = new System.Drawing.Size(218, 20);
            this.txtBxLogDataFormat.TabIndex = 5;
            // 
            // txtBxLogFilenameFormat
            // 
            this.txtBxLogFilenameFormat.Location = new System.Drawing.Point(3, 75);
            this.txtBxLogFilenameFormat.Name = "txtBxLogFilenameFormat";
            this.txtBxLogFilenameFormat.Size = new System.Drawing.Size(218, 20);
            this.txtBxLogFilenameFormat.TabIndex = 4;
            // 
            // chkBxAutoRestart
            // 
            this.chkBxAutoRestart.AutoSize = true;
            this.chkBxAutoRestart.Location = new System.Drawing.Point(3, 3);
            this.chkBxAutoRestart.Name = "chkBxAutoRestart";
            this.chkBxAutoRestart.Size = new System.Drawing.Size(203, 17);
            this.chkBxAutoRestart.TabIndex = 6;
            this.chkBxAutoRestart.Text = " (Attempts to keep the server running)";
            this.chkBxAutoRestart.UseVisualStyleBackColor = true;
            // 
            // txtBxLocalLogPath
            // 
            this.txtBxLocalLogPath.Location = new System.Drawing.Point(3, 49);
            this.txtBxLocalLogPath.Name = "txtBxLocalLogPath";
            this.txtBxLocalLogPath.Size = new System.Drawing.Size(218, 20);
            this.txtBxLocalLogPath.TabIndex = 3;
            // 
            // txtBxAceServerArgs
            // 
            this.txtBxAceServerArgs.Location = new System.Drawing.Point(3, 178);
            this.txtBxAceServerArgs.Name = "txtBxAceServerArgs";
            this.txtBxAceServerArgs.Size = new System.Drawing.Size(218, 20);
            this.txtBxAceServerArgs.TabIndex = 2;
            // 
            // txtBxAceServerExe
            // 
            this.txtBxAceServerExe.Location = new System.Drawing.Point(3, 152);
            this.txtBxAceServerExe.Name = "txtBxAceServerExe";
            this.txtBxAceServerExe.Size = new System.Drawing.Size(218, 20);
            this.txtBxAceServerExe.TabIndex = 1;
            // 
            // txtBxAceServerPath
            // 
            this.txtBxAceServerPath.Location = new System.Drawing.Point(3, 126);
            this.txtBxAceServerPath.Name = "txtBxAceServerPath";
            this.txtBxAceServerPath.Size = new System.Drawing.Size(218, 20);
            this.txtBxAceServerPath.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(6, 16);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblWorldUpdatesUrl);
            this.splitContainer2.Panel1.Controls.Add(this.lblWorldBaseUrl);
            this.splitContainer2.Panel1.Controls.Add(this.lblShardUpdatesUrl);
            this.splitContainer2.Panel1.Controls.Add(this.lblShardBaseUrl);
            this.splitContainer2.Panel1.Controls.Add(this.lblAuthUpdatesUrl);
            this.splitContainer2.Panel1.Controls.Add(this.lblAuthBaseUrl);
            this.splitContainer2.Panel1.Controls.Add(this.lbACEWorldGithubUrl);
            this.splitContainer2.Panel1.Controls.Add(this.lblLocalDataPath);
            this.splitContainer2.Panel1.Controls.Add(this.lblDBPassword);
            this.splitContainer2.Panel1.Controls.Add(this.lblDBUser);
            this.splitContainer2.Panel1.Controls.Add(this.lblDBPort);
            this.splitContainer2.Panel1.Controls.Add(this.lblDBHost);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtBxWorldUpdatesUrl);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxWorldBaseUrl);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxShardUpdatesUrl);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxShardBaseUrl);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxAuthUpdatesUrl);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxAuthBaseUrl);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxACEWorldGithubUrl);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxLocalDataPath);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxDBHost);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxDBPort);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxDBUsername);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxDBPassword);
            this.splitContainer2.Size = new System.Drawing.Size(361, 260);
            this.splitContainer2.SplitterDistance = 124;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 1;
            // 
            // lblWorldUpdatesUrl
            // 
            this.lblWorldUpdatesUrl.AutoSize = true;
            this.lblWorldUpdatesUrl.Location = new System.Drawing.Point(3, 238);
            this.lblWorldUpdatesUrl.Name = "lblWorldUpdatesUrl";
            this.lblWorldUpdatesUrl.Size = new System.Drawing.Size(94, 13);
            this.lblWorldUpdatesUrl.TabIndex = 13;
            this.lblWorldUpdatesUrl.Text = "World Updates Url";
            // 
            // lblWorldBaseUrl
            // 
            this.lblWorldBaseUrl.AutoSize = true;
            this.lblWorldBaseUrl.Location = new System.Drawing.Point(3, 217);
            this.lblWorldBaseUrl.Name = "lblWorldBaseUrl";
            this.lblWorldBaseUrl.Size = new System.Drawing.Size(78, 13);
            this.lblWorldBaseUrl.TabIndex = 12;
            this.lblWorldBaseUrl.Text = "World Base Url";
            // 
            // lblShardUpdatesUrl
            // 
            this.lblShardUpdatesUrl.AutoSize = true;
            this.lblShardUpdatesUrl.Location = new System.Drawing.Point(3, 196);
            this.lblShardUpdatesUrl.Name = "lblShardUpdatesUrl";
            this.lblShardUpdatesUrl.Size = new System.Drawing.Size(94, 13);
            this.lblShardUpdatesUrl.TabIndex = 11;
            this.lblShardUpdatesUrl.Text = "Shard Updates Url";
            // 
            // lblShardBaseUrl
            // 
            this.lblShardBaseUrl.AutoSize = true;
            this.lblShardBaseUrl.Location = new System.Drawing.Point(3, 175);
            this.lblShardBaseUrl.Name = "lblShardBaseUrl";
            this.lblShardBaseUrl.Size = new System.Drawing.Size(78, 13);
            this.lblShardBaseUrl.TabIndex = 10;
            this.lblShardBaseUrl.Text = "Shard Base Url";
            // 
            // lblAuthUpdatesUrl
            // 
            this.lblAuthUpdatesUrl.AutoSize = true;
            this.lblAuthUpdatesUrl.Location = new System.Drawing.Point(3, 155);
            this.lblAuthUpdatesUrl.Name = "lblAuthUpdatesUrl";
            this.lblAuthUpdatesUrl.Size = new System.Drawing.Size(88, 13);
            this.lblAuthUpdatesUrl.TabIndex = 9;
            this.lblAuthUpdatesUrl.Text = "Auth Updates Url";
            // 
            // lblAuthBaseUrl
            // 
            this.lblAuthBaseUrl.AutoSize = true;
            this.lblAuthBaseUrl.Location = new System.Drawing.Point(3, 133);
            this.lblAuthBaseUrl.Name = "lblAuthBaseUrl";
            this.lblAuthBaseUrl.Size = new System.Drawing.Size(72, 13);
            this.lblAuthBaseUrl.TabIndex = 8;
            this.lblAuthBaseUrl.Text = "Auth Base Url";
            // 
            // lbACEWorldGithubUrl
            // 
            this.lbACEWorldGithubUrl.AutoSize = true;
            this.lbACEWorldGithubUrl.Location = new System.Drawing.Point(3, 112);
            this.lbACEWorldGithubUrl.Name = "lbACEWorldGithubUrl";
            this.lbACEWorldGithubUrl.Size = new System.Drawing.Size(112, 13);
            this.lbACEWorldGithubUrl.TabIndex = 7;
            this.lbACEWorldGithubUrl.Text = "ACE-World Github Url:";
            // 
            // lblLocalDataPath
            // 
            this.lblLocalDataPath.AutoSize = true;
            this.lblLocalDataPath.Location = new System.Drawing.Point(3, 91);
            this.lblLocalDataPath.Name = "lblLocalDataPath";
            this.lblLocalDataPath.Size = new System.Drawing.Size(125, 13);
            this.lblLocalDataPath.TabIndex = 6;
            this.lblLocalDataPath.Text = "Local Data Path / Temp:";
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.AutoSize = true;
            this.lblDBPassword.Location = new System.Drawing.Point(3, 69);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(56, 13);
            this.lblDBPassword.TabIndex = 5;
            this.lblDBPassword.Text = "Password:";
            // 
            // lblDBUser
            // 
            this.lblDBUser.AutoSize = true;
            this.lblDBUser.Location = new System.Drawing.Point(3, 49);
            this.lblDBUser.Name = "lblDBUser";
            this.lblDBUser.Size = new System.Drawing.Size(58, 13);
            this.lblDBUser.TabIndex = 4;
            this.lblDBUser.Text = "Username:";
            // 
            // lblDBPort
            // 
            this.lblDBPort.AutoSize = true;
            this.lblDBPort.Location = new System.Drawing.Point(3, 28);
            this.lblDBPort.Name = "lblDBPort";
            this.lblDBPort.Size = new System.Drawing.Size(29, 13);
            this.lblDBPort.TabIndex = 2;
            this.lblDBPort.Text = "Port:";
            // 
            // lblDBHost
            // 
            this.lblDBHost.AutoSize = true;
            this.lblDBHost.Location = new System.Drawing.Point(3, 7);
            this.lblDBHost.Name = "lblDBHost";
            this.lblDBHost.Size = new System.Drawing.Size(32, 13);
            this.lblDBHost.TabIndex = 1;
            this.lblDBHost.Text = "Host:";
            // 
            // txtBxWorldUpdatesUrl
            // 
            this.txtBxWorldUpdatesUrl.Location = new System.Drawing.Point(9, 235);
            this.txtBxWorldUpdatesUrl.Name = "txtBxWorldUpdatesUrl";
            this.txtBxWorldUpdatesUrl.Size = new System.Drawing.Size(218, 20);
            this.txtBxWorldUpdatesUrl.TabIndex = 21;
            // 
            // txtBxWorldBaseUrl
            // 
            this.txtBxWorldBaseUrl.Location = new System.Drawing.Point(9, 214);
            this.txtBxWorldBaseUrl.Name = "txtBxWorldBaseUrl";
            this.txtBxWorldBaseUrl.Size = new System.Drawing.Size(218, 20);
            this.txtBxWorldBaseUrl.TabIndex = 20;
            // 
            // txtBxShardUpdatesUrl
            // 
            this.txtBxShardUpdatesUrl.Location = new System.Drawing.Point(9, 193);
            this.txtBxShardUpdatesUrl.Name = "txtBxShardUpdatesUrl";
            this.txtBxShardUpdatesUrl.Size = new System.Drawing.Size(218, 20);
            this.txtBxShardUpdatesUrl.TabIndex = 19;
            // 
            // txtBxShardBaseUrl
            // 
            this.txtBxShardBaseUrl.Location = new System.Drawing.Point(9, 172);
            this.txtBxShardBaseUrl.Name = "txtBxShardBaseUrl";
            this.txtBxShardBaseUrl.Size = new System.Drawing.Size(218, 20);
            this.txtBxShardBaseUrl.TabIndex = 18;
            // 
            // txtBxAuthUpdatesUrl
            // 
            this.txtBxAuthUpdatesUrl.Location = new System.Drawing.Point(9, 151);
            this.txtBxAuthUpdatesUrl.Name = "txtBxAuthUpdatesUrl";
            this.txtBxAuthUpdatesUrl.Size = new System.Drawing.Size(218, 20);
            this.txtBxAuthUpdatesUrl.TabIndex = 17;
            // 
            // txtBxAuthBaseUrl
            // 
            this.txtBxAuthBaseUrl.Location = new System.Drawing.Point(9, 130);
            this.txtBxAuthBaseUrl.Name = "txtBxAuthBaseUrl";
            this.txtBxAuthBaseUrl.Size = new System.Drawing.Size(218, 20);
            this.txtBxAuthBaseUrl.TabIndex = 16;
            // 
            // txtBxACEWorldGithubUrl
            // 
            this.txtBxACEWorldGithubUrl.Location = new System.Drawing.Point(9, 109);
            this.txtBxACEWorldGithubUrl.Name = "txtBxACEWorldGithubUrl";
            this.txtBxACEWorldGithubUrl.Size = new System.Drawing.Size(218, 20);
            this.txtBxACEWorldGithubUrl.TabIndex = 15;
            // 
            // txtBxLocalDataPath
            // 
            this.txtBxLocalDataPath.Location = new System.Drawing.Point(9, 88);
            this.txtBxLocalDataPath.Name = "txtBxLocalDataPath";
            this.txtBxLocalDataPath.Size = new System.Drawing.Size(218, 20);
            this.txtBxLocalDataPath.TabIndex = 14;
            // 
            // txtBxDBHost
            // 
            this.txtBxDBHost.Location = new System.Drawing.Point(9, 4);
            this.txtBxDBHost.Name = "txtBxDBHost";
            this.txtBxDBHost.Size = new System.Drawing.Size(218, 20);
            this.txtBxDBHost.TabIndex = 12;
            // 
            // txtBxDBPort
            // 
            this.txtBxDBPort.Location = new System.Drawing.Point(9, 25);
            this.txtBxDBPort.Name = "txtBxDBPort";
            this.txtBxDBPort.Size = new System.Drawing.Size(218, 20);
            this.txtBxDBPort.TabIndex = 13;
            // 
            // txtBxDBUsername
            // 
            this.txtBxDBUsername.Location = new System.Drawing.Point(9, 46);
            this.txtBxDBUsername.Name = "txtBxDBUsername";
            this.txtBxDBUsername.Size = new System.Drawing.Size(218, 20);
            this.txtBxDBUsername.TabIndex = 10;
            // 
            // txtBxDBPassword
            // 
            this.txtBxDBPassword.Location = new System.Drawing.Point(9, 67);
            this.txtBxDBPassword.Name = "txtBxDBPassword";
            this.txtBxDBPassword.PasswordChar = '*';
            this.txtBxDBPassword.Size = new System.Drawing.Size(218, 20);
            this.txtBxDBPassword.TabIndex = 11;
            // 
            // groupBoxDatabase
            // 
            this.groupBoxDatabase.Controls.Add(this.splitContainer2);
            this.groupBoxDatabase.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDatabase.Name = "groupBoxDatabase";
            this.groupBoxDatabase.Size = new System.Drawing.Size(370, 279);
            this.groupBoxDatabase.TabIndex = 2;
            this.groupBoxDatabase.TabStop = false;
            this.groupBoxDatabase.Text = "Database Maintenance Settings (Optional)";
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(769, 296);
            this.Controls.Add(this.groupBoxDatabase);
            this.Controls.Add(this.groupBoxConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Application Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.groupBoxConfig.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxDatabase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConfig;
        private System.Windows.Forms.Label lblAceExe;
        private System.Windows.Forms.Label lblAceServerPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblAceArgs;
        private System.Windows.Forms.TextBox txtBxAceServerArgs;
        private System.Windows.Forms.TextBox txtBxAceServerExe;
        private System.Windows.Forms.TextBox txtBxAceServerPath;
        private System.Windows.Forms.Label lblDataFormat;
        private System.Windows.Forms.Label lblFilenameFormat;
        private System.Windows.Forms.Label lblLocalLogPath;
        private System.Windows.Forms.TextBox txtBxLogDataFormat;
        private System.Windows.Forms.TextBox txtBxLogFilenameFormat;
        private System.Windows.Forms.TextBox txtBxLocalLogPath;
        private System.Windows.Forms.CheckBox chkBxSaveLogFile;
        private System.Windows.Forms.CheckBox chkBxAutoRestart;
        private System.Windows.Forms.Label lblAutoRestart;
        private System.Windows.Forms.Label lblSaveLog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblDBPort;
        private System.Windows.Forms.Label lblDBHost;
        private System.Windows.Forms.GroupBox groupBoxDatabase;
        private System.Windows.Forms.Label lblDBPassword;
        private System.Windows.Forms.Label lblDBUser;
        private System.Windows.Forms.TextBox txtBxDBHost;
        private System.Windows.Forms.TextBox txtBxDBPort;
        private System.Windows.Forms.TextBox txtBxDBUsername;
        private System.Windows.Forms.TextBox txtBxDBPassword;
        private System.Windows.Forms.Label lblLocalDataPath;
        private System.Windows.Forms.TextBox txtBxLocalDataPath;
        private System.Windows.Forms.Label lbACEWorldGithubUrl;
        private System.Windows.Forms.TextBox txtBxACEWorldGithubUrl;
        private System.Windows.Forms.TextBox txtBxShardUpdatesUrl;
        private System.Windows.Forms.TextBox txtBxShardBaseUrl;
        private System.Windows.Forms.TextBox txtBxAuthUpdatesUrl;
        private System.Windows.Forms.TextBox txtBxAuthBaseUrl;
        private System.Windows.Forms.TextBox txtBxWorldUpdatesUrl;
        private System.Windows.Forms.TextBox txtBxWorldBaseUrl;
        private System.Windows.Forms.Label lblWorldUpdatesUrl;
        private System.Windows.Forms.Label lblWorldBaseUrl;
        private System.Windows.Forms.Label lblShardUpdatesUrl;
        private System.Windows.Forms.Label lblShardBaseUrl;
        private System.Windows.Forms.Label lblAuthUpdatesUrl;
        private System.Windows.Forms.Label lblAuthBaseUrl;
    }
}