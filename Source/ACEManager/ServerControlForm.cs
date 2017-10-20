using System;
using System.Drawing;
using System.Windows.Forms;
using ConsoleControlAPI;
using System.IO;
using System.Threading.Tasks;

namespace ACEManager
{
    public partial class ServerControlForm : Form
    {
        private string AceServerPath { get; set; }
        private string AceServerExecutable { get; set; }
        private string AceServerArguments { get; set; }
        private ProcessInterface ProcessInterface { get; set; }
        private SolidBrush statusBrush = new SolidBrush(Color.Red);
        private Graphics Graphics { get; set; }
        private bool exitingApplication = false;
        private bool processExited = false;

        public ServerControlForm()
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
            AceServerPath = ACEManager.Config.AceServerPath;
            AceServerArguments = ACEManager.Config.AceServerArguments;
            AceServerExecutable = ACEManager.Config.AceServerExecutable;
            if (ACEManager.Config.EnableAutoRestart)
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
            if (lblRunningStatus.InvokeRequired)
            {
                lblRunningStatus.Invoke(new MethodInvoker(delegate
                {
                    lblRunningStatus.Text = @"Server: " + (ProcessInterface.IsProcessRunning == true ? "Running" : "Stopped");
                }));
            }
            else
            {
                lblRunningStatus.Text = @"Server: " + (ProcessInterface.IsProcessRunning == true ? "Running" : "Stopped");
            }

            if (!exitingApplication)
            {
                statusBrush.Color = (ProcessInterface.IsProcessRunning == true ? Color.LimeGreen : Color.Red);
                Graphics.FillEllipse(statusBrush, new Rectangle(4, 4, 32, 32));
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
            ACEManager.Log.AddLogLine(args.Content);
            UpdateStatus();
            ScrollConsole();
        }

        private void ProcessInterface_OnProcessError(object sender, ProcessEventArgs args)
        {
            if (args.Content.Length > 0 || args.Code != null)
                if (!processExited)
                {
                    EchoCommand($"Process sent error: {args.Content}");
                    ACEManager.Log.AddLogLine(args.Content);
                    UpdateStatus();
                    ScrollConsole();
                }
        }

        private void ProcessInterface_OnProcessInput(object sender, ProcessEventArgs args)
        {
            ACEManager.Log.AddLogLine(args.Content);
            ScrollConsole();
        }

        private void ProcessInterface_OnProcessOutput(object sender, ProcessEventArgs args)
        {
            ACEManager.Log.AddLogLine(args.Content);
            ScrollConsole();
        }

        private void ScrollConsole()
        {
            if (consoleControl1.InvokeRequired)
            {
                consoleControl1.Invoke(new MethodInvoker(delegate
                {
                    consoleControl1.InternalRichTextBox.SelectionStart = consoleControl1.InternalRichTextBox.Text.Length;
                    consoleControl1.InternalRichTextBox.ScrollToCaret();
                }));
            }
            else
            {
                if (!exitingApplication)
                {
                    // Locate end of console
                    consoleControl1.InternalRichTextBox.SelectionStart = consoleControl1.InternalRichTextBox.Text.Length;
                    // Scroll to it
                    consoleControl1.InternalRichTextBox.ScrollToCaret();
                }
            }
        }

        private async void LoadUsers(string[] userFileContents)
        {
            if (userFileContents.Length > 0)
            {
                // Make sure we are started, if not start and wait:
                if (!ProcessInterface.IsProcessRunning)
                {
                    EchoCommand("Starting...");
                    StartServer();
                    UpdateStatus();
                    ProcessError("You must start the server and wait for the application to reach the \"ACE >>\" prompt, before you continue too load users.");
                    return;
                }
                foreach (var line in userFileContents)
                {
                    // go through each line and strip out the user, password, permission:
                    var user = line.Split(',');
                    var msg = $"accountcreate {user[0]} {user[1]} {user[2]}";
                    EchoCommand(msg);
                    SendServerCommand(msg);
                    UpdateStatus();
                    await PutTaskDelay();
                }
            }
        }

