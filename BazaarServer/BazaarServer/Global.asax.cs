using BazaarServer.DependencyResolution;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BazaarServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public void Application_Start()
        {
            //Container container = new Container(x =>
            //{
            //    x.For<IProductService>().Use<ProductService>();
            //    x.For<IProductRepository>().Use<ProductRepository>();
            //    x.For<IUserRepository>().Use<UserRepository>();
            //    x.For<IUserService>().Use<UserService>();
            //});
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
