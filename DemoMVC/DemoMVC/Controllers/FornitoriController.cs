using DemoMVC.ExtensionMethods;
using DemoMVC.Models;
using DemoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class FornitoriController : Controller
    {
        private readonly IDatiGenerici<Suppliers> database;

        public FornitoriController(IDatiGenerici<Suppliers> database)
        {
            this.database = database;
        }

        // GET: Fornitori
        public ActionResult Index()
        {
            var suppliers = database.Estrai().Converti();
            return View(suppliers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Suppliers nuovo)
        {
            database.Aggiungi(nuovo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var fornitore = database.EstraiPerID(id);
            return View(fornitore);
        }


        [HttpGet]
        public JsonResult Esempio()
        {
            var x = new ViewModelFornitore()
            {
                Nome = "Mario",
                Id = 1,
                Città = "Napoli"
            };
            return Json(x, JsonRequestBehavior.AllowGet);
        }
    }
}