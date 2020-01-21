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
        double CPU { get; set; }
        public long Memory { get; set; }
        public double RunningTime { get; set; }
        public DateTime StartTime { get; set; }
        public string Comment { get; set; } = "";

        public ProcessingProgram()
        { }

            public ProcessingProgram(Process process)
        {
            
            try
            {
                Name = process.ProcessName;
                PID = process.Id;
                var result = GetCpuUsageForProcess();
                CPU = Math.Round(result.Result); 
                Memory = process.PrivateMemorySize64;
                StartTime = process.StartTime;
                TimeSpan timeSpan = DateTime.Now.Subtract(StartTime);
                RunningTime =Math.Round( timeSpan.TotalMinutes);
            }
            catch (Exception)
            {
                Console.WriteLine("no data");

            }

        }

        private async Task<double> GetCpuUsageForProcess()
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            await Task.Delay(30);

            var endTime = DateTime.UtcNow;
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            return cpuUsageTotal * 100;
        }

    }
}
