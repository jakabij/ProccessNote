﻿using System;
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
                if(args[0].ToLower().Equals("window"))
                { 
                    Application app = new Application();
                    app.Run(new WpfProcessNote.MainWindow());
                }
                else
                {
                    UI ui = new UI();
                    ui.wrongArgument("Not valid argument!");
                }
            }
            else
            {
                Menu menu = new Menu();

                while (true)
                {
                    menu.PrintMainMenu();
                    menu.MenuOptions();
                }
            }
            
        }
    }
}

