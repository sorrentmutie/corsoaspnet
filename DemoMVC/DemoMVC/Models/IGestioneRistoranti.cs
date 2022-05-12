using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Models
{
    public interface IGestioneRistoranti
    {
        List<Ristorante> EstraiRistoranti(string tipoCucina);
        ViewModelListaRistoranti EstraiRistorantiPerGenere(string tipoCucina, bool vegano);
        void AggiungiRistorante(Ristorante nuovoRistorante);
        Ristorante EstraiDettaglioRistorante(int id);
        void ModificaRistorante(Ristorante ristorante);
        void CancellaRistorante(int id);
        void AggiungiRecensione(Recensione recensione);
    }

    public class GestioneRistorantiSuSQLServer : IGestioneRistoranti
    {
        public void AggiungiRecensione(Recensione recensione)
        {
            throw new NotImplementedException();
        }

        public void AggiungiRistorante(Ristorante nuovoRistorante)
        {
            throw new NotImplementedException();
        }

        public void CancellaRistorante(int id)
        {
            throw new NotImplementedException();
        }

        public Ristorante EstraiDettaglioRistorante(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ristorante> EstraiRistoranti(string tipoCucina)
        {
            throw new NotImplementedException();
        }

        public ViewModelListaRistoranti EstraiRistorantiPerGenere(string tipoCucina, bool vegano)
        {
            throw new NotImplementedException();
        }

        public void ModificaRistorante(Ristorante ristorante)
        {
            throw new NotImplementedException();
        }
    }
}
