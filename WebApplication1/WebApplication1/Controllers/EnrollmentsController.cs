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

        [HttpPost(Name = "EnrollStudent")]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            try
            {
                var response = _service.EnrollStudent(request);
                return Created("EnrollStudent", response);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("there is no such study");
            }
            catch (ArgumentException)
            {
                return BadRequest("there is already a student with such index number");
            }

        }

        [HttpPost("promote")]
        public IActionResult PromoteStudents(PromoteStudentRequest request)
        {
<<<<<<< HEAD
            try
            {
                var response = _service.PromoteStudents(request);
                return Created("PromoteStudents", response);
            }
            catch (SqlException)
            {
                return BadRequest("there are no students to promote or no such study");
            }
=======
            var response = _service.PromoteStudents(request);
            return Created("PromoteStudents", response);
>>>>>>> 458cba8c90ca4a1f04f7d744619d72c995d41c18

        }

    }

}
