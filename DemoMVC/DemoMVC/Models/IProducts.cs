using DemoMVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DemoMVC.Models
{
    public interface IProducts
    {
        List<Products> GetProducts();
        List<ViewModelProdotto> EstraiViewModelProdotti();
        List<ViewModelProdotto> EstraiViewModelProdottiPerCategoria(int id);
        ViewModelProdotto EstraiViewModelUltimoProdottoAggiunto();
    }

    public interface ICategories
    {
        void AggiungiCategoria(string Nome, string Descrizione);
    }


  

    public class NorthwindCategoriesData : ICategories
    {
        private readonly NorthwindEntities database;
        public NorthwindCategoriesData(NorthwindEntities database)
        {
            this.database = database;
        }
        public void AggiungiCategoria(string Nome, string Descrizione)
        {
            database.Categories.Add(new Categories
            {
                CategoryName = Nome,
                Description = Descrizione
            });
            database.SaveChanges();
        }
    }

    public class NorthwindData : IProducts
    {
        NorthwindEntities database;
        public NorthwindData()
        {
            database = new NorthwindEntities();
        }

        public List<ViewModelProdotto> EstraiViewModelProdotti()
        {
            var products = database.Products
                .Where(p => p.UnitsInStock > 0)
                .OrderByDescending( p => p.UnitsInStock)
                .Select(
                prodotto => new ViewModelProdotto
                {
                    Categoria = prodotto.Categories.CategoryName,
                    Fornitore = prodotto.Suppliers.CompanyName,
                    Id = prodotto.ProductID,
                    Nome = prodotto.ProductName,
                    Prezzo = prodotto.UnitPrice.HasValue ? prodotto.UnitPrice.Value : 0M,
                    UnitaInMagazzino = (int) prodotto.UnitsInStock
                }); 
            return products.ToList();
        }

        public List<ViewModelProdotto> EstraiViewModelProdottiPerCategoria(int id)
        {
            var products = database.Products
               .Where(p => p.UnitsInStock > 0 && p.CategoryID == id)
               .OrderByDescending(p => p.UnitsInStock)
               .Select(
               prodotto => new ViewModelProdotto
               {
                   Categoria = prodotto.Categories.CategoryName,
                   Fornitore = prodotto.Suppliers.CompanyName,
                   Id = prodotto.ProductID,
                   Nome = prodotto.ProductName,
                   Prezzo = prodotto.UnitPrice.HasValue ? prodotto.UnitPrice.Value : 0M,
                   UnitaInMagazzino = (int)prodotto.UnitsInStock
               });
            return products.ToList();
        }

        public ViewModelProdotto EstraiViewModelUltimoProdottoAggiunto()
        {
            var prodotto = database.Products
              .OrderByDescending(p => p.ProductID)
              .FirstOrDefault(p => p.UnitsInStock > 0);

            return new ViewModelProdotto
            {
                Categoria = prodotto.Categories.CategoryName,
                Fornitore = prodotto.Suppliers.CompanyName,
                Id = prodotto.ProductID,
                Nome = prodotto.ProductName,
                Prezzo = prodotto.UnitPrice.HasValue ? prodotto.UnitPrice.Value : 0M,
                UnitaInMagazzino = (int)prodotto.UnitsInStock
            };

            //.Select(
            //prodotto => new ViewModelProdotto
            //{
            //    Categoria = prodotto.Categories.CategoryName,
            //    Fornitore = prodotto.Suppliers.CompanyName,
            //    Id = prodotto.ProductID,
            //    Nome = prodotto.ProductName,
            //    Prezzo = prodotto.UnitPrice.HasValue ? prodotto.UnitPrice.Value : 0M,
            //    UnitaInMagazzino = (int)prodotto.UnitsInStock
            //});
        }

        public List<Products> GetProducts()
        {
            var products = database.Products.ToList();
            return products;
        }
    }

}
