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
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IOrderServiceDb _service;
        public ClientsController(IOrderServiceDb service)
        {
            _service = service;
        }



        [HttpPost("{idCustomer}/orders")]
        public IActionResult AddOrder(AddOrderRequest request, int idCustomer)
        {
            try
            {
                var order = _service.AddOrder(request, idCustomer);
                return Created("AddOrder", order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}