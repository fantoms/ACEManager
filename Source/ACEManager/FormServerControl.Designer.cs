namespace ACEManager
{
    public partial class FormServerControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServerControl));
            this.btnKill = new System.Windows.Forms.Button();
            this.btnStopNow = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.rchTxtBxConsoleInput = new System.Windows.Forms.RichTextBox();
            this.chkBxAutoRestart = new System.Windows.Forms.CheckBox();
            this.lblRunningStatus = new System.Windows.Forms.Label();
            this.timerUpdateStatus = new System.Windows.Forms.Timer(this.components);
            this.btnCancelShutdown = new System.Windows.Forms.Button();
            this.consoleControl1 = new ConsoleControl.ConsoleControl();
            this.SuspendLayout();
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(485, 8);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(75, 23);
            this.btnKill.TabIndex = 0;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.BtnKill_Click);
            // 
            // btnStopNow
            // 
            this.btnStopNow.Location = new System.Drawing.Point(404, 8);
            this.btnStopNow.Name = "btnStopNow";
            this.btnStopNow.Size = new System.Drawing.Size(75, 23);
            this.btnStopNow.TabIndex = 1;
            this.btnStopNow.Text = "Stop Now!";
            this.btnStopNow.UseVisualStyleBackColor = true;
            this.btnStopNow.Click += new System.EventHandler(this.BtnStopNow_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(211, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Shutdown";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(130, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // rchTxtBxConsoleInput
            // 
            this.rchTxtBxConsoleInput.BackColor = System.Drawing.Color.Black;
            this.rchTxtBxConsoleInput.DetectUrls = false;
            this.rchTxtBxConsoleInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rchTxtBxConsoleInput.EnableAutoDragDrop = true;
            this.rchTxtBxConsoleInput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchTxtBxConsoleInput.ForeColor = System.Drawing.Color.LimeGreen;
            this.rchTxtBxConsoleInput.Location = new System.Drawing.Point(0, 371);
            this.rchTxtBxConsoleInput.Multiline = false;
            this.rchTxtBxConsoleInput.Name = "rchTxtBxConsoleInput";
            this.rchTxtBxConsoleInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rchTxtBxConsoleInput.Size = new System.Drawing.Size(813, 30);
            this.rchTxtBxConsoleInput.TabIndex = 9;
            this.rchTxtBxConsoleInput.Text = "";
            this.rchTxtBxConsoleInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RchTxtBxConsoleInput_KeyDown);
            // 
            // chkBxAutoRestart
            // 
            this.chkBxAutoRestart.AutoSize = true;
            this.chkBxAutoRestart.Location = new System.Drawing.Point(569, 12);
            this.chkBxAutoRestart.Name = "chkBxAutoRestart";
            this.chkBxAutoRestart.Size = new System.Drawing.Size(232, 17);
            this.chkBxAutoRestart.TabIndex = 10;
            this.chkBxAutoRestart.Text = "Auto-Restart Server (on failure or shutdown)";
            this.chkBxAutoRestart.UseVisualStyleBackColor = true;
            this.chkBxAutoRestart.CheckedChanged += new System.EventHandler(this.ChkBxAutoRestart_CheckedChanged);
            // 
            // lblRunningStatus
            // 
            this.lblRunningStatus.AutoSize = true;
            this.lblRunningStatus.Location = new System.Drawing.Point(40, 13);
            this.lblRunningStatus.Name = "lblRunningStatus";
            this.lblRunningStatus.Size = new System.Drawing.Size(84, 13);
            this.lblRunningStatus.TabIndex = 11;
            this.lblRunningStatus.Text = "Server: Stopped";
            // 
            // timerUpdateStatus
            // 
            this.timerUpdateStatus.Tick += new System.EventHandler(this.TimerUpdateStatus_Tick);
            // 
            // btnCancelShutdown
            // 
            this.btnCancelShutdown.Location = new System.Drawing.Point(292, 8);
            this.btnCancelShutdown.Name = "btnCancelShutdown";
            this.btnCancelShutdown.Size = new System.Drawing.Size(106, 23);
            this.btnCancelShutdown.TabIndex = 12;
            this.btnCancelShutdown.Text = "Cancel Shutdown";
            this.btnCancelShutdown.UseVisualStyleBackColor = true;
            this.btnCancelShutdown.Click += new System.EventHandler(this.BtnCancelShutdown_Click);
            // 
            // consoleControl1
            // 
            this.consoleControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleControl1.AutoScroll = true;
            this.consoleControl1.CausesValidation = false;
            this.consoleControl1.IsInputEnabled = false;
            this.consoleControl1.Location = new System.Drawing.Point(0, 41);
            this.consoleControl1.Name = "consoleControl1";
            this.consoleControl1.SendKeyboardCommandsToProcess = false;
            this.consoleControl1.ShowDiagnostics = true;
            this.consoleControl1.Size = new System.Drawing.Size(813, 330);
            this.consoleControl1.TabIndex = 8;
            // 
            // FormServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 401);
            this.Controls.Add(this.btnCancelShutdown);
            this.Controls.Add(this.lblRunningStatus);
            this.Controls.Add(this.chkBxAutoRestart);
            this.Controls.Add(this.rchTxtBxConsoleInput);
            this.Controls.Add(this.consoleControl1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStopNow);
            this.Controls.Add(this.btnKill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormServerControl";
            this.Text = "ACE Manager";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormServerControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button btnStopNow;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private ConsoleControl.ConsoleControl consoleControl1;
        private System.Windows.Forms.RichTextBox rchTxtBxConsoleInput;
        private System.Windows.Forms.CheckBox chkBxAutoRestart;
        private System.Windows.Forms.Label lblRunningStatus;
        private System.Windows.Forms.Timer timerUpdateStatus;
        private System.Windows.Forms.Button btnCancelShutdown;
    }
}
