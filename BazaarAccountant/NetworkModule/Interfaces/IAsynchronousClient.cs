using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModule.Interfaces
{
	public interface IAsynchronousClient
	{
		string Send(string message);
	}
}
