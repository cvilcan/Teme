using BusinessLayer.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IUserService
	{
		Guid Login(string username, string hashedPassword);
		Guid Register(string username, string hashedPassword);
        UserDetails GetUserDetails(Guid loginToken);
        void Logout(Guid guid);
    }
}
