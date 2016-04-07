using BazaarServer.Interfaces;
using BazaarServer.SocketServer;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BazaarServerSocketStartup
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
			Thread t = new Thread(listener.StartListening);
            t.Start();
            //BazaarServer.WebApiApplication webApi = new BazaarServer.WebApiApplication();
            //webApi.Application_Start();
		}
	}
}
