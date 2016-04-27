using NetworkModule.Interfaces;
using NetworkModule.Services.SocketServices;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazaarAccountant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Container container = new Container(x =>
            {
                x.For<IAsynchronousClient>().Use<AsynchronousClient>();
                //x.For<IUserService>().Use<NetworkModule.Services.SocketServices.UserService>();
                x.For<IProductService>().Use<ProductService>();
                x.For<AccountantForm>().Use<AccountantForm>();
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.GetInstance<AccountantForm>());
        }
    }
}
