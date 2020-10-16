using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;

namespace WebApplication1.Services
{
 public interface IOrderServiceDb
    {
        public GetOrderResponse GetOrders(string surname=null);
        public AddOrderResponse AddOrder(AddOrderRequest request, int idCustomer);
    }
}
