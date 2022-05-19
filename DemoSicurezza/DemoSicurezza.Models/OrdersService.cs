using DemoSicurezza.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSicurezza.Models
{
    public interface IOrdersService
    {
        List<OrderForAdministratorsViewModel> EstraiTuttiGliOrders();
        List<OrderForAdministratorsViewModel> EstraiTuttiGliOrdersPerAnno(int anno);
        OrdersPageForCustomerViewModel EstraiOrdersPerCustomerID(string customerID);
    }

    public class OrdersService : IOrdersService
    {
        private readonly NorthwindEntities db;
        public OrdersService()
        {
            db = new NorthwindEntities();
        }

        public OrdersPageForCustomerViewModel EstraiOrdersPerCustomerID(string customerID)
        {
            var orders = db.Orders.Where(o => o.CustomerID == customerID)
                .ToList();



            return new OrdersPageForCustomerViewModel
            {
                NumberOfOrders = orders.Count,
                TotalOfOrders = orders.Sum(o => o.Order_Details.Sum(od => od.Quantity * od.UnitPrice)),
                Orders = orders.Select(o => new OrderForCustomerViewModel
                {
                    OrderId = o.OrderID,
                    OrderDate = o.OrderDate,
                    Total = o.Order_Details.Sum(od => od.Quantity * od.UnitPrice)
                }).ToList()

            };
        }

        public List<OrderForAdministratorsViewModel> EstraiTuttiGliOrders()
        {
            return db.Orders.Select(ordine => new OrderForAdministratorsViewModel { 
             OrderId = ordine.OrderID,
             OrderDate = ordine.OrderDate  ,
             CompanyName = ordine.Customers.CompanyName,
              EmployeeFullName = ordine.Employees.FirstName + " " + ordine.Employees.LastName           
            }).ToList();
        }

        public List<OrderForAdministratorsViewModel> EstraiTuttiGliOrdersPerAnno(int anno)
        {
            return db.Orders
                .Where(ordine => ordine.OrderDate.Value.Year == anno).Select(ordine => new OrderForAdministratorsViewModel
            {
                OrderId = ordine.OrderID,
                OrderDate = ordine.OrderDate,
                CompanyName = ordine.Customers.CompanyName,
                EmployeeFullName = ordine.Employees.FirstName + " " + ordine.Employees.LastName
            }).ToList();
        }
    }
}
