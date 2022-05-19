using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSicurezza.Models
{
    public class OrderForAdministratorsViewModel
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
