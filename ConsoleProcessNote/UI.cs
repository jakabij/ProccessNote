using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ClassLibrary1;

namespace ConsoleProcessNote
{
    class UI
    {
        public string userInput(string message)
        {
            Console.Write(message+" ");
            return Console.ReadLine();
        }

        public void errorMessage(Exception e)
        {
            Console.WriteLine("An ERROR occured! "+e);
        }

        public void wrongArgument(string message)
        {
            Console.WriteLine("An error occured! "+message);
        }

        public void listAllProcess()
        {
            foreach(var process in Process.GetProcesses())
            {
                Console.WriteLine(process.ProcessName);
            }
        }

        public void toSaveData(AllProcess allProcess)
        {
            foreach (var process in Process.GetProcesses())
            {
                ProcessingProgram p = new ProcessingProgram(process);
                allProcess.ListOfProcesses.Add(p);
            }
        }

        public void toLoadData(List<ProcessingProgram> allProcesses)
        {
            foreach (var process in allProcesses)
            {
                Console.WriteLine(process.PID + ": " + process.Name);
            }
        }


        public void toFindData(string searchedProcess, List<ProcessingProgram> allProcesses)
        {
            bool contains = false;
            foreach (var process in allProcesses)
            {
                if (process.PID.ToString().Equals(searchedProcess))
                {
                    contains = true;
                    Console.WriteLine($"Program name: {process.Name}, started at: " +
                        $"{process.StartTime}, total running time: {process.RunningTime}" +
                        $", Memory usage: {process.Memory}\nComment: {process.Comment}");

                    string answer = userInput("Would you like to comment something to this?\n");
                    if (answer.Equals("yes") || answer.Equals("Yes") || answer.Equals("YES")|| answer.Equals("y"))
                    {
                        string comment = userInput("");
                        process.Comment = comment;
                    }
                    break;
                }
            }
            if (!contains)
            {
                wrongArgument("The added ID doesn't exist!");
            }
        }

    }
}
