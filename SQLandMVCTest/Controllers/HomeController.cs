using DataLibrary.BusinessLogic;
using SQLandMVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models;

namespace SQLandMVCTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewCustomers()
        {
            ViewBag.Message = "The List of Cutomers";

            var data = CustomerProcessor.LoadCustomers();
            List<CustomerModel> customers = new List<CustomerModel>();

            foreach (var row in data)
            {
                customers.Add(new CustomerModel
                {
                    CustomerID = row.CustomerId,
                    Name = row.FullName,
                    PhoneNumber = row.PhoneNumber,
                    Email = row.EmailAddress
                });
            }

            return View(customers);
        }

        public ActionResult CreateCustomer()
        {
            List<OrderModel> orders = new List<OrderModel>();
            foreach (var row in OrderProcessor.LoadOrders())
            {
                orders.Add(new OrderModel
                {
                    OrderID = row.OrderId,
                    Date = row.Date
                });
            }

            ViewBag.Message = "Customer creation";
            ViewBag.Orders = orders;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(CustomerModel model, int[] selectedOrders)
        {
            if(ModelState.IsValid)
            {
                if (selectedOrders != null)
                {
                    foreach (var order in OrderProcessor.LoadOrders().Where(ord => selectedOrders.Contains(ord.Id)))
                    {
                        model.Orders.Add(new OrderModel
                        {
                            OrderID = order.OrderId,
                            Date = order.Date
                        });
                    }
                }
                int recordsCreated = CustomerProcessor.CreateCustomer
                    (
                        model.CustomerID, 
                        model.Name, 
                        model.PhoneNumber, 
                        model.Email
                    );

                foreach (var item in model.Orders)
                {
                    CustomersOrdersProcessor.CreateCustomersOrders
                        (
                            model.CustomerID,
                            item.OrderID
                        );
                }
                return RedirectToAction("ViewCustomers");
            }
            return View();
        }

        public ActionResult ViewCustomersDetails(int id = 0)
        {
            //Получаем покупателя с идентификатором равным id
            var data = CustomerProcessor.LoadCustomers().Where(c => c.CustomerId == id).FirstOrDefault();

            if(data == null)
            {
                return RedirectToAction("ViewCustomers");
            }

            //Получаем из списка заказов все заказы данного покупателя
            var dataOrdersCustomers = CustomersOrdersProcessor.LoadCustomersOrders().Where(co => co.CustomerId == data.CustomerId) as List<DALCustomersOrdersModel>;

            //Теперь нужно найти по идентификаторам заказов сами заказы
            //OrderId - уникальные
            var DALorders = new List<DALOrdersModel>();
            var orders = new List<OrderModel>();

            CustomerModel customer;
            if (dataOrdersCustomers != null)
            {
                foreach (var item in dataOrdersCustomers)
                {
                    DALorders.Add(OrderProcessor.LoadOrders().Where(oid => oid.OrderId == item.OrderId).FirstOrDefault());
                }


                foreach (var dalOrder in DALorders)
                {
                    orders.Add(new OrderModel
                    {
                        OrderID = dalOrder.OrderId,
                        Date = dalOrder.Date
                    });
                }

                customer = new CustomerModel
                {
                    CustomerID = data.CustomerId,
                    Name = data.FullName,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.EmailAddress,
                    Orders = orders
                };
            }
            else
            {
                customer = new CustomerModel
                {
                    CustomerID = data.CustomerId,
                    Name = data.FullName,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.EmailAddress,
                };
            }
            
            
            return View(customer);
        }
    }
}