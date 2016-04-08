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
    public class AccountController : ApiController
    {
        private IUserService _userService;

        public AccountController(IUserService dep)
        {
            _userService = dep;
        }

        [HttpPost]
        public string Login(UserProfile up)
        {
            return _userService.Login(up.Username, up.HashedPassword).ToString();
        }

        [HttpPost]
        public string Register(UserProfile up)
        {
            return _userService.Register(up.Username, up.HashedPassword).ToString();
        }

        [HttpGet]
        public string ASD()
        {
            return "ASD";
        }
    }
}
