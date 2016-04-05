using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
	public interface IAccountController
	{
		int Login(string username, string hashedPassword);
		int Register(string username, string hashedPassword);
	}
}
