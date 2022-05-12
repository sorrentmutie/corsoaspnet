using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts database;

        public ProductsController(IProducts database)
        {
            this.database = database;
        }
        // GET: Products
        public ActionResult Index()
        {
            var prodotti = database.EstraiViewModelProdotti();
            return View(prodotti);
        }

        public ActionResult MostraProdottiPerCategoria(int id)
        {
            return View(database.EstraiViewModelProdottiPerCategoria(id));
        }

    }
}