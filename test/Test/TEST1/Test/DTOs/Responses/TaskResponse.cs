using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DTOs.Responses
{
    public class TaskResponse
    {
        public  string NameofTask { get; set; }
        public  string Description { get; set; }
        public  DateTime Deadline { get; set; }
        public  string NameOfProject { get; set; }
        public  string TaskType { get; set; }
    }
}
