using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Responses
{
    public class EnrollStudentResponse 
    {
        public int Semester { get; set; }
        public string LastName { get; set; }
    }
}
