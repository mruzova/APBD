using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services
{
    public class OracleStudentDbService : IStudentServiceDb
    {
        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest req)
        {
            throw new NotImplementedException();
        }

        public IActionResult PromoteStudents(int semester, string studies)
        {
            throw new NotImplementedException();
        }
    }
}
