using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task10.DTOs;
using task10.DTOs.Requests;
using task10.Services;

namespace task10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServiceDb _service;
        public StudentController(IStudentServiceDb service)
        {
            _service = service;
        }
       
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }
        [HttpPost]
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            try
            {
                var student = _service.ModifyStudent(request);
                return Created("ModifyStudent", student);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteStudent(DeleteStudentRequest request)
        {
            try
            {
                var student = _service.DeleteStudent(request);
                return Ok(student);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}