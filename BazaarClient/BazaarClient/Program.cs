using PresentationLayer.Controllers;
using NetworkModule.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer.Interfaces;
using NetworkModule.Services;
using PresentationLayer.Forms;
using NetworkModule.Services.SocketServices;

namespace NetworkModule
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var container = new Container(x =>
			{
				x.For<IProductController>().Use<ProductController>();
				x.For<IAsynchronousClient>().Use<AsynchronousClient>();
				x.For<IProductService>().Use<NetworkModule.Services.SocketServices.ProductService>();
				x.For<IAccountController>().Use<AccountController>();
				x.For<IUserService>().Use<NetworkModule.Services.SocketServices.UserService>();
				x.For<Bazaar>().Use<Bazaar>();
				x.For<Login>().Use<Login>();
				x.For<ViewCart>().Use<ViewCart>();
			});
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.GetInstance<Login>());
		}
	}
}
