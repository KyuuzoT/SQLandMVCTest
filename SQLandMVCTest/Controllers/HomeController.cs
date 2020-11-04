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
            List<DALCustomerModel> customers = new List<DALCustomerModel>();

            foreach (var row in data)
            {
                customers.Add(new DALCustomerModel
                {
                    CustomerID = row.CustomerID,
                    FullName = row.FullName,
                    PhoneNumber = row.PhoneNumber,
                    EmailAddress = row.EmailAddress
                });
            }

            return View(customers);
        }

        public ActionResult CreateCustomer()
        {
            ViewBag.Message = "Customer creation";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            if(ModelState.IsValid)
            {
                int recordsCreated = CustomerProcessor.CreateCustomer
                    (
                        model.CustomerID, 
                        model.Name, 
                        model.PhoneNumber, 
                        model.Email
                    );
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}