        private async Task PutTaskDelay()
        {
            await Task.Delay(100);
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

        private string OpenUserFileDialog()
        {
            OpenFileDialog fileSelect = new OpenFileDialog();
            fileSelect.InitialDirectory = Path.GetFullPath(".");
            fileSelect.Filter = "Text files (*.text)|*.txt|All files (*.*)|*.*";
            fileSelect.FilterIndex = 4;
            fileSelect.RestoreDirectory = true;

            string filePath = "";
            if (fileSelect.ShowDialog() == DialogResult.OK)
            {
                filePath = fileSelect.FileName;
            }
            return filePath;
        }

        private void TimerUpdateStatus_Tick(object sender, EventArgs e)
        {
            // Check for configuration changes first.
            if (ACEManager.ConfigurationUpdateRequired)
            {
                var msg = $"Reloading configuration @ {DateTime.UtcNow.ToString("MM-dd-yyyy hh:mm:ss")}";
                ACEManager.Log.AddLogLine(msg);
                EchoCommand(msg);
                ReloadConfig();
                msg = $"Server Path: {AceServerPath}\\{AceServerExecutable} {AceServerArguments}";
                ACEManager.Log.AddLogLine(msg);
                EchoCommand(msg);
                ACEManager.ConfigurationUpdateRequired = false;
            }

            // Keep restarted if the setting is enabled.
            if (!ProcessInterface.IsProcessRunning && ACEManager.Config.EnableAutoRestart)
            {
                var msg = $"Restarting @ {DateTime.UtcNow.ToString("MM-dd-yyyy hh:mm:ss")}";
                ACEManager.Log.AddLogLine(msg);
                EchoCommand(msg);
                StartServer();
                UpdateStatus();
            }
        }

        private void FormServerControl_Paint(object sender, PaintEventArgs e)
        {
            UpdateStatus();
        }

        private void ChkBxAutoRestart_CheckedChanged(object sender, EventArgs e)
        {
            ACEManager.Config.EnableAutoRestart = chkBxAutoRestart.Checked;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Adapted from Cody Gray's menu context append: https://stackoverflow.com/users/366904/cody-gray

            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = NativeMethods.GetSystemMenu(this.Handle, false);

            // Add a separator
            NativeMethods.AppendMenu(hSysMenu, NativeMethods.MF_SEPARATOR, 0, string.Empty);

            // Add the menu items
            NativeMethods.AppendMenu(hSysMenu, NativeMethods.MF_STRING, NativeMethods.ext_SYSMENU_CONFIG_ID, "&Application Settings…");
            NativeMethods.AppendMenu(hSysMenu, NativeMethods.MF_STRING, NativeMethods.ext_SYSMENU_DBMAINT_ID, "&Database Maintenance…");
            NativeMethods.AppendMenu(hSysMenu, NativeMethods.MF_STRING, NativeMethods.ext_SYSMENU_USERUPLOAD_ID, "&Load Users…");
            NativeMethods.AppendMenu(hSysMenu, NativeMethods.MF_STRING, NativeMethods.ext_SYSMENU_ABOUT_ID, "&About…");
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == NativeMethods.WM_SYSCOMMAND)
                switch ((int)m.WParam)
                {
                    case NativeMethods.ext_SYSMENU_CONFIG_ID:
                        {
                            ACEManager.ConfigurationForm.ShowDialog();
                            break;
                        }
                    case NativeMethods.ext_SYSMENU_DBMAINT_ID:
                        {
                            ACEManager.DatabaseMaintenanceForm.ShowDialog();
                            break;
                        }
                    case NativeMethods.ext_SYSMENU_USERUPLOAD_ID:
                        {
                            string userFile = ACEManager.Config.UserFilePath;
                            string[] users = { };
                            // if config var exists, ask to load or ask for a folder
                            if (userFile?.Length > 0)
                            {
                                DialogResult res = MessageBox.Show($"Would you like to load the user file from: {ACEManager.Config.UserFilePath}", "Change user file path?", MessageBoxButtons.YesNoCancel);
                                switch (res)
                                {
                                    case DialogResult.Yes:
                                        break;
                                    case DialogResult.No:
                                        ACEManager.Config.UserFilePath = "";
                                        break;
                                    case DialogResult.Cancel:
                                        return;
                                }
                            }
                            if (string.IsNullOrEmpty(ACEManager.Config.UserFilePath))
                            {
                                userFile = OpenUserFileDialog();
                            }
                            if (userFile?.Length > 0)
                            {
                                ACEManager.Config.UserFilePath = userFile;
                                try
                                {
                                    users = File.ReadAllLines(userFile);
                                } catch (Exception error)
                                {
                                    ProcessError($"Error opening user file. {error.Message}");
                                }
                                finally
                                {
                                    ACEManager.Config.UserFilePath = userFile;
                                }
                            }
                            else
                            {
                                ProcessError("Error selecting user file.");
                            }

                            LoadUsers(users);
                            break;
                        }
                    case NativeMethods.ext_SYSMENU_ABOUT_ID:
                        {
                            ACEManager.AboutForm.ShowDialog();
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
                        ACEManager.Log.AddLogLine("Exiting...");
                        break;
                }
            } else
            {
                ACEManager.Log.AddLogLine("Exiting...");
            }
        }
    }
}
