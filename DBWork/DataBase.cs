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
        SqlConnection sqlConnection = new SqlConnection(@"Data source=DESKTOP-CMK6F4H\SQLEXPRESS;Initial Catalog=PikabuParse;Integrated Security=true");

        public void openConnection()
        {
            sqlConnection.Open();
        }
        public void closeConnection()
        {
            sqlConnection.Close();
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
