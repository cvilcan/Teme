using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	public class UserService: IUserService
	{
		private IUserRepository _userRepository;

		public UserService(IUserRepository dependency)
		{
			_userRepository = dependency;
		}

		public int Login(string username, string hashedPassword)
		{
			return _userRepository.Login(username, hashedPassword);
		}

		public int Register(string username, string hashedPassword)
		{
			return _userRepository.Register(username, hashedPassword);
		}
	}
}
