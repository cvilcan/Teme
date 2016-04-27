using BazaarServer.Interfaces;
using BazaarServer.SocketServer;
using BazaarServer.SocketServer.Containers;
using BazaarServer.SocketServer.Interfaces;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
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
			var container = new MyContainer(x =>
			{
				x.For<IProductService>().Use<ProductService>();
				x.For<IProductRepository>().Use<ProductRepository>().SelectConstructor(() => new ProductRepository());
				x.For<IRequestHandler>().Use<RequestHandler>();
				x.For<IUserRepository>().Use<UserRepository>().SelectConstructor(() => new UserRepository());
				x.For<IUserService>().Use<UserService>();
				x.For<AsynchronousSocketListener>().Use<AsynchronousSocketListener>();
                x.For<ProductRepository>().Use<ProductRepository>().SelectConstructor(() => new ProductRepository());
                x.For<BazaarEntities>().Use<BazaarEntities>().SelectConstructor(() => new BazaarEntities());
			});
            container.Inject<IDependencyInjectionContainer>(container);
			AsynchronousSocketListener listener = container.GetInstance<AsynchronousSocketListener>();

			Thread t = new Thread(listener.StartListening);
            t.Start();
            //BazaarServer.WebApiApplication webApi = new BazaarServer.WebApiApplication();
            //webApi.Application_Start();
		}
	}
}
