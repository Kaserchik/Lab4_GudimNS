using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    internal class DataBase
    {
        readonly SqlConnection sqlConnection = new SqlConnection(@"Data source=MY-DESKTOP-PC\SQLEXPRESS;Initial Catalog=PikabuParse;Integrated Security=true");

        public void OpenConnection()
        {
            sqlConnection.Open();
        }
        public void CloseConnection()
        {
            sqlConnection.Close();
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
