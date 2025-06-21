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
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Gma.System.MouseKeyHook;
using System.Collections;

namespace Lemon_resource_monitor
{
    public partial class Form1 : Form
    {
        int updateInterval = 200; // in ms
        string settingsFilePath = "settings.json"; // realative to the .exe file
        string appName = "LemonMonitor";
        string autoPort = "";
        bool leftAction = false;
        bool rightAction = false;
        bool firstConnect = true;
        Settings settings;
        SerialController serial;
        HardwareInfo hwInfo;
        FPSInfo fpsInfo;
        Mutex mutex;

        IKeyboardMouseEvents globalHook;

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

        #region Form
        public Form1()
        {
            InitializeComponent();
            CloseIfAnotherInstanceRunning();

            settings = new Settings(settingsFilePath);
            serial = new SerialController();
            hwInfo = new HardwareInfo();
            fpsInfo = new FPSInfo();

            // Show form if no device is selected
            if (!String.IsNullOrEmpty(settings.Port))
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
            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHook_KeyDown;

            serial_portsChanged(serial.CheckAvailPortInfoMan());
            LoadSettingsForm();
            CheckAutoStart();
            StartMainThread();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            globalHook.KeyDown -= GlobalHook_KeyDown;
            globalHook.Dispose();
        }
        #endregion

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

            rbScrolling.Checked = settings.Scrolling;
            rbSwitch.Checked = !settings.Scrolling;
            cbDividers.Checked = settings.Dividers;

            List<string> keysLeft = new List<string>();
            if (settings.KeyLeft1 != "")
                keysLeft.Add(settings.KeyLeft1);
            keysLeft.Add(settings.KeyLeft2.ToString());
            tbLeft.Text = string.Join("+", keysLeft).ToString();

            List<string> keysRight = new List<string>();
            if (settings.KeyRight1 != "")
                keysRight.Add(settings.KeyRight1);
            keysRight.Add(settings.KeyRight2.ToString());
            tbRight.Text = string.Join("+", keysRight).ToString();

            if (!settings.AutoPort)
                cbPorts.SelectedItem = settings.Port;
        }

        private void CheckAutoStart()
        {
            using (TaskService taskService = new TaskService())
            {
                Task task = taskService.GetTask(appName);
                if(settings.AutoStart)
                {
                    // Delete the task first if available
                    if(task != null)
                        taskService.RootFolder.DeleteTask(appName);

                    // Add task to task scheduler
                    TaskDefinition taskDefinition = taskService.NewTask();
                    taskDefinition.RegistrationInfo.Description = "Start " + appName + " at login";
                    taskDefinition.Principal.RunLevel = TaskRunLevel.Highest; // Runs with admin privileges
                    taskDefinition.Triggers.Add(new LogonTrigger());
                    taskDefinition.Actions.Add(new ExecAction(Application.ExecutablePath, null, null));

                    taskDefinition.Settings.DisallowStartIfOnBatteries = false;
                    taskDefinition.Settings.StopIfGoingOnBatteries = false;
                    taskDefinition.Settings.AllowHardTerminate = false;
                    taskDefinition.Settings.StartWhenAvailable = true;

                    taskService.RootFolder.RegisterTaskDefinition(appName, taskDefinition);
                }
                else if(task != null && !settings.AutoStart)
                    taskService.RootFolder.DeleteTask(appName);
            }
        }

