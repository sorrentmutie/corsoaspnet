using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class RistorantiController : Controller
    {
        private readonly IGestioneRistoranti gestioneRistoranti;
     //   private readonly IGestioneDate gestioneDate;

        public RistorantiController(IGestioneRistoranti gestioneRistoranti)
        {
            this.gestioneRistoranti = gestioneRistoranti;
          //  this.gestioneDate = gestioneDate;
        }

        // private GestioneRistoranti gestioneRistoranti2 = new GestioneRistoranti();
        
        // GET: Ristoranti
        public ActionResult Index()
        {
            // gestioneRistoranti2.StringaConnessione = ".....";
            //if (gestioneDate.DammiOraCorrente().Hour > 12)
            //{
            //    // lista ristoranti aperti dopo le 12
            //}
            //else
            //{
            //    // risotranti dove fare colazione
            //}
           // List<Ristorante> listaRistoranti = new List<Ristorante>();
           return View(gestioneRistoranti.EstraiRistoranti("Indiano"));
        }
        public ActionResult Elenco()
        {
            return View(gestioneRistoranti.EstraiRistorantiPerGenere("Indiano", false));
        }

        [HttpGet]
        public ActionResult Crea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crea(Ristorante nuovoRistorante)
        {
            try
            {
                gestioneRistoranti.AggiungiRistorante(nuovoRistorante);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet()]
        public ActionResult Dettaglio(int id)
        {
            return View(gestioneRistoranti.EstraiDettaglioRistorante(id));
        }

        [HttpGet]
        public ActionResult Modifica(int id)
        {
            return View(gestioneRistoranti.EstraiDettaglioRistorante(id));
        }

        [HttpPost]
        public ActionResult Modifica(Ristorante  ristorante)
        {
            gestioneRistoranti.ModificaRistorante(ristorante);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Elimina(int id)
        {
            return View(gestioneRistoranti.EstraiDettaglioRistorante(id));
        }

        [HttpPost]
        public ActionResult Elimina(Ristorante ristorante)
        {
            gestioneRistoranti.CancellaRistorante(ristorante.Id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AggiungiRecensioneARistorante(int id)
        {
            //var ristorante = gestioneRistoranti.EstraiDettaglioRistorante(id);
            var recensione = new Recensione { Data = DateTime.Now, IdRistorante  = id };
            return View(recensione);
        }

        [HttpPost]
        public ActionResult AggiungiRecensioneARistorante(Recensione recensione)
        {
            gestioneRistoranti.AggiungiRecensione(recensione);
            return RedirectToAction("Index");
        }
    }
}