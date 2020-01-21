using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
namespace ClassLibrary1
{
    [Serializable()]
    public class ProcessingProgram
    {
        public string Name { get; set; }
        public int PID { get; set; }
        public long Memory { get; set; }
        public double RunningTime { get; set; }
        public DateTime StartTime { get; set; }
        public string Comment { get; set; }

        public ProcessingProgram()
        { }

            public ProcessingProgram(Process process)
        {
            
            try
            {
                Name = process.ProcessName;
                PID = process.Id;
                Memory = process.PrivateMemorySize64;
                StartTime = process.StartTime;
                TimeSpan timeSpan = DateTime.Now.Subtract(StartTime);
                RunningTime =Math.Round( timeSpan.TotalMinutes);
            }
            catch (Exception)
            {
            }

        }
        
        

    }
}
