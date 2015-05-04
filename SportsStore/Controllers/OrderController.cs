using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class OrderController : ApiController
    {
        public IHttpActionResult Get()
        {
            var db = new EfDbContext();
            return Ok(db.Orders.ToArray());
        }

        public IHttpActionResult Post([FromBody] Order order)
        {            
            var db = new EfDbContext();         
            db.Orders.Add(order);
            db.SaveChanges();

            //Create the email settings object
            //EmailSettings emailSettings = new EmailSettings
            //{
            //    WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            //};

            //var orderProcessor = new EmailOrderProcessor(emailSettings);

            //if (order.Products.Count() == 0)
            //    return BadRequest("Sorry, your cart is empty!");

            //orderProcessor.ProcessOrder(order.Products, order.ShippingDetails);
          
            return Ok(order.Id);        
        }
    }
}
