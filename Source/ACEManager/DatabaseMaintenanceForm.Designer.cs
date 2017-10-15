namespace ACEManager
{
    public partial class DatabaseMaintenanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseMaintenanceForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblDBWorldName = new System.Windows.Forms.Label();
            this.lblDBShardName = new System.Windows.Forms.Label();
            this.lblDBAuthName = new System.Windows.Forms.Label();
            this.chkBxAdvanced = new System.Windows.Forms.CheckBox();
            this.txtBxDBAuthName = new System.Windows.Forms.TextBox();
            this.txtBxDBShardName = new System.Windows.Forms.TextBox();
            this.txtBxDBWorldName = new System.Windows.Forms.TextBox();
            this.groupBoxDatabase = new System.Windows.Forms.GroupBox();
            this.grpSimpleMode = new System.Windows.Forms.GroupBox();
            this.btnResetShardDB = new System.Windows.Forms.Button();
            this.btnRestWorldDB = new System.Windows.Forms.Button();
            this.btnResetAuthDB = new System.Windows.Forms.Button();
            this.btnResetAllData = new System.Windows.Forms.Button();
            this.btnClearWorldData = new System.Windows.Forms.Button();
            this.btnClearShardData = new System.Windows.Forms.Button();
            this.btnClearAuthData = new System.Windows.Forms.Button();
            this.btnDropWorldDB = new System.Windows.Forms.Button();
            this.btnDropShardDB = new System.Windows.Forms.Button();
            this.btnDropAuthDB = new System.Windows.Forms.Button();
            this.btnWorldUpdates = new System.Windows.Forms.Button();
            this.btnShardUpdates = new System.Windows.Forms.Button();
            this.btnAuthUpdates = new System.Windows.Forms.Button();
            this.btnLoadWorldBase = new System.Windows.Forms.Button();
            this.btnLoadShardBase = new System.Windows.Forms.Button();
            this.btnLoadAuthBase = new System.Windows.Forms.Button();
            this.btnCreateWorldDB = new System.Windows.Forms.Button();
            this.btnCreateShard = new System.Windows.Forms.Button();
            this.btnCreateAuthDB = new System.Windows.Forms.Button();
            this.btnDownloadAllData = new System.Windows.Forms.Button();
            this.btnLoadAWorldBackup = new System.Windows.Forms.Button();
            this.btnLoadAShardBacup = new System.Windows.Forms.Button();
            this.btnLoadAnAuthBackup = new System.Windows.Forms.Button();
            this.btnLoadLastWorldBackup = new System.Windows.Forms.Button();
            this.btnLoadLastShardBackup = new System.Windows.Forms.Button();
            this.btnLoadAuthBackup = new System.Windows.Forms.Button();
            this.grpBackupRestore = new System.Windows.Forms.GroupBox();
            this.btnBackupAuth = new System.Windows.Forms.Button();
            this.btnBackupShard = new System.Windows.Forms.Button();
            this.btnBackupWorld = new System.Windows.Forms.Button();
            this.grpCreatDelete = new System.Windows.Forms.GroupBox();
            this.grpDownload = new System.Windows.Forms.GroupBox();
            this.btnBackupAllData = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBxDBLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxDatabase.SuspendLayout();
            this.grpSimpleMode.SuspendLayout();
            this.grpBackupRestore.SuspendLayout();
            this.grpCreatDelete.SuspendLayout();
            this.grpDownload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(100, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 72);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(6, 16);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblDBWorldName);
            this.splitContainer2.Panel1.Controls.Add(this.lblDBShardName);
            this.splitContainer2.Panel1.Controls.Add(this.lblDBAuthName);
            this.splitContainer2.Panel1.Controls.Add(this.chkBxAdvanced);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxDBAuthName);
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxDBShardName);
            this.splitContainer2.Panel2.Controls.Add(this.txtBxDBWorldName);
            this.splitContainer2.Size = new System.Drawing.Size(291, 104);
            this.splitContainer2.SplitterDistance = 123;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 1;
            // 
            // lblDBWorldName
            // 
            this.lblDBWorldName.AutoSize = true;
            this.lblDBWorldName.Location = new System.Drawing.Point(3, 49);
            this.lblDBWorldName.Name = "lblDBWorldName";
            this.lblDBWorldName.Size = new System.Drawing.Size(115, 13);
            this.lblDBWorldName.TabIndex = 4;
            this.lblDBWorldName.Text = "World Database Name";
            // 
            // lblDBShardName
            // 
            this.lblDBShardName.AutoSize = true;
            this.lblDBShardName.Location = new System.Drawing.Point(3, 28);
            this.lblDBShardName.Name = "lblDBShardName";
            this.lblDBShardName.Size = new System.Drawing.Size(115, 13);
            this.lblDBShardName.TabIndex = 2;
            this.lblDBShardName.Text = "Shard Database Name";
            // 
            // lblDBAuthName
            // 
            this.lblDBAuthName.AutoSize = true;
            this.lblDBAuthName.Location = new System.Drawing.Point(3, 7);
            this.lblDBAuthName.Name = "lblDBAuthName";
            this.lblDBAuthName.Size = new System.Drawing.Size(109, 13);
            this.lblDBAuthName.TabIndex = 1;
            this.lblDBAuthName.Text = "Auth Database Name";
            // 
            // chkBxAdvanced
            // 
            this.chkBxAdvanced.AutoSize = true;
            this.chkBxAdvanced.Location = new System.Drawing.Point(6, 68);
            this.chkBxAdvanced.Name = "chkBxAdvanced";
            this.chkBxAdvanced.Size = new System.Drawing.Size(99, 30);
            this.chkBxAdvanced.TabIndex = 7;
            this.chkBxAdvanced.Text = "Advanced /\r\nThwargle mode";
            this.chkBxAdvanced.UseVisualStyleBackColor = true;
            this.chkBxAdvanced.CheckedChanged += new System.EventHandler(this.ChkBxAdvanced_CheckedChanged);
            // 
            // txtBxDBAuthName
            // 
            this.txtBxDBAuthName.Location = new System.Drawing.Point(9, 4);
            this.txtBxDBAuthName.Name = "txtBxDBAuthName";
            this.txtBxDBAuthName.Size = new System.Drawing.Size(150, 20);
            this.txtBxDBAuthName.TabIndex = 12;
            // 
            // txtBxDBShardName
            // 
            this.txtBxDBShardName.Location = new System.Drawing.Point(9, 25);
            this.txtBxDBShardName.Name = "txtBxDBShardName";
            this.txtBxDBShardName.Size = new System.Drawing.Size(150, 20);
            this.txtBxDBShardName.TabIndex = 13;
            // 
            // txtBxDBWorldName
            // 
            this.txtBxDBWorldName.Location = new System.Drawing.Point(9, 46);
            this.txtBxDBWorldName.Name = "txtBxDBWorldName";
            this.txtBxDBWorldName.Size = new System.Drawing.Size(150, 20);
            this.txtBxDBWorldName.TabIndex = 10;
            // 
            // groupBoxDatabase
            // 
            this.groupBoxDatabase.Controls.Add(this.splitContainer2);
            this.groupBoxDatabase.Location = new System.Drawing.Point(601, 210);
            this.groupBoxDatabase.Name = "groupBoxDatabase";
            this.groupBoxDatabase.Size = new System.Drawing.Size(298, 125);
            this.groupBoxDatabase.TabIndex = 2;
            this.groupBoxDatabase.TabStop = false;
            this.groupBoxDatabase.Text = "Database Maintenance Settings";
            // 
            // grpSimpleMode
            // 
            this.grpSimpleMode.Controls.Add(this.btnResetShardDB);
            this.grpSimpleMode.Controls.Add(this.btnRestWorldDB);
            this.grpSimpleMode.Controls.Add(this.btnResetAuthDB);
            this.grpSimpleMode.Controls.Add(this.btnResetAllData);
            this.grpSimpleMode.Location = new System.Drawing.Point(12, 70);
            this.grpSimpleMode.Name = "grpSimpleMode";
            this.grpSimpleMode.Size = new System.Drawing.Size(440, 87);
            this.grpSimpleMode.TabIndex = 3;
            this.grpSimpleMode.TabStop = false;
            this.grpSimpleMode.Text = "Simple Mode / Automated (WARNING, BE CAREFUL WITH THIS TOOL!)";
            // 
            // btnResetShardDB
            // 
            this.btnResetShardDB.Location = new System.Drawing.Point(229, 19);
            this.btnResetShardDB.Name = "btnResetShardDB";
            this.btnResetShardDB.Size = new System.Drawing.Size(205, 26);
            this.btnResetShardDB.TabIndex = 18;
            this.btnResetShardDB.Text = "Setup / Reset Shard Database";
            this.btnResetShardDB.UseVisualStyleBackColor = true;
            this.btnResetShardDB.Click += new System.EventHandler(this.BtnResetShardDB_Click);
            // 
            // btnRestWorldDB
            // 
            this.btnRestWorldDB.Location = new System.Drawing.Point(298, 51);
            this.btnRestWorldDB.Name = "btnRestWorldDB";
            this.btnRestWorldDB.Size = new System.Drawing.Size(136, 26);
            this.btnRestWorldDB.TabIndex = 17;
            this.btnRestWorldDB.Text = "Setup / Reset World Database";
            this.btnRestWorldDB.UseVisualStyleBackColor = true;
            this.btnRestWorldDB.Click += new System.EventHandler(this.BtnRestWorldDB_Click);
            // 
            // btnResetAuthDB
            // 
            this.btnResetAuthDB.Location = new System.Drawing.Point(6, 19);
            this.btnResetAuthDB.Name = "btnResetAuthDB";
            this.btnResetAuthDB.Size = new System.Drawing.Size(217, 26);
            this.btnResetAuthDB.TabIndex = 16;
            this.btnResetAuthDB.Text = "Setup / Reset Authentication Database";
            this.btnResetAuthDB.UseVisualStyleBackColor = true;
            this.btnResetAuthDB.Click += new System.EventHandler(this.BtnResetAuthDB_Click);
            // 
            // btnResetAllData
            // 
            this.btnResetAllData.Location = new System.Drawing.Point(6, 51);
            this.btnResetAllData.Name = "btnResetAllData";
            this.btnResetAllData.Size = new System.Drawing.Size(286, 26);
            this.btnResetAllData.TabIndex = 5;
            this.btnResetAllData.Text = "Setup / Reset All databases to current (do all the things!)";
            this.btnResetAllData.UseVisualStyleBackColor = true;
            this.btnResetAllData.Click += new System.EventHandler(this.BtnResetAllData_Click);
            // 
            // btnClearWorldData
            // 
            this.btnClearWorldData.Location = new System.Drawing.Point(294, 107);
            this.btnClearWorldData.Name = "btnClearWorldData";
            this.btnClearWorldData.Size = new System.Drawing.Size(138, 23);
            this.btnClearWorldData.TabIndex = 14;
            this.btnClearWorldData.Text = "Clear World Data";
            this.btnClearWorldData.UseVisualStyleBackColor = true;
            this.btnClearWorldData.Click += new System.EventHandler(this.BtnClearWorldData_Click);
            // 
            // btnClearShardData
            // 
            this.btnClearShardData.Location = new System.Drawing.Point(150, 107);
            this.btnClearShardData.Name = "btnClearShardData";
            this.btnClearShardData.Size = new System.Drawing.Size(138, 23);
            this.btnClearShardData.TabIndex = 13;
            this.btnClearShardData.Text = "Clear Shard Data";
            this.btnClearShardData.UseVisualStyleBackColor = true;
            this.btnClearShardData.Click += new System.EventHandler(this.BtnClearShardData_Click);
            // 
            // btnClearAuthData
            // 
            this.btnClearAuthData.Location = new System.Drawing.Point(6, 107);
            this.btnClearAuthData.Name = "btnClearAuthData";
            this.btnClearAuthData.Size = new System.Drawing.Size(138, 23);
            this.btnClearAuthData.TabIndex = 12;
            this.btnClearAuthData.Text = "Clear Auth Data";
            this.btnClearAuthData.UseVisualStyleBackColor = true;
            this.btnClearAuthData.Click += new System.EventHandler(this.BtnClearAuthData_Click);
            // 
            // btnDropWorldDB
            // 
            this.btnDropWorldDB.Location = new System.Drawing.Point(295, 136);
            this.btnDropWorldDB.Name = "btnDropWorldDB";
            this.btnDropWorldDB.Size = new System.Drawing.Size(138, 23);
            this.btnDropWorldDB.TabIndex = 11;
            this.btnDropWorldDB.Text = "Drop World Database";
            this.btnDropWorldDB.UseVisualStyleBackColor = true;
            this.btnDropWorldDB.Click += new System.EventHandler(this.BtnDropWorldDB_Click);
            // 
            // btnDropShardDB
            // 
            this.btnDropShardDB.Location = new System.Drawing.Point(150, 136);
            this.btnDropShardDB.Name = "btnDropShardDB";
            this.btnDropShardDB.Size = new System.Drawing.Size(138, 23);
            this.btnDropShardDB.TabIndex = 10;
            this.btnDropShardDB.Text = "Drop Shard Database";
            this.btnDropShardDB.UseVisualStyleBackColor = true;
            this.btnDropShardDB.Click += new System.EventHandler(this.BtnDropShardDB_Click);
            // 
            // btnDropAuthDB
            // 
            this.btnDropAuthDB.Location = new System.Drawing.Point(6, 136);
            this.btnDropAuthDB.Name = "btnDropAuthDB";
            this.btnDropAuthDB.Size = new System.Drawing.Size(138, 23);
            this.btnDropAuthDB.TabIndex = 9;
            this.btnDropAuthDB.Text = "Drop Auth Database";
            this.btnDropAuthDB.UseVisualStyleBackColor = true;
            this.btnDropAuthDB.Click += new System.EventHandler(this.BtnDropAuthDB_Click);
            // 
            // btnWorldUpdates
            // 
            this.btnWorldUpdates.Location = new System.Drawing.Point(294, 78);
            this.btnWorldUpdates.Name = "btnWorldUpdates";
            this.btnWorldUpdates.Size = new System.Drawing.Size(138, 23);
            this.btnWorldUpdates.TabIndex = 8;
            this.btnWorldUpdates.Text = "Run World Updates";
            this.btnWorldUpdates.UseVisualStyleBackColor = true;
            this.btnWorldUpdates.Click += new System.EventHandler(this.BtnWorldUpdates_Click);
            // 
            // btnShardUpdates
            // 
            this.btnShardUpdates.Location = new System.Drawing.Point(150, 78);
            this.btnShardUpdates.Name = "btnShardUpdates";
            this.btnShardUpdates.Size = new System.Drawing.Size(138, 23);
            this.btnShardUpdates.TabIndex = 7;
            this.btnShardUpdates.Text = "Run Shard Updates";
            this.btnShardUpdates.UseVisualStyleBackColor = true;
            this.btnShardUpdates.Click += new System.EventHandler(this.BtnShardUpdates_Click);
            // 
            // btnAuthUpdates
            // 
            this.btnAuthUpdates.Location = new System.Drawing.Point(6, 78);
            this.btnAuthUpdates.Name = "btnAuthUpdates";
            this.btnAuthUpdates.Size = new System.Drawing.Size(138, 23);
            this.btnAuthUpdates.TabIndex = 6;
            this.btnAuthUpdates.Text = "Run Auth Updates";
            this.btnAuthUpdates.UseVisualStyleBackColor = true;
            this.btnAuthUpdates.Click += new System.EventHandler(this.BtnAuthUpdates_Click);
            // 
            // btnLoadWorldBase
            // 
            this.btnLoadWorldBase.Location = new System.Drawing.Point(294, 49);
            this.btnLoadWorldBase.Name = "btnLoadWorldBase";
            this.btnLoadWorldBase.Size = new System.Drawing.Size(138, 23);
            this.btnLoadWorldBase.TabIndex = 5;
            this.btnLoadWorldBase.Text = "Load World Base";
            this.btnLoadWorldBase.UseVisualStyleBackColor = true;
            this.btnLoadWorldBase.Click += new System.EventHandler(this.BtnLoadWorldBase_Click);
            // 
            // btnLoadShardBase
            // 
            this.btnLoadShardBase.Location = new System.Drawing.Point(150, 49);
            this.btnLoadShardBase.Name = "btnLoadShardBase";
            this.btnLoadShardBase.Size = new System.Drawing.Size(138, 23);
            this.btnLoadShardBase.TabIndex = 4;
            this.btnLoadShardBase.Text = "Load Shard Base";
            this.btnLoadShardBase.UseVisualStyleBackColor = true;
            this.btnLoadShardBase.Click += new System.EventHandler(this.BtnLoadShardBase_Click);
            // 
            // btnLoadAuthBase
            // 
            this.btnLoadAuthBase.Location = new System.Drawing.Point(6, 49);
            this.btnLoadAuthBase.Name = "btnLoadAuthBase";
            this.btnLoadAuthBase.Size = new System.Drawing.Size(138, 23);
            this.btnLoadAuthBase.TabIndex = 3;
            this.btnLoadAuthBase.Text = "Load Auth Base";
            this.btnLoadAuthBase.UseVisualStyleBackColor = true;
            this.btnLoadAuthBase.Click += new System.EventHandler(this.BtnLoadAuthBase_Click);
            // 
            // btnCreateWorldDB
            // 
            this.btnCreateWorldDB.Location = new System.Drawing.Point(294, 20);
            this.btnCreateWorldDB.Name = "btnCreateWorldDB";
            this.btnCreateWorldDB.Size = new System.Drawing.Size(138, 23);
            this.btnCreateWorldDB.TabIndex = 2;
            this.btnCreateWorldDB.Text = "Create World Database";
            this.btnCreateWorldDB.UseVisualStyleBackColor = true;
            this.btnCreateWorldDB.Click += new System.EventHandler(this.BtnCreateWorldDB_Click);
            // 
            // btnCreateShard
            // 
            this.btnCreateShard.Location = new System.Drawing.Point(150, 20);
            this.btnCreateShard.Name = "btnCreateShard";
            this.btnCreateShard.Size = new System.Drawing.Size(138, 23);
            this.btnCreateShard.TabIndex = 1;
            this.btnCreateShard.Text = "Create Shard Database";
            this.btnCreateShard.UseVisualStyleBackColor = true;
            this.btnCreateShard.Click += new System.EventHandler(this.BtnCreateShard_Click);
            // 
            // btnCreateAuthDB
            // 
            this.btnCreateAuthDB.Location = new System.Drawing.Point(6, 20);
            this.btnCreateAuthDB.Name = "btnCreateAuthDB";
            this.btnCreateAuthDB.Size = new System.Drawing.Size(138, 23);
            this.btnCreateAuthDB.TabIndex = 0;
            this.btnCreateAuthDB.Text = "Create Auth Database";
            this.btnCreateAuthDB.UseVisualStyleBackColor = true;
            this.btnCreateAuthDB.Click += new System.EventHandler(this.BtnCreateAuthDB_Click);
            // 
            // btnDownloadAllData
            // 
            this.btnDownloadAllData.Location = new System.Drawing.Point(6, 19);
            this.btnDownloadAllData.Name = "btnDownloadAllData";
            this.btnDownloadAllData.Size = new System.Drawing.Size(217, 24);
            this.btnDownloadAllData.TabIndex = 4;
            this.btnDownloadAllData.Text = "Download ALL Data from Github";
            this.btnDownloadAllData.UseVisualStyleBackColor = true;
            this.btnDownloadAllData.Click += new System.EventHandler(this.BtnDownloadUpdates_Click);
            // 
            // btnLoadAWorldBackup
            // 
            this.btnLoadAWorldBackup.Location = new System.Drawing.Point(294, 48);
            this.btnLoadAWorldBackup.Name = "btnLoadAWorldBackup";
            this.btnLoadAWorldBackup.Size = new System.Drawing.Size(138, 23);
            this.btnLoadAWorldBackup.TabIndex = 18;
            this.btnLoadAWorldBackup.Text = "Load a World Backup...";
            this.btnLoadAWorldBackup.UseVisualStyleBackColor = true;
            this.btnLoadAWorldBackup.Click += new System.EventHandler(this.BtnLoadAWorldBackup_Click);
            // 
            // btnLoadAShardBacup
            // 
            this.btnLoadAShardBacup.Location = new System.Drawing.Point(150, 48);
            this.btnLoadAShardBacup.Name = "btnLoadAShardBacup";
            this.btnLoadAShardBacup.Size = new System.Drawing.Size(138, 23);
            this.btnLoadAShardBacup.TabIndex = 17;
            this.btnLoadAShardBacup.Text = "Load a Shard Backup...";
            this.btnLoadAShardBacup.UseVisualStyleBackColor = true;
            this.btnLoadAShardBacup.Click += new System.EventHandler(this.BtnLoadAShardBacup_Click);
            // 
            // btnLoadAnAuthBackup
            // 
            this.btnLoadAnAuthBackup.Location = new System.Drawing.Point(6, 48);
            this.btnLoadAnAuthBackup.Name = "btnLoadAnAuthBackup";
            this.btnLoadAnAuthBackup.Size = new System.Drawing.Size(138, 23);
            this.btnLoadAnAuthBackup.TabIndex = 16;
            this.btnLoadAnAuthBackup.Text = "Load an Auth Backup...";
            this.btnLoadAnAuthBackup.UseVisualStyleBackColor = true;
            this.btnLoadAnAuthBackup.Click += new System.EventHandler(this.BtnLoadAnAuthBackup_Click);
            // 
            // btnLoadLastWorldBackup
            // 
            this.btnLoadLastWorldBackup.Location = new System.Drawing.Point(294, 19);
            this.btnLoadLastWorldBackup.Name = "btnLoadLastWorldBackup";
            this.btnLoadLastWorldBackup.Size = new System.Drawing.Size(138, 23);
            this.btnLoadLastWorldBackup.TabIndex = 21;
            this.btnLoadLastWorldBackup.Text = "Load last World Backup";
            this.btnLoadLastWorldBackup.UseVisualStyleBackColor = true;
            this.btnLoadLastWorldBackup.Click += new System.EventHandler(this.BtnLoadLastWorldBackup_Click);
            // 
            // btnLoadLastShardBackup
            // 
            this.btnLoadLastShardBackup.Location = new System.Drawing.Point(150, 19);
            this.btnLoadLastShardBackup.Name = "btnLoadLastShardBackup";
            this.btnLoadLastShardBackup.Size = new System.Drawing.Size(138, 23);
            this.btnLoadLastShardBackup.TabIndex = 20;
            this.btnLoadLastShardBackup.Text = "Load Last Shard Backup";
            this.btnLoadLastShardBackup.UseVisualStyleBackColor = true;
            this.btnLoadLastShardBackup.Click += new System.EventHandler(this.BtnLoadLastShardBackup_Click);
            // 
            // btnLoadAuthBackup
            // 
            this.btnLoadAuthBackup.Location = new System.Drawing.Point(6, 19);
            this.btnLoadAuthBackup.Name = "btnLoadAuthBackup";
            this.btnLoadAuthBackup.Size = new System.Drawing.Size(138, 23);
            this.btnLoadAuthBackup.TabIndex = 19;
            this.btnLoadAuthBackup.Text = "Load Last Auth Backup";
            this.btnLoadAuthBackup.UseVisualStyleBackColor = true;
            this.btnLoadAuthBackup.Click += new System.EventHandler(this.BtnLoadAuthBackup_Click);
            // 
            // grpBackupRestore
            // 
            this.grpBackupRestore.Controls.Add(this.btnBackupAuth);
            this.grpBackupRestore.Controls.Add(this.btnBackupShard);
            this.grpBackupRestore.Controls.Add(this.btnBackupWorld);
            this.grpBackupRestore.Controls.Add(this.btnLoadLastWorldBackup);
            this.grpBackupRestore.Controls.Add(this.btnLoadLastShardBackup);
            this.grpBackupRestore.Controls.Add(this.btnLoadAnAuthBackup);
            this.grpBackupRestore.Controls.Add(this.btnLoadAuthBackup);
            this.grpBackupRestore.Controls.Add(this.btnLoadAShardBacup);
            this.grpBackupRestore.Controls.Add(this.btnLoadAWorldBackup);
            this.grpBackupRestore.Location = new System.Drawing.Point(459, 97);
            this.grpBackupRestore.Name = "grpBackupRestore";
            this.grpBackupRestore.Size = new System.Drawing.Size(440, 107);
            this.grpBackupRestore.TabIndex = 4;
            this.grpBackupRestore.TabStop = false;
            this.grpBackupRestore.Text = "Backup / Restore";
            this.grpBackupRestore.Visible = false;
            // 
            // btnBackupAuth
            // 
            this.btnBackupAuth.Location = new System.Drawing.Point(6, 77);
            this.btnBackupAuth.Name = "btnBackupAuth";
            this.btnBackupAuth.Size = new System.Drawing.Size(138, 23);
            this.btnBackupAuth.TabIndex = 22;
            this.btnBackupAuth.Text = "Backup Auth Database";
            this.btnBackupAuth.UseVisualStyleBackColor = true;
            this.btnBackupAuth.Click += new System.EventHandler(this.BtnBackupAuth_Click);
            // 
            // btnBackupShard
            // 
            this.btnBackupShard.Location = new System.Drawing.Point(150, 77);
            this.btnBackupShard.Name = "btnBackupShard";
            this.btnBackupShard.Size = new System.Drawing.Size(138, 23);
            this.btnBackupShard.TabIndex = 23;
            this.btnBackupShard.Text = "Backup Shard Database";
            this.btnBackupShard.UseVisualStyleBackColor = true;
            this.btnBackupShard.Click += new System.EventHandler(this.BtnBackupShard_Click);
            // 
            // btnBackupWorld
            // 
            this.btnBackupWorld.Location = new System.Drawing.Point(294, 77);
            this.btnBackupWorld.Name = "btnBackupWorld";
            this.btnBackupWorld.Size = new System.Drawing.Size(138, 23);
            this.btnBackupWorld.TabIndex = 24;
            this.btnBackupWorld.Text = "Backup World Database";
            this.btnBackupWorld.UseVisualStyleBackColor = true;
            this.btnBackupWorld.Click += new System.EventHandler(this.BtnBackupWorld_Click);
            // 
            // grpCreatDelete
            // 
            this.grpCreatDelete.Controls.Add(this.btnLoadShardBase);
            this.grpCreatDelete.Controls.Add(this.btnCreateWorldDB);
            this.grpCreatDelete.Controls.Add(this.btnLoadAuthBase);
            this.grpCreatDelete.Controls.Add(this.btnCreateAuthDB);
            this.grpCreatDelete.Controls.Add(this.btnClearWorldData);
            this.grpCreatDelete.Controls.Add(this.btnCreateShard);
            this.grpCreatDelete.Controls.Add(this.btnClearShardData);
            this.grpCreatDelete.Controls.Add(this.btnDropWorldDB);
            this.grpCreatDelete.Controls.Add(this.btnLoadWorldBase);
            this.grpCreatDelete.Controls.Add(this.btnWorldUpdates);
            this.grpCreatDelete.Controls.Add(this.btnDropAuthDB);
            this.grpCreatDelete.Controls.Add(this.btnClearAuthData);
            this.grpCreatDelete.Controls.Add(this.btnDropShardDB);
            this.grpCreatDelete.Controls.Add(this.btnAuthUpdates);
            this.grpCreatDelete.Controls.Add(this.btnShardUpdates);
            this.grpCreatDelete.Location = new System.Drawing.Point(12, 169);
            this.grpCreatDelete.Name = "grpCreatDelete";
            this.grpCreatDelete.Size = new System.Drawing.Size(439, 166);
            this.grpCreatDelete.TabIndex = 5;
            this.grpCreatDelete.TabStop = false;
            this.grpCreatDelete.Text = "Create / Delete";
            this.grpCreatDelete.Visible = false;
            // 
            // grpDownload
            // 
            this.grpDownload.Controls.Add(this.btnBackupAllData);
            this.grpDownload.Controls.Add(this.btnDownloadAllData);
            this.grpDownload.Location = new System.Drawing.Point(12, 12);
            this.grpDownload.Name = "grpDownload";
            this.grpDownload.Size = new System.Drawing.Size(440, 52);
            this.grpDownload.TabIndex = 8;
            this.grpDownload.TabStop = false;
            this.grpDownload.Text = "Download (Required loading schema and World data, aka do first!)";
            // 
            // btnBackupAllData
            // 
            this.btnBackupAllData.Location = new System.Drawing.Point(229, 19);
            this.btnBackupAllData.Name = "btnBackupAllData";
            this.btnBackupAllData.Size = new System.Drawing.Size(205, 24);
            this.btnBackupAllData.TabIndex = 5;
            this.btnBackupAllData.Text = "Backup All Databases!";
            this.btnBackupAllData.UseVisualStyleBackColor = true;
            this.btnBackupAllData.Click += new System.EventHandler(this.BtnBackupAllData_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ACEManager.Properties.Resources.ACEMULATOR_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(457, 210);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // txtBxDBLog
            // 
            this.txtBxDBLog.CausesValidation = false;
            this.txtBxDBLog.Location = new System.Drawing.Point(459, 12);
            this.txtBxDBLog.Multiline = true;
            this.txtBxDBLog.Name = "txtBxDBLog";
            this.txtBxDBLog.ReadOnly = true;
            this.txtBxDBLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBxDBLog.Size = new System.Drawing.Size(440, 79);
            this.txtBxDBLog.TabIndex = 10;
            this.txtBxDBLog.TabStop = false;
            // 
            // DatabaseMaintenanceForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(904, 340);
            this.Controls.Add(this.txtBxDBLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpDownload);
            this.Controls.Add(this.grpCreatDelete);
            this.Controls.Add(this.grpBackupRestore);
            this.Controls.Add(this.grpSimpleMode);
            this.Controls.Add(this.groupBoxDatabase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 379);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 379);
            this.Name = "DatabaseMaintenanceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Database Maintenance";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DatabaseMaintenanceForm_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxDatabase.ResumeLayout(false);
            this.grpSimpleMode.ResumeLayout(false);
            this.grpBackupRestore.ResumeLayout(false);
            this.grpCreatDelete.ResumeLayout(false);
            this.grpDownload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblDBShardName;
        private System.Windows.Forms.Label lblDBAuthName;
        private System.Windows.Forms.GroupBox groupBoxDatabase;
        private System.Windows.Forms.Label lblDBWorldName;
        private System.Windows.Forms.TextBox txtBxDBAuthName;
        private System.Windows.Forms.TextBox txtBxDBShardName;
        private System.Windows.Forms.TextBox txtBxDBWorldName;
        private System.Windows.Forms.GroupBox grpSimpleMode;
        private System.Windows.Forms.Button btnCreateWorldDB;
        private System.Windows.Forms.Button btnCreateShard;
        private System.Windows.Forms.Button btnCreateAuthDB;
        private System.Windows.Forms.Button btnWorldUpdates;
        private System.Windows.Forms.Button btnShardUpdates;
        private System.Windows.Forms.Button btnAuthUpdates;
        private System.Windows.Forms.Button btnLoadWorldBase;
        private System.Windows.Forms.Button btnLoadShardBase;
        private System.Windows.Forms.Button btnLoadAuthBase;
        private System.Windows.Forms.Button btnDownloadAllData;
        private System.Windows.Forms.Button btnDropWorldDB;
        private System.Windows.Forms.Button btnDropShardDB;
        private System.Windows.Forms.Button btnDropAuthDB;
        private System.Windows.Forms.Button btnClearWorldData;
        private System.Windows.Forms.Button btnClearShardData;
        private System.Windows.Forms.Button btnClearAuthData;
        private System.Windows.Forms.Button btnResetAllData;
        private System.Windows.Forms.Button btnLoadAWorldBackup;
        private System.Windows.Forms.Button btnLoadAShardBacup;
        private System.Windows.Forms.Button btnLoadAnAuthBackup;
        private System.Windows.Forms.Button btnLoadLastWorldBackup;
        private System.Windows.Forms.Button btnLoadLastShardBackup;
        private System.Windows.Forms.Button btnLoadAuthBackup;
        private System.Windows.Forms.GroupBox grpBackupRestore;
        private System.Windows.Forms.Button btnBackupAuth;
        private System.Windows.Forms.Button btnBackupShard;
        private System.Windows.Forms.Button btnBackupWorld;
        private System.Windows.Forms.Button btnResetAuthDB;
        private System.Windows.Forms.GroupBox grpCreatDelete;
        private System.Windows.Forms.Button btnResetShardDB;
        private System.Windows.Forms.Button btnRestWorldDB;
        private System.Windows.Forms.CheckBox chkBxAdvanced;
        private System.Windows.Forms.GroupBox grpDownload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBxDBLog;
        private System.Windows.Forms.Button btnBackupAllData;
    }
}