using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class ViewModelListaRistoranti
    {
        public List<Ristorante> Ristoranti { get; set; }
        public string TipoCucina { get; set; }
        public bool Vegano { get; set; }
    }
}