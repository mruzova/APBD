using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Studies
    {

        public string nameOfStudies { get; set; }
        public string mode { get; set; }
        public Studies()
        {
           
        }
        public Studies(string name, string mode)
        {
            nameOfStudies = name;
            this.mode = mode;
        }
    }
}
