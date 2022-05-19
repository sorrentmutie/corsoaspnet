using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoSicurezza.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[Route("provamvc/{p1}/prova/{p2?}")]
        //[Route("provamvc/{p1}/secondoprova/{p2}")]
        public ActionResult About(int p1, int p2 = 0)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var utente = User.Identity;
           

            return View();
        }
    }
}