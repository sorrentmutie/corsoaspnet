using DemoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.ExtensionMethods
{
    public static class NorthwindExtensions
    {
        public static ViewModelFornitore ConvertiInViewModel(this Suppliers supplier)
        {
            return new ViewModelFornitore
            {
                Id = supplier.SupplierID,
                Città = supplier.City,
                Telefono = supplier.Phone,
                Nome = supplier.CompanyName
            };
        }

        public static List<ViewModelFornitore> Converti(this IEnumerable<Suppliers> suppliers)
        {
            var lista = new List<ViewModelFornitore>();

            foreach (var item in suppliers)
            {
                lista.Add(item.ConvertiInViewModel());
            }

            return lista;
        }

    }
}