using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;

namespace ConsoleProcessNote
{
    class Menu
    {
        UI ui = new UI();
        DataManager manager = new DataManager();
        public void PrintMainMenu()
        {
            string[] options = new string[] { "[command: list] to list all process",
                "[command: save] to save all currently running process"
                , "[command: load] load saved data","[command: find] find saved data by ID", "[command: exit] to exit" };

            Console.WriteLine("/--------------------------------------------------------\\");
            for(int count=0;count<options.Length;count++)
            {
                Console.WriteLine("\t{0}",options[count]);
            }
            Console.WriteLine("/--------------------------------------------------------\\");
        }



        public void MenuOptions()
        {
            string input = ui.userInput("");

            if (input.Equals("list"))
            {
                ui.listAllProcess();
            }
            else if (input.Equals("save"))
            {
                Save();
            }
            else if (input.Equals("load"))
            {
                Load();
            }
            else if (input.Equals("find"))
            {
                Find();

            }
            else if (input.Equals("exit"))
            {
                System.Environment.Exit(0);
            }
            else
            {
                ui.wrongArgument("Wrong argument!");
            }
        }



        public void Save()
        {
            AllProcess allProcess = new AllProcess();
            ui.toSaveData(allProcess);
            manager.WriteTOXml(allProcess.ListOfProcesses);
        }



        public void Load()
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



        public void Find()
        {
            List<ProcessingProgram> allProcesses = manager.ReadFromXml();
            string searchedProcess = ui.userInput("The searched process' ID");
            ui.toFindData(searchedProcess, allProcesses);
        }
    }
}
