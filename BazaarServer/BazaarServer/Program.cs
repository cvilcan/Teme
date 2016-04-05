using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NetworkServer;
using NetworkServer.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarServer
{
	public class Program
	{
		static void Main(string[] args)
		{
			var container = new Container(x =>
			{
				x.For<IProductService>().Use<ProductService>();
				x.For<IProductRepository>().Use<ProductRepository>();
				x.For<IRequestHandler>().Use<RequestHandler>();
				x.For<IUserRepository>().Use<UserRepository>();
				x.For<IUserService>().Use<UserService>();
				x.For<AsynchronousSocketListener>().Use<AsynchronousSocketListener>();
			});
			AsynchronousSocketListener listener = container.GetInstance<AsynchronousSocketListener>();
			listener.StartListening();
		}
	}
}
