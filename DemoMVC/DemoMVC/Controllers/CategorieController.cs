using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class CategorieController : Controller
    {
        private readonly IDatiGenerici<Categories> database;

        public CategorieController(IDatiGenerici<Categories> database)
        {
            this.database = database;
        }

        // GET: Categorie
        public ActionResult Index()
        {
            return View(this.database.Estrai());
        }
    }
}