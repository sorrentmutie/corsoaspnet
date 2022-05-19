using DemoSicurezza.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DemoSicurezza.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersService service;

        public OrdersController()
        {
            service = new OrdersService();
            
        }
        // GET: Orders
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var user = User.Identity;
            return View(service.EstraiTuttiGliOrders());
        }


        public ActionResult IndexForCustomer()
        {
            var user = User.Identity;
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            var customerclaim = claims.FirstOrDefault(c => c.Type == "customerID");
            var customerId = "";
            if (customerclaim != null) customerId = customerclaim.Value;
            return View(service.EstraiOrdersPerCustomerID(customerId));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult IndexForYear(int id)
        {
            return View(service.EstraiTuttiGliOrdersPerAnno(id));
        }

    }
}