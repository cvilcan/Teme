using BusinessLayer.Interfaces;
using BusinessLayer.PresentationModels;
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

		public Guid Login(string username, string hashedPassword)
		{
            Guid returnValue = Guid.Empty;
            returnValue = _userRepository.Login(username, hashedPassword);
            if (returnValue != Guid.Empty)
                Console.WriteLine("{0} logged in!", username);
            return returnValue;
		}

		public Guid Register(string username, string hashedPassword)
		{
            Guid returnValue = Guid.Empty;
			returnValue = _userRepository.Register(username, hashedPassword);
            if (returnValue != Guid.Empty)
                Console.WriteLine("{0} registered!", username);
            return returnValue;
		}

        public UserDetails GetUserDetails(Guid loginToken)
        {
            var detailsFromRepo = _userRepository.GetUserDetails(loginToken);
            UserDetails userDetails = new UserDetails()
            {
                UserID = detailsFromRepo.Item1,
                Username = detailsFromRepo.Item2
            };
            return userDetails;
        }

        public void Logout(Guid guid)
        {
            _userRepository.GetUserDetails(guid);
            Console.WriteLine("{0} logged out!", _userRepository.GetUserDetails(guid).Item2);
        }
    }
}
