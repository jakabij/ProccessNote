using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ClassLibrary1
{
    public class AllProcess
    {
        public List<ProcessingProgram> ListOfProcesses = new List<ProcessingProgram>();

        public AllProcess()
        {
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    
                    ProcessingProgram program = new ProcessingProgram(process.ProcessName, process.Id, process.StartTime);
                    ListOfProcesses.Add(program);
                }
                catch (Exception)
                {
                    Console.WriteLine("neeeeeeeeeeeee");
                    
                }
                
                
                
            }
        }
    }
}
