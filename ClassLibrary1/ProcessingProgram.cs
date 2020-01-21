using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary1
{
    [Serializable()]
    public class ProcessingProgram
    {
        public string Name { get; set; }
        public int PID { get; set; }
        //int CPU { get; set; }
        //long Memory { get; set; }
        //DateTime RunningTIme { get; set; }
        DateTime StartTIme { get; set; }
        //string Comment { get; set; }

        public ProcessingProgram()
        {

        }
        
        public ProcessingProgram(string name,int pid, DateTime startTime)
        {
            Name = name;
            PID = pid;
            StartTIme = startTime;
            
        }

    }
}
