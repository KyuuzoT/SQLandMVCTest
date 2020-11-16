using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLandMVCTest.Models
{
    public class OrderModel
    {
        [Display(Name = "Order ID")]
        [Range(0, 999999, ErrorMessage = "ID should match the range between 0 and 999 999")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Date address should be provided")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual ICollection<CustomerModel> Customers { get; set; }

        public OrderModel()
        {
            Customers = new List<CustomerModel>();
        }
    }
}