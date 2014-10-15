using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImbarkPlatform.Areas.AccountManagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /AccountManagement/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}
