using Common.DataLayer.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace Common.DataLayer
{
    public static class CustomerData
    {
        public static List<Customer> CustomerGet(IConfig config)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (Connection connection = new Connection(config))
                {
                    DbCommand dbCommand = connection.ReturnCommand(Enums.Procedures.Sp_CustomerDetails_Get.ToString(), true);
                    DbDataReader dr = dbCommand.ExecuteReader();


                    while (dr.Read())
                        customers.Add(FillFromReader(new Customer(), dr));
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customers;
        }

        private static Customer FillFromReader(Customer customer, DbDataReader dr)
        {
            customer.ID = Connection.LoadInt32(dr, "ID");
            customer.Name = Connection.LoadString(dr, "Name");
            customer.Surename = Connection.LoadString(dr, "Surname");
            customer.Balance = Connection.LoadDecimal(dr, "Balance");
            return customer;
        }
    }
}