        private void CloseIfAnotherInstanceRunning()
        {
            bool isNewInstance;
            mutex = new Mutex(true, "Lemon_resource_monitor", out isNewInstance);

            if (!isNewInstance)
            {
                ExitApp();
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
                    if(!String.IsNullOrEmpty(settings.Port))
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
            autoPort = "";
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
                    Thread.Sleep(updateInterval); // Wait for x seconds
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
                SendData();
        }

        private void CheckConnection()
        {
            if (settings.AutoPort && !serial.Connected)
            {
                List<string> availPorts = cbPorts.Items.Cast<string>().ToList();
                foreach (string port in availPorts)
                {
                    if (port.Contains("CH340"))// || port.Contains("Arduino"))
                    {
                        MethodInvoker mi1 = delegate ()
                        {cbPorts.SelectedItem = port; autoPort = port; };
                        Invoke(mi1);
                        
                        break;
                    }
                }
            }
        }

        private void TryConnect()
        {
            if (!settings.AutoPort && !serial.Connected && !String.IsNullOrEmpty(settings.Port))
                serial.Connect(settings.Port);
            if (settings.AutoPort && !serial.Connected && !String.IsNullOrEmpty(autoPort))
            {
                firstConnect = true;
                serial.Connect(autoPort);
                Thread.Sleep(2000);
            }
        }

        private void SendData()
        {
            byte[] dataFirstPart;
            if (firstConnect)
            {
                firstConnect = false;
                FPSInfo.InitFPS();

                dataFirstPart = BuildFirstPartPacket(true);
                serial.WriteBytes(dataFirstPart, 0, dataFirstPart.Length);

                Thread.Sleep(200);

                byte[] dataSecondPart = BuildSecondPartPacket();
                serial.WriteBytes(dataSecondPart, 0, dataSecondPart.Length);

                return;
            }

            dataFirstPart = BuildFirstPartPacket();
            serial.WriteBytes(dataFirstPart, 0, dataFirstPart.Length);
        }

        int ClampInt(int val, int max)
        {
            return Math.Max(Math.Min(val, max), 1);
        }

        private byte[] BuildFirstPartPacket(bool fullBuffer = false)
        {
            byte[] data = new byte[46];

            FPSInfo.UpdateFPS();
            hwInfo.refresh();

            // Full buffer or not
            data[2] = 0x57;
            if (fullBuffer)
                data[2] = 0xD9;

            // Save fps values
            int currFps = ClampInt((int)(FPSInfo.FPS+0.5), 2047);
            int avgFps = ClampInt((int)(FPSInfo.avgFPS + 0.5), 2047);
            int onePer = ClampInt((int)(FPSInfo.onePercentLow + 0.5), 99);
            int combined = (currFps << 21) | (avgFps << 10) | onePer;

            for (int i = 0; i < 4; i++)
            {
                data[3 + i] = (byte)((combined >> ((3 - i) * 8)) & 0xFF);
            }

            // RAM percentage
            data[7] = (byte)(((float)hwInfo.availableMemory / (float)hwInfo.totalMemory) * 100.0F + 0.5F);

            //CPU temperature and load
            data[8] = (byte)ClampInt((int)(hwInfo.cpuTemp + 0.5F), 255);
            data[9] = (byte)(hwInfo.cpuLoad + 0.5F);

            //GPU temperature and load
            data[10] = (byte)ClampInt((int)(hwInfo.gpuTemp + 0.5F), 255);
            data[11] = (byte)(hwInfo.gpuLoad + 0.5F);

            // Mode (scrolling/switch), keyboard action and dividers
            int mode = settings.Scrolling ? 1 : 2;
            int kbdAct = leftAction ? 2 : (rightAction ? 3 : 1);
            int div = settings.Dividers ? 1 : 2;

            data[12] = (byte)(((mode & 3) << 6) | ((kbdAct & 15) << 2) | (div & 3));

            // Default states for actions
            leftAction = false;
            rightAction = false;

            // VRAM
            data[13] = (byte)(((float)hwInfo.gpuAvailVram / (float)hwInfo.gpuTotalVram) * 100.0F + 0.5F);

            // FPS bar graph
            byte[] barGraph = FPSInfo.getFPSbarsS1();
            for (int i = 0; i < 32; ++i)
                data[14 + i] = barGraph[i];

            return data;
        }

        private byte[] BuildSecondPartPacket()
        {
            byte[] data = new byte[64];

            for (int i = 0; i < Math.Min(hwInfo.cpuName.Length, 31); ++i)
                data[i] = (byte)hwInfo.cpuName[i];

            for (int i = 0; i < Math.Min(hwInfo.gpuName.Length, 31); ++i)
                data[i+32] = (byte)hwInfo.gpuName[i];

            return data;
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

            if (!String.IsNullOrEmpty(settings.Port))
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

        private void cbDividers_CheckedChanged(object sender, EventArgs e)
        {
            settings.Dividers = cbDividers.Checked;
            settings.SaveSettings();
        }

        private void rbScrolling_CheckedChanged(object sender, EventArgs e)
        {
            settings.Scrolling = rbScrolling.Checked;
            settings.SaveSettings();
        }
        #endregion

        #region SystemTray
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void RestoreForm()
        {
            this.ShowInTaskbar = true;
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
            if(hwInfo != null) hwInfo.close();
            if(fpsInfo != null) fpsInfo.StopFPS();
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }
        #endregion

        #region KeysHook
        private void tbLeft_KeyDown(object sender, KeyEventArgs e)
        {
            List<string> keys = new List<string>();
            string keyLeft1 = "";

            if (e.Control) keyLeft1 = "Ctrl";
            if (e.Alt) keyLeft1 = "Alt";
            if (e.Shift) keyLeft1 = "Shift";
            if (keyLeft1 != "")
            {
                keys.Add(keyLeft1);
                settings.KeyLeft1 = keyLeft1;
            }

            keys.Add(e.KeyCode.ToString());
            settings.KeyLeft2 = e.KeyCode;

            keys.RemoveAll(s => s.Length > 1 && s!="Ctrl" && s != "Alt" && s!="Shift");
            tbLeft.Text = string.Join("+", keys);

            settings.SaveSettings();
            e.SuppressKeyPress = true;
        }

        private void tbRight_KeyDown(object sender, KeyEventArgs e)
        {
            List<string> keys = new List<string>();
            string keyRight1 = "";

            if (e.Control) keyRight1 = "Ctrl";
            if (e.Alt) keyRight1 = "Alt";
            if (e.Shift) keyRight1 = "Shift";
            if (keyRight1 != "")
            {
                keys.Add(keyRight1);
                settings.KeyRight1 = keyRight1;
            }

            keys.Add(e.KeyCode.ToString());
            settings.KeyRight2 = e.KeyCode;

            keys.RemoveAll(s => s.Length > 1 && s != "Ctrl" && s != "Alt" && s != "Shift");
            tbRight.Text = string.Join("+", keys);

            settings.SaveSettings();
            e.SuppressKeyPress = true;
        }

        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            bool keyLeft1 = false;
            bool keyRight1 = false;

            if (settings.KeyLeft1 == "Ctrl" && e.Control) keyLeft1 = true;
            else if (settings.KeyLeft1 == "Alt" && e.Alt) keyLeft1 = true;
            else if (settings.KeyLeft1 == "Shift" && e.Shift) keyLeft1 = true;

            if (settings.KeyRight1 == "Ctrl" && e.Control) keyRight1 = true;
            else if (settings.KeyRight1 == "Alt" && e.Alt) keyRight1 = true;
            else if (settings.KeyRight1 == "Shift" && e.Shift) keyRight1 = true;

            if (keyLeft1 && e.KeyCode == settings.KeyLeft2)
            {
                leftAction = true;
            }

            if (keyRight1 && e.KeyCode == settings.KeyRight2)
            {
                rightAction = true;
            }
        }
        #endregion
    }
}
