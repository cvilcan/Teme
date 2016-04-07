using NetworkModule.Interfaces;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkUtilities.ExtensionMethods;

namespace PresentationLayer.Controllers
{
	public class AccountController: IAccountController
	{
        const int OPERATION_TIMEOUT = 7000;
		private IUserService _userService;

		public AccountController(IUserService dependency)
		{
			_userService = dependency;
		}

		public Guid Login(string username, string hashedPassword)
		{
            Func<Guid> login = () => _userService.Login(username, hashedPassword);
            return login.WithTimeout(OPERATION_TIMEOUT);
		}

		public Guid Register(string username, string hashedPassword)
		{
            Func<Guid> register = () => _userService.Register(username, hashedPassword);
            return register.WithTimeout(OPERATION_TIMEOUT);
		}

        public void Logout(Guid guid)
        {
            Action logout = () => _userService.Logout(guid);
            logout.WithTimeout(OPERATION_TIMEOUT);
        }
    }
}
