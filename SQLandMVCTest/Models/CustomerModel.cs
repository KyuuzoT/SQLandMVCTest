using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLandMVCTest.Models
{
    public class CustomerModel
    {
        [Display(Name = "Customer ID")]
        [Range(0, 999999, ErrorMessage ="ID should match the range between 0 and 999 999")]
        public int CustomerID { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Customer SHOULD have name")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address should be provided")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Information
        {
            get
            {
                return $"ID: {CustomerID} | Name: {Name} | Phone: {PhoneNumber}";
            }
        }

        public virtual ICollection<OrderModel> Orders { get; set; }

        public CustomerModel()
        {
            Orders = new List<OrderModel>();
        }
    }
}