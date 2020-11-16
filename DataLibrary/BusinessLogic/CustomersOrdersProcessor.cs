using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class CustomersOrdersProcessor
    {
        public static int CreateCustomersOrders(int customerId, int orderId)
        {
            DALCustomersOrdersModel data = new DALCustomersOrdersModel
            {
                CustomerId = customerId,
                OrderId = orderId
            };

            string sql = @"INSERT INTO dbo.CustomersOrdersTable (CustomerId, OrderId) VALUES (@CustomerId, @OrderId)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<DALCustomersOrdersModel> LoadCustomersOrders()
        {
            string sql = @"SELECT Id, CustomerId, OrderId from dbo.CustomersOrdersTable";

            return SqlDataAccess.LoadData<DALCustomersOrdersModel>(sql);
        }
    }
}
