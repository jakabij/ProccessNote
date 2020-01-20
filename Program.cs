using System;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DotNetProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataManager manager = new DataManager();







            manager.WriteTOXml();
            manager.ReadFromXml();
        }
    }
}

