using System;
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

namespace ACEManager
{
    public partial class FormServerControl : Form
    {
        private string aceServerPath { get; set; }
        private string aceServerExecutable { get; set; }
        private string aceServerArguments { get; set; }

        private ProcessInterface processInterface { get; set; }

        private SolidBrush statusBrush = new SolidBrush(Color.Red);
        private Graphics graphics { get; set; }
        private bool Exiting = false;

        public FormServerControl()
        {
            InitializeComponent();
            aceServerPath = ConfigManager.StartingConfiguration.AceServerPath;
            aceServerArguments = ConfigManager.StartingConfiguration.AceServerArguments;
            aceServerExecutable = ConfigManager.StartingConfiguration.AceServerExecutable;
            consoleControl1.ShowDiagnostics = false;
            consoleControl1.IsInputEnabled = false;
            processInterface = consoleControl1.ProcessInterface;
            processInterface.OnProcessOutput += ProcessInterface_OnProcessOutput;
            processInterface.OnProcessInput += ProcessInterface_OnProcessInput;
            processInterface.OnProcessError += ProcessInterface_OnProcessError;
            processInterface.OnProcessExit += ProcessInterface_OnProcessExit;
            consoleControl1.InternalRichTextBox.ReadOnly = true;
            graphics = this.CreateGraphics();
            if (ConfigManager.StartingConfiguration.EnableAutoRestart) chkBxAutoRestart.Checked = true;
            timerUpdateStatus.Enabled = true;
            timerUpdateStatus.Interval = 3000;
            timerUpdateStatus.Start();
        }

        private void UpdateStatus()
        {
            if (!Exiting)
            {
                statusBrush.Color = (processInterface.IsProcessRunning == true ? Color.LimeGreen : Color.Red);
                graphics.FillEllipse(statusBrush, new Rectangle(4, 4, 32, 32));
                lblRunningStatus.Text = @"Server: " + (processInterface.IsProcessRunning == true ? "Running" : "Stopped");
            }
        }

        public void EchoCommand(string text)
        {
            consoleControl1.WriteOutput(text + "\n", Color.LimeGreen);
        }

        public void SendServerCommand(string text, bool echo = false)
        {
            consoleControl1.WriteInput(text, Color.LimeGreen, echo);
        }

        private void StartServer()
        {
            if (!processInterface.IsProcessRunning)
                processInterface.StartProcess(Path.Combine(aceServerPath, aceServerExecutable), aceServerArguments, aceServerPath);
        }

        private void ProcessInterface_OnProcessExit(object sender, ProcessEventArgs args)
        {
            EchoCommand("Process ended.");
            Program.Log.AddLogLine(args.Content);
            Console.WriteLine(args.Content);
            UpdateStatus();
        }

        private void ProcessInterface_OnProcessError(object sender, ProcessEventArgs args)
        {
            Program.Log.AddLogLine(args.Content);
            Console.WriteLine(args.Content);
            UpdateStatus();
        }

        private void ProcessInterface_OnProcessInput(object sender, ProcessEventArgs args)
        {
            Program.Log.AddLogLine(args.Content);
            Console.WriteLine(args.Content);
        }

        private void ProcessInterface_OnProcessOutput(object sender, ProcessEventArgs args)
        {
            Program.Log.AddLogLine(args.Content);
            Console.WriteLine(args.Content);
            if (!Exiting)
            {
                consoleControl1.InternalRichTextBox.SelectionStart = consoleControl1.InternalRichTextBox.Text.Length;
                // scroll it automatically
                consoleControl1.InternalRichTextBox.ScrollToCaret();
            }
        }

        private void consoleControl1_Load(object sender, EventArgs e)
        {
            // do nothing yet
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!processInterface.IsProcessRunning)
            {
                EchoCommand("Starting...\n");
                StartServer();
                UpdateStatus();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (processInterface.IsProcessRunning)
            {
                var msg = "shutdown";
                EchoCommand(msg);
                SendServerCommand(msg);
                UpdateStatus();
            }
        }

        private void btnCancelShutdown_Click(object sender, EventArgs e)
        {
            if (processInterface.IsProcessRunning)
            {
                var msg = "cancel-shutdown";
                EchoCommand(msg);
                SendServerCommand(msg);
                UpdateStatus();
            }
        }

        private void btnStopNow_Click(object sender, EventArgs e)
        {
            if (processInterface.IsProcessRunning)
            {
                var msg = "stop-now";
                EchoCommand(msg);
                SendServerCommand(msg);
                UpdateStatus();
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (consoleControl1.IsProcessRunning)
            {
                EchoCommand("Killing process...");
                processInterface.StopProcess();
                UpdateStatus();
            }
        }

        private void consoleControl1_KeyDown(object sender, KeyEventArgs e)
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

        private void rchTxtBxConsoleInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void consoleControl1_KeyDown_1(object sender, KeyEventArgs e)
        {
            // do nothing yet
        }

        private void timerUpdateStatus_Tick(object sender, EventArgs e)
        {
            if (!processInterface.IsProcessRunning)
            {
                if (Program.Config.EnableAutoRestart)
                {
                    var msg = $"Restarting @ {DateTime.UtcNow.ToString("MM-dd-yyyy hh:mm:ss")}";
                    Program.Log.AddLogLine(msg);
                    Console.WriteLine(msg);
                    EchoCommand(msg);
                    StartServer();
                    UpdateStatus();
                }
            }
        }

        private void FormServerControl_Paint(object sender, PaintEventArgs e)
        {
            UpdateStatus();
        }

        private void chkBxAutoRestart_CheckedChanged(object sender, EventArgs e)
        {
            Program.Config.EnableAutoRestart = chkBxAutoRestart.Checked;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Does this prevent windows from shutting down?
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Final Confirm user wants to close, if connected to ssh.
            if (processInterface.IsProcessRunning)
            {
                switch (MessageBox.Show(this, "You're still running the server!\n\nAre you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        // Disables connection watcher, allowing thread to exit
                        processInterface.StopProcess();
                        Exiting = true;
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
