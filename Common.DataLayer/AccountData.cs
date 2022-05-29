using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace Common.DataLayer
{
    public static class AccountData
    {
        public static int  CreateAccount(IConfig config,int IdCustomer)
        {
            using (Connection connection = new Connection(config))
            {
                DbCommand dbCommand = connection.ReturnCommand(Enums.Procedures.Sp_Account_Add.ToString(), true);
                dbCommand.Parameters.Add(new SqlParameter("@IdCustomer", IdCustomer));
                var result = dbCommand.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
        
    }
}