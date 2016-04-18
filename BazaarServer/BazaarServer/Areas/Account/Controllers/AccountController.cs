using BazaarServer.Models;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BazaarServer.Areas.Account.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IUserService _userService;

        public AccountController(IUserService dep)
        {
            _userService = dep;
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(UserProfile up)
        {
            IHttpActionResult result;
            Guid userID;

            userID = _userService.Login(up.Username, up.HashedPassword);
            if (userID == Guid.Empty)
                result = NotFound();
            else
                result = Ok(Convert.ToString(userID));

            return result;
        }

        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(UserProfile up)
        {
            IHttpActionResult result;
            Guid userID;

            userID = _userService.Register(up.Username, up.HashedPassword);
            if (userID == Guid.Empty)
                result = NotFound();
            else
                result = Ok(Convert.ToString(userID));

            return result;
        }

        [HttpGet]
        [Route("Uaaa")]
        public IHttpActionResult QWE()
        {
            return Ok("Uaaa");
        }
    }
}
