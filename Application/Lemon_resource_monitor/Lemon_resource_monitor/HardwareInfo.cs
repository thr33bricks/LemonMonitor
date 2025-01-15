using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace hardware_info_test
{
    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }

    public class HardwareInfo
    {
        // RAM
        public ulong totalMemory = 0;
        public ulong availableMemory = 0;

        // CPU
        public string cpuName = "";
        public float cpuLoad = 0;
        public float cpuTemp = 0;

        // GPU Dedicated
        public string gpuName = "";
        public float gpuLoad = 0;
        public float gpuTemp = 0;
        public ulong gpuTotalVram = 0;
        public ulong gpuAvailVram = 0;

        private bool nvidiaUsed = false;
        private bool amdUsed = false;

        private Computer computer;
        private List<ISensor> sensors = new List<ISensor>();
        private Dictionary<IHardware, int> lastUpdate = new Dictionary<IHardware, int>();

        public HardwareInfo()
        {
            Computer computer = new Computer(){
                IsGpuEnabled = true,IsCpuEnabled = true,
                //IsMemoryEnabled = true
            };
            this.computer = computer;
            computer.Open();

            Initialize();
        }

        private void Initialize()
        {
            HashSet<SensorType> enabledSensors = new HashSet<SensorType>();
            enabledSensors.Add(SensorType.Temperature);
            enabledSensors.Add(SensorType.Load);
            enabledSensors.Add(SensorType.SmallData);

            computer.Accept(new UpdateVisitor());
            computer.Accept(new SensorVisitor(sensor =>
            {
                if (enabledSensors.Contains(sensor.SensorType))
                    sensors.Add(sensor);
            }));
        }

        public void close()
        {
            computer.Close();
        }

        public void reload()
        {
            sensors.Clear();
            lastUpdate.Clear();
            computer.Reset();

            Initialize();
        }

        public void refresh()
        {
            getRamUsage();
            getCpuGpuUsage();
        }

        private float sensorValue(ISensor sensor)
        {
            if (sensor == null)
                return 0f;

            // Update sensors hardware if last update was over 100ms ago.
            // This most likely results in one update per hardware in a polling cycle as long as polling interval is greater.
            if (!lastUpdate.TryGetValue(sensor.Hardware, out int last) || (Environment.TickCount - last) > 100)
            {
                sensor.Hardware.Update();
                lastUpdate[sensor.Hardware] = Environment.TickCount;
            }

            return sensor.Value ?? 0f;
        }

        private void getRamUsage()
        {
            using (var searcher =
                new ManagementObjectSearcher(
                    "SELECT TotalVisibleMemorySize, " +
                    "FreePhysicalMemory FROM Win32_OperatingSystem"))
            {
                foreach (var queryObj in searcher.Get())

                {
                    // Convert KB to MB
                    this.totalMemory = Convert.ToUInt64(
                        queryObj["TotalVisibleMemorySize"]) / 1024;
                    // Convert KB to MB
                    this.availableMemory = Convert.ToUInt64(
                        queryObj["FreePhysicalMemory"]) / 1024;
                }
            }
        }

        private void getCpuGpuUsage()
        {
            foreach (var s in sensors)
            {
                if (s.Hardware.HardwareType == HardwareType.Cpu)
                {
                    this.cpuName = s.Hardware.Name;

                    if (s.SensorType == 
                        SensorType.Temperature && 
                        s.Name == "Core Average")
                    {
                        this.cpuTemp = (float)sensorValue(s);
                    }
                    else if (s.SensorType == 
                        SensorType.Load && s.Name == "CPU Total")
                    {
                        this.cpuLoad = (float)sensorValue(s);
                    }
                }
                else if(s.Hardware.HardwareType == HardwareType.GpuNvidia ||
                        s.Hardware.HardwareType == HardwareType.GpuAmd ||
                        s.Hardware.HardwareType == HardwareType.GpuIntel)
                {
                    if(s.Hardware.HardwareType == HardwareType.GpuNvidia || 
                       !nvidiaUsed &&
                            s.Hardware.HardwareType == HardwareType.GpuAmd ||
                       !nvidiaUsed && !amdUsed &&
                            s.Hardware.HardwareType == HardwareType.GpuIntel)
                    {
                        this.gpuName = s.Hardware.Name;

                        if (s.SensorType == SensorType.Temperature &&
                            s.Name == "GPU Core")
                        {
                            this.gpuTemp = (float)sensorValue(s);
                        }
                        else if (s.SensorType == SensorType.Load && 
                            s.Name == "GPU Core")
                        {
                            this.gpuLoad = (float)sensorValue(s);
                        }
                        else if (s.SensorType == SensorType.Load &&
                            s.Name == "D3D 3D")
                        {
                            this.gpuLoad = (float)sensorValue(s);
                        }

                        if (s.SensorType == SensorType.SmallData &&
                            s.Name == "GPU Memory Total")
                        {
                            this.gpuTotalVram = (ulong)sensorValue(s);
                        }
                        else if (s.SensorType == SensorType.SmallData &&
                            s.Name == "GPU Memory Free")
                        {
                            this.gpuAvailVram = (ulong)sensorValue(s);
                        }
                    }

                    if (s.Hardware.HardwareType == HardwareType.GpuNvidia)
                        this.nvidiaUsed = true;
                    else if (s.Hardware.HardwareType == HardwareType.GpuAmd)
                        this.amdUsed = true;
                }
            }
        }

        private void printRamUsage()
        {
            ulong usedMemory = this.totalMemory - this.availableMemory;
            double ramUsagePercentage =
                (double)usedMemory / this.totalMemory * 100;

            Console.WriteLine(
                $"RAM Total: {this.totalMemory} MB");
            Console.WriteLine(
                $"RAM Available: {this.availableMemory} MB");
            Console.WriteLine($"RAM Usage: {ramUsagePercentage:F2}%");
        }

        private void printCpuUsage()
        {
            Console.WriteLine($"CPU: {cpuName}");
            Console.WriteLine($"CPU Temperature: {cpuTemp:F2}°C");
            Console.WriteLine($"CPU Load: {cpuLoad:F2}%");
        }

        private void printGpuUsage()
        {
            Console.WriteLine($"GPU: {gpuName}");
            Console.WriteLine($"GPU Temperature: {gpuTemp:F2}°C");
            Console.WriteLine($"GPU Load: {gpuLoad:F2}%");
            Console.WriteLine($"GPU Total VRAM: {gpuTotalVram} MB");
            Console.WriteLine($"GPU Available VRAM: {gpuAvailVram} MB");
        }

        public void print()
        {
            printRamUsage();
            Console.WriteLine();
            printCpuUsage();
            Console.WriteLine();
            printGpuUsage();
        }
    }
}
