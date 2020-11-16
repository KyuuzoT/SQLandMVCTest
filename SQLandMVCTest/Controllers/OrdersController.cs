using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.BusinessLogic;
using SQLandMVCTest.Models;

namespace SQLandMVCTest.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            ViewBag.Message = "Order creation";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = OrderProcessor.CreateOrder
                    (
                        model.OrderID,
                        model.Date
                    );
                return RedirectToAction("ViewOrders");
            }
            return View();
        }

        public ActionResult ViewOrders()
        {
            ViewBag.Message = "The List of Orders";

            var data = OrderProcessor.LoadOrders();
            List<OrderModel> orders = new List<OrderModel>();

            foreach (var row in data)
            {
                orders.Add(new OrderModel
                {
                    OrderID = row.OrderId,
                    Date = row.Date
                });
            }

            return View(orders);
        }
    }
}
