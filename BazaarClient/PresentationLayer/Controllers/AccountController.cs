using NetworkModule.Interfaces;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
	public class AccountController: IAccountController
	{
		private IUserService _userService;

		public AccountController(IUserService dependency)
		{
			_userService = dependency;
		}

		public int Login(string username, string hashedPassword)
		{
			return _userService.Login(username, hashedPassword);
		}

		public int Register(string username, string hashedPassword)
		{
			return _userService.Register(username, hashedPassword);
		}
	}
}
