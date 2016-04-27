using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModule.Interfaces
{
	public interface IUserService
	{
		Guid Login(string username, string hashedPassword);
		Guid Register(string username, string hashedPassword);
        void Logout(Guid guid);
    }
}
