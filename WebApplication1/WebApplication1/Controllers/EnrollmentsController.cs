using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/enrollment")]
    [ApiController] //implicit model validation
    public class EnrollmentsController : ControllerBase
    {
        //Tight coupling of classes
        private IStudentServiceDb _service;

        public EnrollmentsController(IStudentServiceDb service)
        {
            _service = service;
        }

        [HttpPost]
        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
           _service.EnrollStudent(request);

            var response = new EnrollStudentResponse();
            return response;
        }
    
        [HttpPost("promote")]
        public IActionResult PromoteStudents(int semester, string studies)
        {
            //Request - name of studies=IT, semester=1

            //1. Check if studies exists
            //2. Find all the students from studies=IT and semester=1
            //3. Promote all students to the 2 semester
            //   Find an enrollment record with studies=IT and semester=2    -> IdEnrollment=10
            //   Update all the students
            //   If Enrollment does not exist -> add new one

            //Create stored procedure
            

            return _service.PromoteStudents(semester, studies);
        }
    }

}