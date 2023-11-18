using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWork
{
    public class Class1
    {
        DataBase dataBase;

        public void GetByID(int a)
        {
            string query;
            query = $"select * from PikParse where messageID = '{a}'";
            SqlCommand sqlCommand = new SqlCommand(query,dataBase.getConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(table);
        }
        public void GetByName(string a)
        {
            string query;
            query = $"select * from PikParse where PPname = '{a}'";
            SqlCommand sqlCommand = new SqlCommand(query, dataBase.getConnection());
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(table);
        }
        public void Add(int id, string name, string message)
        {
            string query;
            query = $"insert PikParse values ({id},'{name}','{message}')";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            command.ExecuteNonQuery();
            dataBase.closeConnection();
        }
        public void Update(int id, string message)
        {
            string query;
            query = $"update PikParse message = '{message}' where PPID = {id}";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            command.ExecuteNonQuery();
            dataBase.closeConnection();
        }
        public void Delete(int id)
        {
            string query;
            query = $"delete PikParse where PPID = {id}";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            command.ExecuteNonQuery();
            dataBase.closeConnection();
        }
    }
}
