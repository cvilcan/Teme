using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
	public interface IUserRepository
	{
		Guid Login(string username, string hashedPassword);
		Guid Register(string username, string hashedPassword);
        Tuple<int, string> GetUserDetails(Guid loginGuid);
	}
}
