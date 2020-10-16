using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Responses
{
    public class AddOrderResponse
    {
        public string Surname { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public int IdEmployee { get; set; }
    }
}
