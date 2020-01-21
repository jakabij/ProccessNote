using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    public class DataManager
    {
        string path = "processes.xml";
        XmlSerializer xml = new XmlSerializer(typeof(List<ProcessingProgram>));

        public void WriteTOXml(List<ProcessingProgram> PList)
        {
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