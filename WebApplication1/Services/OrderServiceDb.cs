using Microsoft.EntityFrameworkCore;
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

        public GetOrderResponse GetOrders(string surname = null)
        {
            var response = new GetOrderResponse();
            if (surname == null)
            {
                response.orders = _context.Order.ToList();
                return response;
            }
            var customer = _context.Customer.FirstOrDefault(s => s.Surname == surname);
            if (customer == null)
            {
                throw new Exception("there is no such customer");
            }
            var order = _context.Order.Where(o => o.IdCustomer == customer.IdCustomer).FirstOrDefault();

            var confectionery_order = _context.Confectionery_Order.FirstOrDefault(co => co.IdOrder == order.IdOrder);
            var confectionery = _context.Confectionery.Where(c => c.IdConfectionery == confectionery_order.IdConfectionery).FirstOrDefault();
            response.DateAccepted = order.DateAccepted;
            response.DateFinished = order.DateFinished;
            response.Notes = order.Notes;
            response.NameConfectionery = confectionery.Name;
            return response;
        }

        public AddOrderResponse AddOrder(AddOrderRequest request, int idCustomer)
        {
            if (String.IsNullOrEmpty(idCustomer.ToString()))
            {
                throw new Exception("you have to provide the id of a customer");
            }
            var customer = _context.Customer.FirstOrDefault(c => c.IdCustomer == idCustomer);
            if (customer == null)
            {
                throw new Exception("there is no such customer");
            }
            for(int i = 0; i < request.Confectionery.Count; i++)
            {
                var confect = _context.Confectionery.FirstOrDefault(c => c.Name.Equals(request.Confectionery.ElementAt(i).Name));
                if (confect == null)
                {
                    throw new Exception("there is no such confectionery");
                }
                    
            }
            Random rand = new Random();
        
            var order = new Order()
            {
              //  IdOrder = _context.Order.Max(o=>o.IdOrder) +1,
                DateAccepted = request.DateAccepted,
                DateFinished = request.DateAccepted.AddDays(3),
                Notes = request.Notes,
                IdCustomer = idCustomer,
                IdEmployee = rand.Next(1, 3)
            };
            for (int i = 0; i < request.Confectionery.Count; i++)
            {
                var confectionery_order = new Confectionery_Order()
                {
                   // IdOrder = _context.Order.Max(o => o.IdOrder) + 1,
                    IdConfectionery = _context.Confectionery.FirstOrDefault(c=>c.Name.Equals(request.Confectionery.ElementAt(i).Name)).IdConfectionery,
                    Quantity = request.Confectionery.ElementAt(i).Quantity,
                    Notes = request.Confectionery.ElementAt(i).Notes
                };
                _context.Confectionery_Order.Add(confectionery_order);
                    
            }
            _context.Order.Add(order);
          // _context.SaveChanges();
            var response = new AddOrderResponse()
            {
                Notes = order.Notes,
                DateFinished = order.DateFinished,
                Surname = customer.Surname,
                IdEmployee = order.IdEmployee
            };
            return response;
        }




        //public AddOrderResponse AddOrder(AddOrderRequest request, int idCustomer)
        //{
        //    var confectionary = new Confectionery();
        //    List<int> quantity = new List<int>();
        //    List<string> notes = new List<string>();
        //    var ConfectionaryRequest = new ConfectioneryRequest();

        //    if (String.IsNullOrEmpty(idCustomer.ToString()))
        //    {
        //        throw new Exception("you have to provide the id of a customer");
        //    }
        //    var customer = _context.Customer.FirstOrDefault(c => c.IdCustomer == idCustomer);
        //    if (customer == null)
        //    {

        //        throw new Exception("there is no such customer in db");
        //    }
        //    for (int i = 0; i < request.Confectionery.Count; i++)
        //    {
        //        confectionary = _context.Confectionery.FirstOrDefault(c => c.Name == request.Confectionery.ElementAt(i).Name);
        //        quantity.Add((request.Confectionery.ElementAt(i).Quantity));
        //        notes.Add((request.Confectionery.ElementAt(i).Notes));

        //        if (confectionary == null)
        //        {
        //            throw new Exception("there is no such confectionary");
        //        }



        //    }
        //    Random rand = new Random();
        //    var order = new Order()
        //    {

        //        DateAccepted = request.DateAccepted,
        //        DateFinished = DateTime.Now.AddDays(4),
        //        Notes = request.Notes,
        //        IdCustomer = idCustomer,
        //        IdEmployee = rand.Next(1, 3)
        //    };
        //    _context.Order.Add(order);
        //    for (int i = 0; i < request.Confectionery.Count; i++)
        //    {
        //        var confecOrder = new Confectionery_Order()
        //        {

        //            Quantity = quantity.ElementAt(i),
        //            Notes = notes.ElementAt(i)

        //        };
        //        _context.Add(confecOrder);

        //    }
        //    var response = new AddOrderResponse()
        //    {
        //        Notes = order.Notes,
        //        DateFinished = order.DateFinished,
        //        Surname = customer.Surname,
        //        IdEmployee = order.IdEmployee
        //    };
        //    _context.SaveChanges();
        //    return response;
        //}
    }
}