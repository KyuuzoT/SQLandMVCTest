using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class DALCustomersOrdersModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}
