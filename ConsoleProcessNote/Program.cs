using System;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using ClassLibrary1;
using System.Threading;
using System.Windows.Threading;
using WpfProcessNote;
using System.Windows;

namespace ConsoleProcessNote
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Application app = new Application();
                app.Run(new WpfProcessNote.MainWindow());
                
            }
            else
            {
                Menu menu = new Menu();
                UI ui = new UI();
                DataManager manager = new DataManager();

                while (true)
                {
                    menu.PrintMainMenu();
                    string input = ui.userInput("");


                    if (input.Equals("list"))
                    {
                        ui.listAllProcess();
                    }
                    else if (input.Equals("save"))
                    {
                        AllProcess allProcess = new AllProcess();
                        ui.toSaveData(allProcess);
                        manager.WriteTOXml(allProcess.ListOfProcesses);
                    }
                    else if (input.Equals("load"))
                    {
                        try
                        {
                            List<ProcessingProgram> allProcesses = manager.ReadFromXml();
                            ui.toLoadData(allProcesses);
                        }
                        catch (Exception e)
                        {
                            ui.errorMessage(e);
                        }
                    }
                    else if (input.Equals("find"))
                    {
                        List<ProcessingProgram> allProcesses = manager.ReadFromXml();
                        string searchedProcess=ui.userInput("The searched process' ID");
                        ui.toFindData(searchedProcess, allProcesses);

                    }
                    else if (input.Equals("exit"))
                    {
                        break;
                    }
                }
            }
            
        }
    }
}

