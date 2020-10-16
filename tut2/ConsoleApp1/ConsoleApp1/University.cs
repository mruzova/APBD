using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
public class University
    {
        [XmlAttribute("createdAt")]
        public string createdAt { get; set; }
        [XmlAttribute("Author")]
        public string Author {get; set; }

        public List<Student> students { get; set; }
    }
}
