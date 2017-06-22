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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAceServerPath = new System.Windows.Forms.Label();
            this.chkBxSaveLogFile = new System.Windows.Forms.CheckBox();
            this.txtBxLogDataFormat = new System.Windows.Forms.TextBox();
            this.txtBxLogFilenameFormat = new System.Windows.Forms.TextBox();
            this.chkBxAutoRestart = new System.Windows.Forms.CheckBox();
            this.txtBxLocalLogPath = new System.Windows.Forms.TextBox();
            this.txtBxAceServerArgs = new System.Windows.Forms.TextBox();
            this.txtBxAceServerExe = new System.Windows.Forms.TextBox();
            this.txtBxAceServerPath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
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
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
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
            this.splitContainer1.Size = new System.Drawing.Size(361, 292);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Enable Auto-Restart:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Save Log File:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Log Data Format:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Log Filename Format:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Local Log Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ace Server Arguments:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ace Server Executable:";
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 336);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(407, 375);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(407, 375);
            this.Name = "ConfigurationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Application Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAceServerPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxAceServerArgs;
        private System.Windows.Forms.TextBox txtBxAceServerExe;
        private System.Windows.Forms.TextBox txtBxAceServerPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxLogDataFormat;
        private System.Windows.Forms.TextBox txtBxLogFilenameFormat;
        private System.Windows.Forms.TextBox txtBxLocalLogPath;
        private System.Windows.Forms.CheckBox chkBxSaveLogFile;
        private System.Windows.Forms.CheckBox chkBxAutoRestart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}