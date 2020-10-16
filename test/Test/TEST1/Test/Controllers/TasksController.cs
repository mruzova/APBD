using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase  
    {
        private readonly ITaskServiceDb _service;
        public TasksController(ITaskServiceDb service)
        {
            _service = service;
        }

        [HttpGet] 
        public IActionResult GetTasks(int idMember)
        {
            // please use link https://localhost:44359/api/tasks?idMember=1 to test this endpopint
            try
            {
                var response = _service.GetTasks(idMember);
                return Ok(response);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("no such member");
            }
        }
        [Route("api/delete")]
        [HttpDelete]
        public IActionResult DeleteProject( int idProject)
        {
            try
            {
                var response = _service.DeleteProject(idProject);
                // return Created("DeleteProject", response);??
                return Ok(response);
            }
            catch (ArgumentException)
            {
                return BadRequest("no such project");
            }
        }
    }
}
