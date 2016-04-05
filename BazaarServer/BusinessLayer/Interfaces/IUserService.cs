using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IUserService
	{
		int Login(string username, string hashedPassword);
		int Register(string username, string hashedPassword);
	}
}
