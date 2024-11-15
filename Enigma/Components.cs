using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Enigma
{
    public class Components
    {
        private static string key = "COMPONENT";

        public static Computer GetComponents1()
        {
            string cpuId = GetCpuId();
            string biosVersion = GetBiosSerialNumber();
            string osVersion = GetDeviceName();

            return new Computer
            {
                characteristic1 = AutokeyCipher.Encrypt(cpuId, key),
                characteristic2 = AutokeyCipher.Encrypt(biosVersion, key),
                characteristic3 = AutokeyCipher.Encrypt(osVersion, key)
            };
        }

        public static Computer GetComponents2()
        {
            string driveSerial = GetDriveSerial();
            string macAddress = GetRamSerial();
            string motherboardSerial = GetMotherboardSerial();

            return new Computer
            {
                characteristic1 = AutokeyCipher.Encrypt(driveSerial, key),
                characteristic2 = AutokeyCipher.Encrypt(macAddress, key),
                characteristic3 = AutokeyCipher.Encrypt(motherboardSerial, key)
            };
        }

        public static Computer GetComponents3()
        {
            string gpuName = GetGpuName();
            string ramAmount = GetProcessorModel();
            string processorCount = GetRamManufacturer();

            return new Computer
            {
                characteristic1 = AutokeyCipher.Encrypt(gpuName, key),
                characteristic2 = AutokeyCipher.Encrypt(ramAmount, key),
                characteristic3 = AutokeyCipher.Encrypt(processorCount, key)
            };
        }

        private static string GetCpuId()
        {
            string cpuId = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select ProcessorId from Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    cpuId = obj["ProcessorId"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving CPU ID: {ex.Message}");
            }
            return cpuId;
        }

        // Метод для получения серийного номера BIOS
        private static string GetBiosSerialNumber()
        {
            string biosSerialNumber = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
                foreach (ManagementObject obj in searcher.Get())
                {
                    biosSerialNumber = obj["SerialNumber"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving BIOS serial number: {ex.Message}");
            }
            return biosSerialNumber;
        }

        // Метод для получения имени устройства
        private static string GetDeviceName()
        {
            string deviceName = string.Empty;
            try
            {
                deviceName = Environment.MachineName;  // Имя устройства, уникальное для компьютера в сети
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving device name: {ex.Message}");
            }
            return deviceName;
        }


        // Метод для получения серийного номера жесткого диска
        private static string GetDriveSerial()
        {
            string driveSerial = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
                foreach (ManagementObject obj in searcher.Get())
                {
                    driveSerial = obj["SerialNumber"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving hard drive serial number: {ex.Message}");
            }
            return driveSerial;
        }

        private static string GetRamSerial()
        {
            string ramSerial = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMemory");
                foreach (ManagementObject obj in searcher.Get())
                {
                    ramSerial = obj["SerialNumber"].ToString();
                    break;  // Если найден первый модуль RAM, выходим из цикла
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving RAM serial number: {ex.Message}");
            }
            return ramSerial;
        }


        private static string GetMotherboardSerial()
        {
            string motherboardSerial = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                foreach (ManagementObject obj in searcher.Get())
                {
                    motherboardSerial = obj["SerialNumber"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving motherboard serial number: {ex.Message}");
            }
            return motherboardSerial;
        }

        private static string GetGpuName()
        {
            string gpuName = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController");
                foreach (ManagementObject obj in searcher.Get())
                {
                    gpuName = obj["Name"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving GPU name: {ex.Message}");
            }
            return gpuName;
        }

        private static string GetProcessorModel()
        {
            string processorModel = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    processorModel = obj["Name"].ToString();
                    break;  // Получаем только первый процессор
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving processor model: {ex.Message}");
            }
            return processorModel;
        }


        // Метод для получения производителя оперативной памяти
        private static string GetRamManufacturer()
        {
            string ramManufacturer = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_PhysicalMemory");
                foreach (ManagementObject obj in searcher.Get())
                {
                    ramManufacturer = obj["Manufacturer"].ToString();
                    break;  // Получаем только первый найденный производитель
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving RAM manufacturer: {ex.Message}");
            }
            return ramManufacturer;
        }

    }
}
