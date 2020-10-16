using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Responses
{
    public class GetOrderResponse
    {
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public string NameConfectionery { get; set; }
        public List<Order> orders { get; set; }
    }
}
