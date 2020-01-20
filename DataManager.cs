using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DotNetProject
{
    public class DataManager
    {
        string path = "processes.xml";
        List<ProcessingProgram> PList = new List<ProcessingProgram>();
        XmlSerializer xml = new XmlSerializer(typeof(List<ProcessingProgram>));

        public void WriteTOXml()
        {
            foreach(var process in Process.GetProcesses())
            {
                ProcessingProgram n = new ProcessingProgram(process.ProcessName,process.Id);
                PList.Add(n);
            }
            using (TextWriter tw = new StreamWriter(path))
            {
                xml.Serialize(tw, PList);
            }
        }


        public void ReadFromXml()
        {
            List<ProcessingProgram> read = new List<ProcessingProgram>();
            using (FileStream file = File.OpenRead(path))
            {
                read = (List<ProcessingProgram>)xml.Deserialize(file);
            }

            foreach (var i in read)
            {
                Console.WriteLine(i.Name);
            }
        }

    }
}
