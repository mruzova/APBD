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
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServiceDb _service;
        public OrdersController(IOrderServiceDb service)
        {
            _service = service;
        }

        [HttpGet]

        public IActionResult GetOrders(string surname=null)
        {
            try {
                return Ok(_service.GetOrders(surname));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            }
     
        }
    
}