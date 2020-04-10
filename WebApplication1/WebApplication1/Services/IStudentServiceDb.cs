using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;

namespace WebApplication1.Services
{
    public interface IStudentServiceDb
    {
        IActionResult EnrollStudent(EnrollStudentRequest req);
        IActionResult PromoteStudents(PromoteStudentRequest req);
    }
}
