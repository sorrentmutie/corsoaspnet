using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Ristorante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome del ristorante è obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Indirizzo Obbligatorio")]
        public string Indirizzo { get; set; }
        [MaxLength(10)]
        public string TipoCucina { get; set; }
        public bool Vegano { get; set; }

        public List<Recensione> Recensioni { get; set; } = new List<Recensione>();
    }
}