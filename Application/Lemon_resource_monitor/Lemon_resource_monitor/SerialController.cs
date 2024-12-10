using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Management.Instrumentation;

namespace Lemon_resource_monitor
{
    public class SerialController
    {
        public delegate void SerialConnected();
        public event SerialConnected serialConnected = delegate { };

        public delegate void SerialDisconnected(int intent);
        public event SerialDisconnected serialDisconnected = delegate { };

        public delegate void ConnInterrupted();
        public event ConnInterrupted connInterrupted = delegate { };

        public delegate void SerialPortsChn(List<string> a);
        public event SerialPortsChn serialChn = delegate { };

        public delegate void DataRecieved(string a);
        public event DataRecieved dataRecieved = delegate { };

        public bool Connected { get; private set; }
        public bool ReadAllowed { get; private set; }

        private string portName = null;
        private SafeSerialPort port;

        public SerialController()
        {
            ReadAllowed = true;
            SerialPortService.PortsChanged += (sender1, changedArgs) 
                => SerialPortsChanged(
                    changedArgs.SerialPorts, changedArgs.EventType);
        }

        public void Connect(string comInfo, int baud = 9600, 
            Parity p = Parity.None, int dataBits = 8, 
            StopBits sb = StopBits.One, bool restartBoard = false)
        {
            if (!Connected && ReadAllowed)
            {
                string comPort = chkForTargetCOM(comInfo);
                if (comPort != "")
                    Connect_(comPort, baud, p, dataBits, sb, restartBoard);
            }
        }

        public void Disconnect()
        {
            if (Connected)
                Disconnect_(0);
        }

        public void Write(string a)
        {
            if (Connected)
            {
                port.Write(a);
            }

        }

        public void WriteLine(string a)
        {
            if (Connected)
            {
                port.WriteLine(a);
            }

        }

        public List<string> CheckAvailPortInfoMan()
        {
            List<string> a = chkForDevices();
            return a.Distinct().ToList();
        }

        private void Connect_(string comPort, int baud, 
            Parity p, int dataBits, StopBits sb, bool restartBoard)
        {
            try
            {
                port = new SafeSerialPort(
                    comPort, baud, p, dataBits, sb);
                port.DtrEnable = restartBoard;
                port.DataReceived += 
                    new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.BaseStream.Flush();
                port.DiscardInBuffer();

                Connected = true;
                portName = comPort;

                if (serialConnected != null)
                    serialConnected();
            }
            catch
            {
                if (connInterrupted != null)
                    connInterrupted();
            }
        }

        async Task PutTaskDelay()
        {
            ReadAllowed = false;
            await Task.Delay(200);
        }

        private async void Disconnect_(int intent)
        {
            await PutTaskDelay();
            port.Dispose();
            Connected = false;
            portName = "";
            ReadAllowed = true;

            if (serialDisconnected != null)
                serialDisconnected(intent);
        }

        private List<string> chkForDevices()
        {
            List<string> resPortInfo = new List<string>();
            string[] portNames = SerialPort.GetPortNames();

            using (var searcher = new ManagementObjectSearcher(
                "SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList()
                    .Select(p => p["Caption"].ToString());
                var portList = portNames.Select(
                    n => ports.FirstOrDefault(s => s.Contains(n))).ToList();

                foreach (string portInfo in portList)
                {
                    resPortInfo.Add(portInfo);
                }

                return resPortInfo;
            }
        }

        private string chkForTargetCOM(string portName)
        {
            string resComPort = "";
            string[] portNames = SerialPort.GetPortNames();

            using (var searcher = new ManagementObjectSearcher(
                "SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var ports = searcher.Get().Cast<ManagementBaseObject>()
                    .ToList().Select(p => p["Caption"].ToString());

                var portList = portNames.Select(n => n + "#" + 
                    ports.FirstOrDefault(s => s.Contains(n))).ToList();

                foreach (string portInfo in portList)
                {
                    if (portInfo.Contains(portName))
                    {
                        resComPort = portInfo.Split('#').ToArray()[0];
                        break;
                    }
                }

                return resComPort;
            }
        }

        private void SerialPortsChanged(string[] ports, EventType eventType)
        {
            if (!Connected)
            {
                List<string> portsInfo = chkForDevices();
                serialChn(portsInfo);
            }
            else if (eventType == EventType.Removal && Connected)
            {
                bool portAvailable = false;

                foreach (string port in ports)
                {
                    if (portName == port)
                        portAvailable = true;
                }
                if (!portAvailable)
                    Disconnect_(1);
            }
        }

        private void port_DataReceived(
            object sender, SerialDataReceivedEventArgs e)
        {
            if (ReadAllowed)
            {
                string a = port.ReadExisting();
                //Raise event and pass the string to listeners
                dataRecieved(a);
            }
        }
    }
}
