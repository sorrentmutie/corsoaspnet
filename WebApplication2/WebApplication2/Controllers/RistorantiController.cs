using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RistorantiController : ApiController
    {

        [HttpGet]
        public List<Ristorante> TrovaRistoranti()
        {
            var ristoranti = new List<Ristorante>();
            ristoranti.Add(new Ristorante { Id = 1, Nome = "Bella Napoli" });
            ristoranti.Add(new Ristorante { Id = 2, Nome = "Trattoria Romana" });
            return ristoranti;
        }

       

        // POST PUT DELETE PATCH GET (BY id)

        [HttpGet]
        public Ristorante TrovaRistorante(int id)
        {
            var ristorante = new Ristorante { Id = id, Nome = "Bella Napoli" };
            return ristorante;
        }
    }
}
