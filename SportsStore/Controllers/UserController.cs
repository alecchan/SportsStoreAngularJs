using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace SportsStore.Controllers
{
    public class UserController : ApiController
    {
        public UserController()
        {
            
        }

        //public IHttpActionResult Get ()
        //{
        //    System.Web.Security.FormsAuthentication f;
        //    string d;
        //    d.ToString();

        //}


        public IHttpActionResult Login(dynamic login)
        {
            string userName = login.username;
            string password = login.password;

          //  var result = Membership.ValidateUser(userName, password);
            //bool result = true;//FormsAuthentication.Authenticate(userName, password);
            //if (result)
            //    FormsAuthentication.SetAuthCookie(userName, false);
               // Membership.

            //return Request.CreateErrorResponse(
            // HttpStatusCode.Unauthorized, "You are not authorized");
            return Ok();
        }
    }
}
