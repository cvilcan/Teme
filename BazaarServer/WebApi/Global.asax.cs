using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using ConfigurationManager.AppSettings;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NetworkServer
{
    public class Application : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var container = new Container(x =>
            //{
            //    x.For<IProductService>().Use<ProductService>();
            //    x.For<IProductRepository>().Use<ProductRepository>();
            //    x.For<IUserRepository>().Use<UserRepository>();
            //    x.For<IUserService>().Use<UserService>();
            //});
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(ConfigurationManager.AppSettings["BasePath"])Config.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
