using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Utility
    {
        public static void AddComent(ProcessingProgram program,string comment)
        {
            program.Comment = comment;
        }
    }
}
