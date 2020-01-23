using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable()]
    public class ProcessingProgram
    {
        public string Name { get; set; }
        public int PID { get; set; }
        public string CPU { get; set; }
        public string Memory { get; set; }
        public string RunningTime { get; set; }
        public string StartTime { get; set; }
        public string Comment { get; set; } = "";

        public ProcessingProgram()
        {
        }

        public ProcessingProgram(Process process)
        {
            Name = process.ProcessName;
            PID = process.Id;
            var result = GetCpuUsageForProcess();
            CPU = Math.Round(result.Result).ToString()+"%";
            Memory = (process.PrivateMemorySize64/1000000).ToString()+" MB";

            try
            {
                StartTime = process.StartTime.ToString();

            }
            catch (Exception e)
            {
                StartTime = "N/A";
            }
                

            try
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(process.StartTime);
                RunningTime = Math.Round(timeSpan.TotalMinutes).ToString()+" minute";
            }
            catch
            {
                RunningTime = "N/A";
            }
        }

        public void refreshProcess(ProcessingProgram p)
        {
            Process process = Process.GetProcessById(p.PID);
            var result = GetCpuUsageForProcess();
            p.CPU = Math.Round(result.Result).ToString() + "%";
            p.Memory = (process.PrivateMemorySize64 / 1000000).ToString() + " MB";

            try
            {
                p.StartTime = process.StartTime.ToString();

            }
            catch (Exception e)
            {
                p.StartTime = "N/A";
            }


            try
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(process.StartTime);
                p.RunningTime = Math.Round(timeSpan.TotalMinutes).ToString() + " minute";
            }
            catch
            {
                p.RunningTime = "N/A";
            }
            
        }

        
        private async Task<double> GetCpuUsageForProcess()
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            await Task.Delay(0);

            var endTime = DateTime.UtcNow;
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            return cpuUsageTotal * 100;
        }

    }
}
