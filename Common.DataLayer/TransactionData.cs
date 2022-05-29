using System.Data.Common;
using Common.DataLayer.Models;
using System.Data.SqlClient;

namespace Common.DataLayer
{
    public static class TransactionData
    {
        public static int TransactionAdd(IConfig config, int IdAccount, decimal InitialCredit)
        {
            using (Connection connection = new Connection(config))
            {
                DbCommand dbCommand = connection.ReturnCommand(Enums.Procedures.Sp_Transaction_Add.ToString(), true);
                dbCommand.Parameters.Add(new SqlParameter("@IdAccount", IdAccount));
                dbCommand.Parameters.Add(new SqlParameter("@InitialCredit", InitialCredit));
                var result = dbCommand.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
        public static List<Transaction> TransactionGet(Config config)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (Connection connection = new Connection(config))
            {
                DbCommand dbCommand = connection.ReturnCommand(Enums.Procedures.Sp_Transactions_Get.ToString(), true);
                DbDataReader dr = dbCommand.ExecuteReader();
                while (dr.Read())
                    transactions.Add(FillFromReader(new Transaction(), dr));
                dr.Close();
                return transactions;
            }
        }

        private static Transaction FillFromReader(Transaction transaction, DbDataReader dr)
        {
            transaction.ID = Connection.LoadInt32(dr, "ID");
            transaction.IdAccount = Connection.LoadInt32(dr, "IdAccount");
            transaction.Amount = Connection.LoadDecimal(dr, "Amount");
            transaction.IdCustomer = Connection.LoadInt32(dr, "IdCustomer");
            return transaction;
        }
    }
}