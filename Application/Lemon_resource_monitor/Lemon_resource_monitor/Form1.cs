using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.TaskScheduler;
using hardware_info_test;
using Microsoft.Win32;

namespace Lemon_resource_monitor
{
    public partial class Form1 : Form
    {
        int updateInterval = 1; // in seconds
        int packetCounter = 9; 
        string settingsFilePath = "settings.json"; // realative to the .exe file
        string appName = "LemonMonitor";
        Settings settings;
        SerialController serial;
        HardwareInfo hwInfo;

        #region Movable
        //====================================================================================
        //Declarations used for making the form movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //====================================================================================
        //Events to make the form movable

        private void CheckBeingMoved(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelUpper_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void lblFormHeading_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void pbPattern_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void lblQu_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        //====================================================================================
        #endregion

        #region Snappable
        private const int SnapDist = 100;
        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            Screen scn = Screen.FromPoint(this.Location);
            if (DoSnap(this.Left, scn.WorkingArea.Left)) this.Left = scn.WorkingArea.Left;
            if (DoSnap(this.Top, scn.WorkingArea.Top)) this.Top = scn.WorkingArea.Top;
            if (DoSnap(scn.WorkingArea.Right, this.Right)) this.Left = scn.WorkingArea.Right - this.Width;
            if (DoSnap(scn.WorkingArea.Bottom, this.Bottom)) this.Top = scn.WorkingArea.Bottom - this.Height;
        }
        #endregion

        public Form1()
        {
            InitializeComponent();

            settings = new Settings(settingsFilePath);
            serial = new SerialController();
            hwInfo = new HardwareInfo();

            // Show form if no device is selected
            if (settings.Port != "")
            {
                this.ShowInTaskbar = false;
                HideForm();
            }
            notifyIcon1.Visible = true;

            serial.serialConnected += serial_connected;
            serial.serialDisconnected += serial_disconnected;
            serial.serialChn += serial_portsChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial_portsChanged(serial.CheckAvailPortInfoMan());
            LoadSettingsForm();
            CheckAutoStart();
            StartMainThread();
        }

        #region Title bar buttons
        private void form_mini_MouseEnter(object sender, EventArgs e)
        {
            form_mini.BackColor = ColorTranslator.FromHtml("#272a2e");
        }

        private void form_mini_MouseLeave(object sender, EventArgs e)
        {
            form_mini.BackColor = ColorTranslator.FromHtml("#202225");
        }

        private void form_mini_MouseDown(object sender, MouseEventArgs e)
        {
            form_mini.BackColor = ColorTranslator.FromHtml("#2b2e32");
        }

        private void form_mini_MouseUp(object sender, MouseEventArgs e)
        {
            form_mini.BackColor = ColorTranslator.FromHtml("#272a2e");
        }

        private void formClose_MouseEnter(object sender, EventArgs e)
        {
            Image close_clicked = Properties.Resources.close_clicked;
            formClose.BackColor = ColorTranslator.FromHtml("#f04747");
            pbClose.Image = (Image)(new Bitmap(close_clicked));
        }

        private void formClose_MouseLeave(object sender, EventArgs e)
        {
            Image close = Properties.Resources.close;
            formClose.BackColor = ColorTranslator.FromHtml("#202225");
            pbClose.Image = (Image)(new Bitmap(close));
        }

        private void form_mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void formClose_Click(object sender, EventArgs e)
        {
            if (settings.Background)
            {
                HideForm();
                return;
            }
            ExitApp();
        }
        #endregion

        #region Button About
        private void btnAboutOut_Click(object sender, EventArgs e)
        {
            btnAbout_Click();
        }

        private void btnAboutOut_MouseEnter(object sender, EventArgs e)
        {
            btnAbout_MouseEnter();
        }

        private void btnAboutOut_MouseLeave(object sender, EventArgs e)
        {
            btnAbout_MouseLeave();
        }

        private void btnAboutIn_Click(object sender, EventArgs e)
        {
            btnAbout_Click();
        }

        private void btnAboutIn_MouseEnter(object sender, EventArgs e)
        {
            btnAbout_MouseEnter();
        }

        private void btnAboutIn_MouseLeave(object sender, EventArgs e)
        {
            btnAbout_MouseLeave();
        }

        private void lblBtnAbout_Click(object sender, EventArgs e)
        {
            btnAbout_Click();
        }

        private void lblBtnAbout_MouseEnter(object sender, EventArgs e)
        {
            btnAbout_MouseEnter();
        }

        private void lblBtnAbout_MouseLeave(object sender, EventArgs e)
        {
            btnAbout_MouseLeave();
        }

        private void btnAbout_Click()
        {
            frmAbout about = new frmAbout();
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog(this);
        }

        private void btnAbout_MouseEnter()
        {
            btnAboutOut.BackColor = Color.FromArgb(0, 122, 204);
            btnAboutIn.BackColor = Color.LightGray;
        }

        private void btnAbout_MouseLeave()
        {
            btnAboutOut.BackColor = Color.DimGray;
            btnAboutIn.BackColor = Color.Gainsboro;
        }
        #endregion

        #region Misc
        private void pnlMain_Click(object sender, EventArgs e)
        {
            pnlMain.Focus();
        }

        private void pbPattern_Click(object sender, EventArgs e)
        {
            pnlMain.Focus();
        }

        private void pnlMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pnlMain.Focus();
        }

