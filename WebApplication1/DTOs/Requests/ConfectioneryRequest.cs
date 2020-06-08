using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Requests
{
    public class ConfectioneryRequest
    {
        [Required(ErrorMessage = "You have to provide quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "You have to provide name of confectionery")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You have to provide notes")]
        public string Notes { get; set; }
    }
}
