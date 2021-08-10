using System;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace project
{
    public class Connection 
    {
        SqliteConnectionStringBuilder connectionString = new SqliteConnectionStringBuilder();
        SqliteConnection conn = new SqliteConnection();                 

        public Connection()
        {      
            connectionString.DataSource = "DataSource=TasksApp.db";          
            SqliteConnection conn = new SqliteConnection(connectionString.DataSource);
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