using SportsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class ProductController : ApiController
    {
        public IHttpActionResult Get() {

            EfDbContext db = new EfDbContext();
            var ps = db.Products.ToArray();

            return Ok(ps);
        }
    }
}
