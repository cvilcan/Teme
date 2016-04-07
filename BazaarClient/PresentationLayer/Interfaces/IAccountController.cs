using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
	public interface IAccountController
	{
		Guid Login(string username, string hashedPassword);
		Guid Register(string username, string hashedPassword);
        void Logout(Guid guid);
    }
}
