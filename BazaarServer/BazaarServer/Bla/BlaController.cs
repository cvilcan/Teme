using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BazaarServer.Bla
{
    public class BlaController : Controller
    {
        //
        // GET: /Bla/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
	}
}