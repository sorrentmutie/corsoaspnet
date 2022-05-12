using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.ViewModels
{
    public class ViewModelFornitore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Città { get; set; }
        public string Telefono { get; set; }
    }
}