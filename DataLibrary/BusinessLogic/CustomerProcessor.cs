using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CustomerProcessor
    {
        public static int CreateCustomer(int customerID, string fullName, string phoneNumber,
            string emailAddress)
        {
            DALCustomerModel data = new DALCustomerModel
            {
                CustomerId = customerID,
                FullName = fullName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };

            string sql = @"INSERT INTO dbo.CustomersTable (CustomerId, FullName, PhoneNumber, EmailAddress) values (@CustomerId, @FullName, @PhoneNumber, @EmailAddress)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<DALCustomerModel> LoadCustomers()
        {
            string sql = @"SELECT Id, CustomerId, FullName, PhoneNumber, EmailAddress from dbo.CustomersTable";

            return SqlDataAccess.LoadData<DALCustomerModel>(sql);
        }
    }
}
