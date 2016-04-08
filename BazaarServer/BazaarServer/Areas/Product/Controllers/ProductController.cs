using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BazaarServer.Areas.Product.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public string ASD()
        {
            return "ASD";
        }
    }
}
