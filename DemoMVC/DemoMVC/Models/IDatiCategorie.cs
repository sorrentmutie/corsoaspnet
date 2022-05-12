using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Models
{
    public interface IDatiGenerici<T> where T : class
    {
        void Aggiungi(T nuovo);
        IEnumerable<T> Estrai();
        IEnumerable<T> EstraiPerPagina(int pagina, int elementi);
        void Aggiorna(T daAggiornare);
        void Cancella(int id);
        T EstraiPerID(int id);
    }

    public class RepositorySQLServer<T> : IDatiGenerici<T> where T : class
    {
        private readonly NorthwindEntities database;
        private readonly DbSet<T> tabella;

        public RepositorySQLServer()
        {
            database = new NorthwindEntities();
            tabella = database.Set<T>();
        }

        public void Aggiorna(T daAggiornare)
        {
            database.Entry(daAggiornare).State = EntityState.Modified;
            database.SaveChanges();
        }

        public void Aggiungi(T nuovo)
        {
            tabella.Add(nuovo);
            database.SaveChanges();
        }

        public void Cancella(int id)
        {
            var elemento = EstraiPerID(id);
            if (elemento != null)
            {
                database.Entry(elemento).State = EntityState.Deleted;
                database.SaveChanges();
            }
        }

        public IEnumerable<T> Estrai()
        {
            return tabella;
        }

        public T EstraiPerID(int id)
        {
            return tabella.Find(id);
        }

        public IEnumerable<T> EstraiPerPagina(int pagina, int elementi)
        {
            return Estrai().Skip((pagina - 1) * elementi).Take(elementi);
        }
    }

}
