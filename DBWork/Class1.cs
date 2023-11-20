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
        DataBase dataBase = new DataBase();
        public DataTable table = new DataTable();

        public void GetByID(int a)
        {
            table.Clear();
            string query;
            query = $"select * from PikParse where messageId = {a}";
            SqlCommand sqlCommand = new SqlCommand(query,dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(table);
        }
        public void GetByName(string a)
        {
            table.Clear();
            string query;
            query = $"select * from PikParse where messageName = '{a}'";
            SqlCommand sqlCommand = new SqlCommand(query, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(table);
        }
        public void Add(int id, string name, string message)
        {
            string query;
            query = $"insert PikParse values ({id},'{name}','{message}')";
            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            dataBase.OpenConnection();
            command.ExecuteNonQuery();
            dataBase.CloseConnection();
        }
        public void Update(int id, string message)
        {
            string query;
            query = $"update PikParse set messageContent = '{message}' where messageId = {id}";
            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            dataBase.OpenConnection();
            command.ExecuteNonQuery();
            dataBase.CloseConnection();
        }
        public void Delete(int id)
        {
            string query;
            query = $"delete PikParse where messageId = {id}";
            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            dataBase.OpenConnection();
            command.ExecuteNonQuery();
            dataBase.CloseConnection();
        }
        public bool IsRecordExists(int id, string name, string message)
        {
            table.Clear();
            string query;
            query = $"select * from PikParse where messageId = {id} and messageName = '{name}' and messageContent = '{message}'";
            SqlCommand sqlCommand = new SqlCommand(query, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
