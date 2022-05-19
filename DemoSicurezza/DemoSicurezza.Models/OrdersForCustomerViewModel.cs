using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSicurezza.Models
{
    public class OrderForCustomerViewModel
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal Total { get; set; }
    }

    public class OrdersPageForCustomerViewModel
    {
        public int NumberOfOrders { get; set; }
        public decimal TotalOfOrders { get; set; }
        public List<OrderForCustomerViewModel> Orders { get; set; }
    }
}