        private void LoadSettingsForm()
        {
            cbAutostart.Checked = settings.AutoStart;
            cbBackground.Checked = settings.Background;
            cbAutoPort.Checked = settings.AutoPort;

            if(!settings.AutoPort)
                cbPorts.SelectedItem = settings.Port;
        }

        private void CheckAutoStart()
        {
            using (TaskService taskService = new TaskService())
            {
                Task task = taskService.GetTask(appName);
                if(task == null && settings.AutoStart)
                {
                    // Add task to task scheduler
                    TaskDefinition taskDefinition = taskService.NewTask();
                    taskDefinition.RegistrationInfo.Description = "Start " + appName + " at login";
                    taskDefinition.Principal.RunLevel = TaskRunLevel.Highest; // Runs with admin privileges
                    taskDefinition.Triggers.Add(new LogonTrigger());
                    taskDefinition.Actions.Add(new ExecAction(Application.ExecutablePath, null, null));
                    taskService.RootFolder.RegisterTaskDefinition(appName, taskDefinition);
                }
                else if(task != null && !settings.AutoStart)
                    taskService.RootFolder.DeleteTask(appName);
            }
        }
        #endregion

        #region Serial comm
        void serial_portsChanged(List<string> portsInfo)
        {
            MethodInvoker mi1 = delegate ()
            {
                cbPorts.Items.Clear();

                foreach (string portInfo in portsInfo)
                {
                    try
                    {
                        if (portInfo != "")
                            cbPorts.Items.Add(portInfo);
                    }
                    catch { }
                }
                if (cbPorts.Items.Count == 0)
                {
                    cbPorts.Items.Add("No devices available...");
                    cbPorts.Enabled = false;
                    cbPorts.SelectedIndex = 0;
                }
                else if (cbPorts.Items.Count > 0)
                {
                    if(!cbAutoPort.Checked)
                        cbPorts.Enabled = true;
                    if(settings.Port != "")
                        cbPorts.SelectedItem = settings.Port;
                }
            };
            Invoke(mi1);
        }

        private void serial_connected()
        {
        }

        private void serial_disconnected(int intent)
        {
            serial_portsChanged(serial.CheckAvailPortInfoMan());
        }
        #endregion

        #region MainThread
        private void StartMainThread()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    MainThread();
                    Thread.Sleep(updateInterval * 1000); // Wait for x seconds
                }
            });

            thread.IsBackground = true; // Optional: Set as background thread
            thread.Start();
        }

        private void MainThread()
        {
            CheckConnection();
            TryConnect();

            if (serial.Connected)
                SendPerformanceData();
        }

        private void CheckConnection()
        {
            if (settings.AutoPort && !serial.Connected)
            {
                List<string> availPorts = cbPorts.Items.Cast<string>().ToList();
                foreach (string port in availPorts)
                {
                    if (port.Contains("CH340"))
                    {
                        MethodInvoker mi1 = delegate ()
                        {cbPorts.SelectedItem = port;};
                        Invoke(mi1);
                        
                        break;
                    }
                }
            }
        }

        private void TryConnect()
        {
            if(!serial.Connected)
                serial.Connect(settings.Port);
        }

        private void SendPerformanceData()
        {
            string packet = BuildPerformancePacket();
            serial.Write(packet);
        }

        private string TwoDecimalPlaces(float val)
        {
            return string.Format("{0:F2}", val);
        }

        private string BuildPerformancePacket()
        {
            string res = "";
            packetCounter++;
            if (packetCounter == 12)
                packetCounter = 1;

            hwInfo.refresh();

            if(packetCounter == 10)
                res = String.Format("<{0},{1}>", 0, hwInfo.cpuName);
            else if(packetCounter == 11)
                res = String.Format("<{0},{1}>", 1, hwInfo.gpuName);
            else
            {
                res = String.Format("<{0},{1},{2},{3},{4},{5},{6},{7},{8}>",
                    2, hwInfo.totalMemory, hwInfo.availableMemory, 
                    TwoDecimalPlaces(hwInfo.cpuTemp),
                    TwoDecimalPlaces(hwInfo.cpuLoad),
                    TwoDecimalPlaces(hwInfo.gpuTemp),
                    TwoDecimalPlaces(hwInfo.gpuLoad),
                    hwInfo.gpuTotalVram, hwInfo.gpuAvailVram);
            }
            return res;
        }
        #endregion

        #region Controls
        private void cbAutostart_CheckedChanged(object sender, EventArgs e)
        {
            settings.AutoStart = cbAutostart.Checked;
            settings.SaveSettings();
            CheckAutoStart();
        }

        private void cbBackground_CheckedChanged(object sender, EventArgs e)
        {
            settings.Background = cbBackground.Checked;
            settings.SaveSettings();
        }

        private void cbAutoPort_CheckedChanged(object sender, EventArgs e)
        {
            serial_portsChanged(serial.CheckAvailPortInfoMan());
            if (cbAutoPort.Checked)
                cbPorts.Enabled = false;

            if (settings.Port != "")
                cbPorts.SelectedItem = settings.Port;

            settings.AutoPort = cbAutoPort.Checked;
            settings.SaveSettings();
        }

        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selItem = cbPorts.SelectedItem.ToString();
            if (selItem == "No devices available...")
                return;

            settings.Port = selItem;
            settings.SaveSettings();

            if(serial.Connected)
                serial.Disconnect();
        }
        #endregion

        #region SystemTray
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void RestoreForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreForm();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            RestoreForm();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideForm();
        }

        private void HideForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void ExitApp()
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }
        #endregion
    }
}
