using BazaarServer.Areas.Account.Controllers;
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
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace BazaarServer.DependencyResolution
{
    public class SocketRegistry : Registry
    {
        public SocketRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For<IProductService>().Use<ProductService>();
            For<IProductRepository>().Use<ProductRepository>().SelectConstructor(() => new ProductRepository());
            For<IRequestHandler>().Use<RequestHandler>();
            For<IUserRepository>().Use<UserRepository>().SelectConstructor(() => new UserRepository());
            For<IUserService>().Use<UserService>();
            For<AsynchronousSocketListener>().Use<AsynchronousSocketListener>();
            For<ProductRepository>().Use<ProductRepository>().SelectConstructor(() => new ProductRepository());
            For<BazaarEntities>().Use<BazaarEntities>().SelectConstructor(() => new BazaarEntities());
        }
    }
}