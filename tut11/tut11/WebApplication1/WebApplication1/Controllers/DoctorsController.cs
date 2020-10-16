using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorServiceDb _service;
        public DoctorsController(IDoctorServiceDb service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }
        [Route("add")]
        [HttpPost]
        public IActionResult AddDoctor(AddDoctorRequest request)
        {
            try
            {
                var doctor = _service.AddDoctor(request);
                return Created("AddDoctor",doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [Route("modify")]
        [HttpPost]
        public IActionResult ModifyDoctor(ModifyDoctorRequest request)
        {
            try
            {
                var doctor = _service.ModifyDoctor(request);
                return Created("ModifyDoctor", doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpDelete]
        public IActionResult DeleteDoctor(DeleteDoctorRequest request)
        {
            try
            {
                var doctor = _service.DeleteDoctor(request);
                return Ok(doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        }
    }
