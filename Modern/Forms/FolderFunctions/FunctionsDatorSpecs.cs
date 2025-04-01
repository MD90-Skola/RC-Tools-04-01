using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Modern.Forms.FolderFunctions
{
    public static class FunctionsDatorSpecs
    {
        public static string HämtaCPU()
        {
            using (var searcher = new ManagementObjectSearcher("select Name from Win32_Processor"))
            {
                foreach (var item in searcher.Get())
                    return item["Name"]?.ToString();
            }
            return "Ej hittad";
        }

        public static string[] HämtaGPUer()
        {
            var lista = new List<string>();
            using (var searcher = new ManagementObjectSearcher("select Name from Win32_VideoController"))
            {
                foreach (var item in searcher.Get())
                    lista.Add(item["Name"]?.ToString());
            }
            return lista.ToArray();
        }

        public static string HämtaRAM()
        {
            ulong totalMemory = 0;
            using (var searcher = new ManagementObjectSearcher("Select Capacity from Win32_PhysicalMemory"))
            {
                foreach (var item in searcher.Get())
                    totalMemory += Convert.ToUInt64(item["Capacity"]);
            }
            return (totalMemory / (1024 * 1024 * 1024)) + " GB";
        }

        public static string HämtaModerkort()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT Manufacturer, Product FROM Win32_BaseBoard"))
            {
                foreach (var item in searcher.Get())
                {
                    return $"{item["Manufacturer"]} {item["Product"]}";
                }
            }
            return "Ej hittat";
        }

        public static string HämtaDisk()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT Model, Size FROM Win32_DiskDrive"))
            {
                foreach (var item in searcher.Get())
                {
                    var storlekGB = Convert.ToUInt64(item["Size"]) / (1024 * 1024 * 1024);
                    return $"{item["Model"]} ({storlekGB} GB)";
                }
            }
            return "Ingen disk hittad";
        }

        public static string[] HämtaNätverkskort()
        {
            var lista = new List<string>();
            using (var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_NetworkAdapter WHERE NetEnabled = true"))
            {
                foreach (var item in searcher.Get())
                {
                    lista.Add(item["Name"]?.ToString());
                }
            }
            return lista.ToArray();
        }

        // OBS: CPU-temperatur kräver särskilda drivrutiner eller 3rd party API
        public static string HämtaCputemp()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        double tempKelvin = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                        double tempCelsius = (tempKelvin / 10) - 273.15;
                        return $"{Math.Round(tempCelsius)} °C";
                    }
                }
            }
            catch
            {
                return "Ej tillgänglig";
            }

            return "Temperatur ej hittad";
        }















    }
}
