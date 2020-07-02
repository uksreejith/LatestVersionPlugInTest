using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilterTest.Filters;

namespace FilterTest.Controllers
{
    [APIVersionFilter]
    public class TestController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            return Json("Hello World");
        }
    }
}