using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using ConfigurationManager.AppSettings["BasePath"].Models;

namespace ConfigurationManager.AppSettings["BasePath"].Areas.Login
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

        [HttpGet]
        public string ASD()
        {
            return "ASD";
        }
    }
}
