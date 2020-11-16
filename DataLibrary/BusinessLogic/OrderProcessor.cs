using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class OrderProcessor
    {
        public static int CreateOrder(int orderID, DateTime date)
        {
            DALOrdersModel data = new DALOrdersModel
            {
                OrderId = orderID,
                Date = date
            };

            string sql = @"INSERT INTO dbo.OrdersTable (OrderId, Date) VALUES (@OrderId, @Date)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<DALOrdersModel> LoadOrders()
        {
            string sql = @"SELECT Id, OrderId, Date FROM dbo.OrdersTable";

            return SqlDataAccess.LoadData<DALOrdersModel>(sql);
        }
    }
}
