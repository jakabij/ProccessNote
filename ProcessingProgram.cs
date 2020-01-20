using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotNetProject
{
    [Serializable()]
    public class ProcessingProgram : ISerializable
    {
        public string Name { get; set; }
        public int PID { get; set; }
        int CPU { get; set; }
        int Memory { get; set; }
        DateTime RunningTIme { get; set; }
        DateTime StartTIme { get; set; }

        public ProcessingProgram()
        {

        }

        public ProcessingProgram(string name,int pid)
        {
            Name = name;
            PID = pid;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("ProcessID", PID);
        }
    }
}
