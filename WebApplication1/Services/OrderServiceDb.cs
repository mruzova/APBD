using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requests;
using WebApplication1.DTOs.Responses;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OrderServiceDb : IOrderServiceDb
    {
        public ConfectioneryContext _context { get; set; }
        public OrderServiceDb(ConfectioneryContext context)
        {
            _context = context;
        }

        public GetOrderResponse GetOrders(GetOrdersRequest request)
        {
            var response = new GetOrderResponse();
           if(request.Surname.Equals(null))
            {
                response.orders =_context.Order.ToList();
                return response;
            }
            var customer = _context.Customer.FirstOrDefault(s => s.Surname == request.Surname);
            var order = _context.Order.Where(o => o.IdCustomer == customer.IdCustomer).FirstOrDefault();
            if (order == null)
            {
                throw new Exception("there is no such customer");
            }
            var confectionery_order = _context.Confectionery_Order.FirstOrDefault(co => co.IdOrder == order.IdOrder);
            var confectionery = _context.Confectionery.Where(c => c.IdConfectionery == confectionery_order.IdConfectionery).FirstOrDefault();
            response.DateAccepted = order.DateAccepted;
            response.DateFinished = order.DateFinished;
            response.Notes = order.Notes;
            response.NameConfectionery = confectionery.Name;
            return response;
        }
    }
}
