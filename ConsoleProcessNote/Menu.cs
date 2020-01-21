using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProcessNote
{
    class Menu
    {
        public void PrintMainMenu()
        {
            string[] options = new string[] { "List all process [command: list]","Save all currently running process [command: save]"
                , "Load saved data [command: load]","Find saved data by ID [command: find]", "Exit [command: exit]" };

            Console.WriteLine("/--------------------------------------------------\\");
            for(int count=0;count<options.Length;count++)
            {
                Console.WriteLine("\t{0}: {1}",count+1,options[count]);
            }
            Console.WriteLine("/--------------------------------------------------\\");
        }



    }
}
