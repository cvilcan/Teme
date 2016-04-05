using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
	public interface IUserRepository
	{
		int Login(string username, string hashedPassword);
		int Register(string username, string hashedPassword);
	}
}
