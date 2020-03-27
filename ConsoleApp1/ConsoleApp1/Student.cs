using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Student
    {
        [XmlElement(ElementName = "fname")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "lname")]
        public string LastName { get; set; }
        // will be added to the student tag when we use collections [XmlAttribute(AttributeName = "indexNumber")]

        [XmlElement(ElementName = "birthdate")]
        public string birthdate { get; set; }

        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }

        public Studies studies { get; set; }
        [XmlAttribute(AttributeName = "indexNumber")]
        public string indexNumber { get; set; }
       
    }
}
