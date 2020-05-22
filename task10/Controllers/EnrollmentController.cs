using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task10.DTOs;
using task10.Services;

namespace task10.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IStudentServiceDb _service;
        public EnrollmentController(IStudentServiceDb service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            try
            {
                var response = _service.EnrollStudent(request);
                return Created("EntollStudent", response);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("promote")]
        [HttpPost]
        public IActionResult PromoteStudent(PromoteStudentRequest request)
        {
            try
            {
                var response = _service.PromoteStudents(request);
                return Created("PromoteStudent", response);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}