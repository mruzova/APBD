
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConsoleApp1

{
    class Program
    {
       
        public static void ErrorLogging(Exception ec)
        {
            string logpath = @"D:\APBD\task2\log.txt";
            if (!File.Exists(logpath))
            {
                File.Create(logpath).Dispose();
            }

            StreamWriter sw = File.AppendText(logpath);

            sw.WriteLine(ec.Message);

            sw.Close();
        }
        static void Main(string[] args)
        {


            //var path = @"D:\APBD\task2\data.csv";
           

            XmlSerializer xMLSerializer = new XmlSerializer(typeof(University), new XmlRootAttribute("university"));


            var studentList = new List<Student>();
            try
            {
                string csvpath = Console.ReadLine();
                string xmlOrJsonPath = Console.ReadLine();
                string format = Console.ReadLine();
               

                if (File.Exists(csvpath) && Directory.Exists(xmlOrJsonPath))
                {
                    using (var stream = new StreamReader(File.OpenRead(csvpath)))
                    {
                        string line = null;

                        while ((line = stream.ReadLine()) != null)
                        {
                            string[] student = line.Split(',');

                            var st = new Student
                            {
                                FirstName = student[0],
                                LastName = student[1],
                                indexNumber = student[2],
                                birthdate = student[3],
                                email = student[4],
                                mothersName = student[5],
                                fathersName = student[6],
                                studies = new Studies(student[7], student[8])
                             
                            };
                            
                            studentList.Add(st);
                           
                        }
                        var university = new University
                        {
                            createdAt = DateTime.Now.ToString(),
                            Author = "Maryia Ruzava",
                            students = studentList

                        };
                      
                        if (format.Equals("xml"))
                        {
                            FileStream writer = new FileStream(xmlOrJsonPath + "result.xml", FileMode.Create);
                            xMLSerializer.Serialize(writer, university);
                        } else if (format.Equals("json"))
                        {

                           
                            var jsonString = JsonSerializer.Serialize(university);
                            File.WriteAllText(xmlOrJsonPath + "result.json", jsonString);

                        }

                    }
                }
                else
                {
                    if (!File.Exists(csvpath))
                    {
                        throw new FileNotFoundException("file does not exist");

                    }
                    if (!Directory.Exists(xmlOrJsonPath))
                    {
                        throw new ArgumentException("the path is incorrect");
                    }

                }

            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }

            //var jsonString = JsonSerializer.Serialize(list);
            //File.WriteAllText("data.json", jsonString);


        }
    }
}