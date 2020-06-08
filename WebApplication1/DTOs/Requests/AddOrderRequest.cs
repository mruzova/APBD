using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Requests
{
    public class AddOrderRequest
    {
        [Required(ErrorMessage="You have to provide date")]
        public DateTime DateAccepted { get; set; }
        [Required(ErrorMessage = "You have to provide notes")]
        public string Notes{ get; set; }
        [Required(ErrorMessage = "You have to provide confectionery(confectioneries)")]
        public List<ConfectioneryRequest> Confectionery { get; set; }
    }
}
