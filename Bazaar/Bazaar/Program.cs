using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StructureMap;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Bazaar.Controllers;
using DataAccessLayer.Interfaces;
using DataAccessLayer;
using Bazaar.Forms;

namespace Bazaar
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
					x.For<IProductService>().Use<ProductService>();
					x.For<IProductRepository>().Use<ProductRepository>();
					x.For<IProductController>().Use<ProductController>();
					x.For<Bazaar>().Use<Bazaar>();
				});
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.GetInstance<Bazaar>());
		}
	}
}
