﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleControlAPI;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ACEManager
{
    public partial class FormServerControl : Form
    {
        // About form constants
        // P/Invoke constants
        private const int WM_SYSCOMMAND = 0x112;
        private const int MF_STRING = 0x0;
        private const int MF_SEPARATOR = 0x800;

        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);

        /// <summary>
        /// ID for the Config item on the system menu
        /// </summary>
        private const int ext_SYSMENU_CONFIG_ID = 0x1;
        /// <summary>
        /// ID for the Database Maintenance item on the system menu
        /// </summary>
        private const int ext_SYSMENU_DBMAINT_ID = 0x2;
        /// <summary>
        /// ID for the About item on the system menu
        /// </summary>
        private const int ext_SYSMENU_ABOUT_ID = 0x3;

        private string AceServerPath { get; set; }
        private string AceServerExecutable { get; set; }
        private string AceServerArguments { get; set; }
        private ProcessInterface ProcessInterface { get; set; }
        private SolidBrush statusBrush = new SolidBrush(Color.Red);
        private Graphics Graphics { get; set; }
        private bool exitingApplication = false;
        private bool processExited = false;

        public FormServerControl()
        {
            InitializeComponent();
            AceServerPath = ConfigManager.StartingConfiguration.AceServerPath;
            AceServerArguments = ConfigManager.StartingConfiguration.AceServerArguments;
            AceServerExecutable = ConfigManager.StartingConfiguration.AceServerExecutable;
            consoleControl1.ShowDiagnostics = false;
            consoleControl1.IsInputEnabled = false;
            ProcessInterface = consoleControl1.ProcessInterface;
            ProcessInterface.OnProcessOutput += ProcessInterface_OnProcessOutput;
            ProcessInterface.OnProcessInput += ProcessInterface_OnProcessInput;
            ProcessInterface.OnProcessError += ProcessInterface_OnProcessError;
            ProcessInterface.OnProcessExit += ProcessInterface_OnProcessExit;
            consoleControl1.InternalRichTextBox.ReadOnly = true;
            Graphics = this.CreateGraphics();
            if (ConfigManager.StartingConfiguration.EnableAutoRestart) chkBxAutoRestart.Checked = true;
            timerUpdateStatus.Enabled = true;
            timerUpdateStatus.Interval = 3000;
            timerUpdateStatus.Start();
        }

        public void ReloadConfig()
        {
            AceServerPath = Program.Config.AceServerPath;
            AceServerArguments = Program.Config.AceServerArguments;
            AceServerExecutable = Program.Config.AceServerExecutable;
            if (Program.Config.EnableAutoRestart)
                chkBxAutoRestart.Checked = true;
            else
                chkBxAutoRestart.Checked = false;
        }

        /// <summary>
        /// Starts the ACE Server process.
        /// </summary>
        public void StartServer()
        {
            processExited = false;

            if (!ProcessInterface.IsProcessRunning)
            {
                var result = ProcessInterface.StartProcessResult(Path.Combine(AceServerPath, AceServerExecutable), AceServerArguments, AceServerPath);
                if (result.Length > 0)
                {
                    ProcessError(result);
                }
                else
                    EchoCommand("... Started!");
            }
        }

        /// <summary>
        /// Updates function to draw the Ellipse status icon.
        /// </summary>
        public void UpdateStatus()
        {
            if (!exitingApplication)
            {
                statusBrush.Color = (ProcessInterface.IsProcessRunning == true ? Color.LimeGreen : Color.Red);
                Graphics.FillEllipse(statusBrush, new Rectangle(4, 4, 32, 32));
                lblRunningStatus.Text = @"Server: " + (ProcessInterface.IsProcessRunning == true ? "Running" : "Stopped");
            }
        }
        
        /// <summary>
        /// Prints green text in the console.
        /// </summary>
        /// <param name="text"></param>
        public void EchoCommand(string text)
        {
            consoleControl1.WriteOutput(text + "\n", Color.LimeGreen);
            ScrollConsole();
        }

        /// <summary>
        /// Prints red error text in the console.
        /// </summary>
        /// <param name="text"></param>
        public void ProcessError(string text)
        {
            consoleControl1.WriteOutput(text + "\n", Color.Red);
            ScrollConsole();
        }

        public void SendServerCommand(string text, bool echo = false)
        {
            consoleControl1.WriteInput(text, Color.LimeGreen, echo);
            ScrollConsole();
        }

        private void ProcessInterface_OnProcessExit(object sender, ProcessEventArgs args)
        {
            processExited = true;
            EchoCommand($"Process ended: {args.Content}");
            Program.Log.AddLogLine(args.Content);
            UpdateStatus();
            ScrollConsole();
        }

        private void ProcessInterface_OnProcessError(object sender, ProcessEventArgs args)
        {
            if (!processExited)
            {
                EchoCommand($"Process sent error: {args.Content}");
                Program.Log.AddLogLine(args.Content);
                UpdateStatus();
                ScrollConsole();
            }
        }

        private void ProcessInterface_OnProcessInput(object sender, ProcessEventArgs args)
        {
            Program.Log.AddLogLine(args.Content);
            ScrollConsole();
        }

        private void ProcessInterface_OnProcessOutput(object sender, ProcessEventArgs args)
        {
            Program.Log.AddLogLine(args.Content);
            ScrollConsole();
        }

        private void ScrollConsole()
        {
            if (!exitingApplication)
            {
                // Locate end of console
                consoleControl1.InternalRichTextBox.SelectionStart = consoleControl1.InternalRichTextBox.Text.Length;
                // Scroll to it
                consoleControl1.InternalRichTextBox.ScrollToCaret();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!ProcessInterface.IsProcessRunning)
            {
                EchoCommand("Starting...");
                StartServer();
                UpdateStatus();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (ProcessInterface.IsProcessRunning)
            {
                var msg = "shutdown";
                EchoCommand(msg);
                SendServerCommand(msg);
                UpdateStatus();
            }
        }

        private void BtnCancelShutdown_Click(object sender, EventArgs e)
        {
            if (ProcessInterface.IsProcessRunning)
            {
                var msg = "cancel-shutdown";
                EchoCommand(msg);
                SendServerCommand(msg);
                UpdateStatus();
            }
        }

        private void BtnStopNow_Click(object sender, EventArgs e)
        {
            if (ProcessInterface.IsProcessRunning)
            {
                var msg = "stop-now";
                EchoCommand(msg);
                SendServerCommand(msg);
                UpdateStatus();
            }
        }

        private void BtnKill_Click(object sender, EventArgs e)
        {
            if (consoleControl1.IsProcessRunning)
            {
                EchoCommand("Killing process...");
                ProcessInterface.StopProcess();
                UpdateStatus();
            }
        }

        private void RchTxtBxConsoleInput_KeyDown(object sender, KeyEventArgs e)
        {
            if ((char)e.KeyCode == (char)13)
            {
                ConsoleInputSend();
                rchTxtBxConsoleInput.Focus();
            }
            return;
        }

        private void ConsoleInputSend()
        {
            if (rchTxtBxConsoleInput.TextLength > 0)
            {
                EchoCommand(rchTxtBxConsoleInput.Text);
                consoleControl1.WriteInput(rchTxtBxConsoleInput.Text, Color.LimeGreen, false);
            }
            rchTxtBxConsoleInput.Clear();
        }

        private void TimerUpdateStatus_Tick(object sender, EventArgs e)
        {
            if (!ProcessInterface.IsProcessRunning && Program.Config.EnableAutoRestart)
            {
                var msg = $"Restarting @ {DateTime.UtcNow.ToString("MM-dd-yyyy hh:mm:ss")}";
                Program.Log.AddLogLine(msg);
                EchoCommand(msg);
                StartServer();
                UpdateStatus();
            }

            if (Program.ConfigurationUpdated)
            {
                ReloadConfig();
                Program.ConfigurationUpdated = false;
            }
        }

        private void FormServerControl_Paint(object sender, PaintEventArgs e)
        {
            UpdateStatus();
        }

        private void ChkBxAutoRestart_CheckedChanged(object sender, EventArgs e)
        {
            Program.Config.EnableAutoRestart = chkBxAutoRestart.Checked;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Adapted from Cody Gray's menu context append: https://stackoverflow.com/users/366904/cody-gray

            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(this.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the menu items
            AppendMenu(hSysMenu, MF_STRING, ext_SYSMENU_CONFIG_ID, "&Application Settings…");
            AppendMenu(hSysMenu, MF_STRING, ext_SYSMENU_DBMAINT_ID, "&Database Maintenance…");
            AppendMenu(hSysMenu, MF_STRING, ext_SYSMENU_ABOUT_ID, "&About…");
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_SYSCOMMAND)
                switch ((int)m.WParam)
                {
                    case ext_SYSMENU_CONFIG_ID:
                        {
                            Program.ConfigurationForm.ShowDialog();
                            break;
                        }
                    case ext_SYSMENU_DBMAINT_ID:
                        {
                            break;
                        }
                    case ext_SYSMENU_ABOUT_ID:
                        {
                            Program.AboutForm.ShowDialog();
                            break;
                        }
                }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Does this prevent windows from shutting down?
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Final Confirm user wants to close, if connected to ssh.
            if (ProcessInterface.IsProcessRunning)
            {
                switch (MessageBox.Show(this, "The server is still active!\n\nAre you sure you want to kill the server?\n\nPerforming this action will hard-stop the server, without allowing it too shutdown properly\n\nPlease click on the Cancel button below and use the shutdown command, before closing the application.\n\n*WARNING: AFTER CLICKING OK DATA LOSS MAY OCCUR*", "Active Server Exit Warning", MessageBoxButtons.OKCancel))
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        // Disables connection watcher, allowing thread to exit
                        ProcessInterface.StopProcess();
                        exitingApplication = true;
                        Program.Log.AddLogLine("Exiting...");
                        break;
                }
            } else
            {
                Program.Log.AddLogLine("Exiting...");
            }
        }
    }
}
