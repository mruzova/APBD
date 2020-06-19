using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requests;
using WebApplication1.Services;
namespace WebApplication1.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetServiceDb _service;
        public PetController(IPetServiceDb service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult AddPet(AddPetRequest request)
         try
            {
                var pet = _service.AddPet(request);
                return Created("AddPet", pet);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
          }
        [HttpGet]
        public IActionResult GetPets(string year =null)
        {
            try
            {
                return Ok(_service.GetPets(year));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
