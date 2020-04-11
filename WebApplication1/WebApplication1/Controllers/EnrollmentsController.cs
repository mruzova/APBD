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
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
           _service.EnrollStudent(request);

            var response = new EnrollStudentResponse();
            return Ok(response);
        }
    
        [HttpPost("promote")]
        public IActionResult PromoteStudents(PromoteStudentRequest request)
        {
        
            

            return _service.PromoteStudents(request);
        }
    }

}