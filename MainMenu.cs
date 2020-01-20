using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    class MainMenu
    {
        public void PrintMainMenu()
        {
            string[] options = new string[] { "List all process", "Load saved data", "Exit" };

            Console.WriteLine("/--------------------------------------------------\\");
            for(int count=0;count<options.Length;count++)
            {
                Console.WriteLine("\t{0}: {1}",count+1,options[count]);
            }
            Console.WriteLine("/--------------------------------------------------\\");
        }


        public void ListAllProcess()
        {

        }

    }
}
