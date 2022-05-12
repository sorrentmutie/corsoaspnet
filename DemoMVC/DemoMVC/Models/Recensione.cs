using DataAnnotationsExtensions;
using System;

namespace DemoMVC.Models
{
    public class Recensione
    {
        public string Testo { get; set; }
        public DateTime Data { get; set; }
        [Min(1)]
        [Max(10)]
        public int Voto { get; set; }
        public int IdRistorante { get; set; }
    }
}