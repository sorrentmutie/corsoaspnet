using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducts products;
        private readonly ICategories categories;

        public HomeController(IProducts products, ICategories categories)
        {


            this.products = products;
            this.categories = categories;
        }

        public ActionResult Index()
        {
           // this.categories.AggiungiCategoria("Categoria ZZ", "Bla bla bla");
            return View(products.EstraiViewModelUltimoProdottoAggiunto());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}