using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Knockout.API.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController() { }

        [HttpPost]
        public IHttpActionResult login([FromBody]string username, [FromBody]string password)
        {
            if (username == "user" && password == "password")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Ok();
            }
            else
                return Unauthorized();
        }

        [HttpGet]
        public IHttpActionResult logout()
        {
            FormsAuthentication.SignOut();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult checkAuth()
        {
            return Ok("Authorized");
        }
    }
}