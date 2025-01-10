using LibreHardwareMonitor.Hardware;
using System;
using System.Management;

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
        public HardwareInfo()
        {
            Computer computer = new Computer(){
                IsGpuEnabled = true,IsCpuEnabled = true,
                //IsMemoryEnabled = true
            };
            this.computer = computer;
        }

        public void refresh()
        {
            getRamUsage();
            getCpuGpuUsage();
        }

        public void print()
        {
            printRamUsage();
            Console.WriteLine();
            printCpuUsage();
            Console.WriteLine();
            printGpuUsage();
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

        private void getCpuGpuUsage()
        {
            this.computer.Open();
            this.computer.Accept(new UpdateVisitor());

            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    this.cpuName = hardware.Name;

                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == 
                            SensorType.Temperature && 
                            sensor.Name == "Core Average")
                        {
                            this.cpuTemp = (float)sensor.Value;
                        }
                        else if (sensor.SensorType == 
                            SensorType.Load && sensor.Name == "CPU Total")
                        {
                            this.cpuLoad = (float)sensor.Value;
                        }
                    }
                }
                else if(hardware.HardwareType == HardwareType.GpuNvidia ||
                        hardware.HardwareType == HardwareType.GpuAmd ||
                        hardware.HardwareType == HardwareType.GpuIntel)
                {
                    if(hardware.HardwareType == HardwareType.GpuNvidia || 
                       !nvidiaUsed && 
                            hardware.HardwareType == HardwareType.GpuAmd ||
                       !nvidiaUsed && !amdUsed && 
                            hardware.HardwareType == HardwareType.GpuIntel)
                    {
                        this.gpuName = hardware.Name;

                        foreach (var sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == 
                                SensorType.Temperature && 
                                sensor.Name == "GPU Core")
                            {
                                this.gpuTemp = (float)sensor.Value;
                            }
                            else if (sensor.SensorType == 
                                SensorType.Load && sensor.Name == "GPU Core")
                            {
                                this.gpuLoad = (float)sensor.Value;
                            }

                            if (sensor.SensorType == 
                                SensorType.SmallData && 
                                sensor.Name == "GPU Memory Total")
                            {
                                this.gpuTotalVram = (ulong)sensor.Value;
                            }
                            else if (sensor.SensorType == 
                                SensorType.SmallData && 
                                sensor.Name == "GPU Memory Free")
                            {
                                this.gpuAvailVram = (ulong)sensor.Value;
                            }
                        }
                    }

                    if (hardware.HardwareType == HardwareType.GpuNvidia)
                        this.nvidiaUsed = true;
                    else if (hardware.HardwareType == HardwareType.GpuAmd)
                        this.amdUsed = true;
                }
            }

            this.computer.Close();
        }
    }
}
