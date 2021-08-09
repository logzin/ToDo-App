using System;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;


namespace project
{
    public class Connection 
    {
        SqliteConnection conn = new SqliteConnection();
        SqliteConnectionStringBuilder connectionString = new SqliteConnectionStringBuilder();

        public Connection()
        {      
            connectionString.DataSource = "Data Source=C:\\Users\\logzi\\Documents\\GitHub\\ToDo\\database\\TasksApp.db";
        }

        public SqliteConnection connect()
        {
            SqliteConnection conn = new SqliteConnection(connectionString.DataSource);

            conn.Open();     

            return conn;
        }
        public void disconnect()
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();  
            }         
        }
   
        
    }
}