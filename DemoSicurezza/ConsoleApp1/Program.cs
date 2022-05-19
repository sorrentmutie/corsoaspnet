using DemoSicurezza.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindEntities();
            var categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }
            Console.ReadLine();
        }
    }
}
