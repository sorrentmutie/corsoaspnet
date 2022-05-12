using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class GestioneRistoranti: IGestioneRistoranti
    {
        public static List<Ristorante> listaRistoranti = new List<Ristorante>();
        public static string TipoCucina = "Indiano";
        // public string StringaConnessione { get; set; }
        private string StringaConnessione = ""; 

        public GestioneRistoranti()
        {
            if(listaRistoranti.Count == 0)
            {
                listaRistoranti.Add(new Ristorante
                {
                    Id = 31,
                    Indirizzo = "Via del Pino 1, Napoli",
                    Nome = "Pizzeria Bella Napoli",
                    TipoCucina = "Pizzeria",
                    Recensioni = new List<Recensione>
                    {
                        new Recensione { Data = DateTime.Today, Testo = "Buonissimo", Voto=10},
                        new Recensione { Data = DateTime.Today, Testo = "Pessimo", Voto=1},
                        new Recensione { Data = DateTime.Today, Testo = "Decento", Voto=5},
                    }
                });
                listaRistoranti.Add(new Ristorante
                {
                    Id = 2,
                    Indirizzo = "Via della Quercia 1, Napoli",
                    Nome = "La grande muraglia",
                    TipoCucina = "Cinese"
                });
                listaRistoranti.Add(new Ristorante
                {
                    Id = 3,
                    Indirizzo = "Via del Duomo, Napoli",
                    Nome = "Braceria Brasiliana",
                    TipoCucina = "Carne"
                });
                listaRistoranti.Add(new Ristorante
                {
                    Id = 4,
                    Indirizzo = "Via Mergellina, Napoli",
                    Nome = "Nuova Delhi",
                    TipoCucina = "Indiano"
                });

            }
        }


        public List<Ristorante> EstraiRistoranti(string tipoCucina)
        {
            //var maxId = 0;
            //for (int i = 0; i < listaRistoranti.Count; i++)
            //{
            //            if(listaRistoranti[i].Id > maxId)
            //    {
            //        maxId = listaRistoranti[i].Id;
            //    }
            //}

           

            //  return listaRistoranti.Where(ristorante => ristorante.TipoCucina == tipoCucina).ToList();
            return listaRistoranti;
        }

        public ViewModelListaRistoranti EstraiRistorantiPerGenere(string tipoCucina, bool vegano)
        {
            var ristoranti = 
                listaRistoranti.Where(ristorante => ristorante.TipoCucina == tipoCucina
                 && ristorante.Vegano == vegano).ToList();
            return new ViewModelListaRistoranti
            {
                Ristoranti = ristoranti,
                TipoCucina = tipoCucina,
                Vegano = vegano
            };
        }

        public void AggiungiRistorante(Ristorante nuovoRistorante)
        {
            // throw new Exception("Errore gravissimo");
            var maxId = listaRistoranti.Max(x => x.Id);
            nuovoRistorante.Id = maxId + 1;

            listaRistoranti.Add(nuovoRistorante);
        }

        public Ristorante EstraiDettaglioRistorante(int id)
        {
            var ristorante = listaRistoranti.FirstOrDefault(x => x.Id == id);
            return ristorante;
        }

        public void ModificaRistorante(Ristorante ristorante)
        {
            var ristoranteDb = listaRistoranti.FirstOrDefault(x => x.Id == ristorante.Id);
            if(ristoranteDb != null)
            {
                listaRistoranti.Remove(ristoranteDb);
                listaRistoranti.Add(ristorante);
            }
        }

        public void CancellaRistorante(int id)
        {
            var ristoranteDb = listaRistoranti.FirstOrDefault(x => x.Id == id);
            if (ristoranteDb != null)
            {
                listaRistoranti.Remove(ristoranteDb);
            }
        }

        public void AggiungiRecensione (Recensione recensione)
        {
            var ristoranteDb = listaRistoranti.FirstOrDefault(x => x.Id == recensione.IdRistorante);
            if(ristoranteDb != null)
            {
                ristoranteDb.Recensioni.Add(recensione);
            }
        }
    }
}