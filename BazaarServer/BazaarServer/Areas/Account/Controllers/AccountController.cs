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
        public string Login(UserProfile up)
        {
            return _userService.Login(up.Username, up.HashedPassword).ToString();
        }

        [HttpPost]
        [Route("Register")]
        public string Register(UserProfile up)
        {
            return _userService.Register(up.Username, up.HashedPassword).ToString();
        }
    }
}
