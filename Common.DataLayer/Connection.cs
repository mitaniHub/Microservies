using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Common.DataLayer
{
    public class Connection : IDisposable
    {
        #region Properties
        public DbConnection Conn { get; set; }
        private readonly IConfig _config;
        
        #endregion

        #region Constructors
        public Connection(IConfig config)
        {
            _config = config;
            Conn = new SqlConnection(_config.SqlConnectionString);
            OpenConnection();
        }
        
        #endregion

        #region Methods

        #region Connection Methods
        public bool OpenConnection()
        {
            try
            {
                if (this.Conn.State == ConnectionState.Closed)
                    Conn.Open();
            }
            catch (Exception err)
            {
                //Log4net
                return false;
            }
            return true;
        }

        public bool CloseConnection()
        {
            try
            {
                if (Conn.State != ConnectionState.Closed)
                    Conn.Close();
            }
            catch (Exception err)
            {
               
                return false;
            }
            return true;
        }
        #endregion

        #region Data Methods
        public DbParameter GetParameter(string name, object value)
        {
            DbParameter parameter = null;
            try
            {
                parameter = new SqlParameter("@" + name, value);
            }
            catch (Exception err)
            {
            }
            return parameter;
        }

       
        public DbCommand ReturnCommand(string query, bool isProcedure )
        {
            DbCommand cmd = new SqlCommand();
            try
            {
                 cmd = new SqlCommand(query, Conn as SqlConnection);
                 cmd.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                 cmd.CommandTimeout = 0;
            }
            catch (Exception err)
            {
               
            }
            return cmd;
        }

        public object ReturnScalar(string query, bool isProcedure, DbCommand cmd)
        {
            dynamic Result = null;
            try
            {
                cmd = cmd ?? ReturnCommand(query, isProcedure);
                Result = cmd.ExecuteScalar();
            }
            catch (Exception err)
            {
                
            }
            return Result;
        }


        #endregion

        #region Convertion Methods
        public static short LoadInt16(DbDataReader reader, string index, short defaultValue = 0)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToInt16(Convert.ToDecimal(reader[index]));
        }

        public static int LoadInt32(DbDataReader reader, string index, int defaultValue = 0)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToInt32(Convert.ToDecimal(reader[index]));
        }

        public static long LoadInt64(DbDataReader reader, string index, long defaultValue = 0)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToInt64(Convert.ToDecimal(reader[index]));
        }

        public static string LoadString(DbDataReader reader, string index, string defaultValue = "")
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return reader[index].ToString();
        }

        public static decimal LoadDecimal(DbDataReader reader, string index, decimal defaultValue = 0)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToDecimal(reader[index]);
        }

        public static float LoadFloat(DbDataReader reader, string index, float defaultValue = 0)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return float.Parse(reader[index].ToString());
        }

        public static double LoadDouble(DbDataReader reader, string index, double defaultValue = 0)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToDouble(Convert.ToDecimal(reader[index]));
        }

        public static char LoadChar(DbDataReader reader, string index, char defaultValue = ' ')
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToChar(reader[index]);
        }

        public static bool LoadBool(DbDataReader reader, string index, bool defaultValue = false)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToBoolean(reader[index]);
        }


        public static byte[] LoadBytes(DbDataReader reader, string index, byte[] defaultValue = null)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return (byte[])reader[index];
        }

        public static DateTime LoadDateTime(DbDataReader reader, string index, DateTime defaultValue)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return Convert.ToDateTime(reader[index]);
        }

       
        public static T LoadEnum<T>(DbDataReader reader, string index, T defaultValue)
        {
            if (reader[index] == DBNull.Value)
                return defaultValue;
            else
                return (T)Enum.Parse(typeof(T), reader[index].ToString());
        }
        #endregion

        public void Dispose()
        {
            CloseConnection();
            Conn.Dispose();
        }
        #endregion
    }
}
