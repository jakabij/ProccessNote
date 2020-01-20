using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotNetProject
{
    public class AllProcess
    {
        public List<ProcessingProgram> ListOfProcesses = new List<ProcessingProgram>();

        public AllProcess()
        {
            foreach (var process in Process.GetProcesses())
            {
                ProcessingProgram program = new ProcessingProgram(process.ProcessName, process.Id);
                ListOfProcesses.Add(program);
            }
        }
    }
}
