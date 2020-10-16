using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task10.DTOs.Responses
{
    public class AddStudentResponse
    {
        public int Semester { get; set; }
        public string LastName { get; set; }

        public DateTime StartDate{ get; set; }
    }
}
