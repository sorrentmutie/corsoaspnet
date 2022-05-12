using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.ViewModels
{
    public class ViewModelProdotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fornitore { get; set; }
        public string Categoria { get; set; }
        public decimal Prezzo { get; set; }
        public int UnitaInMagazzino { get; set; }
    }
}