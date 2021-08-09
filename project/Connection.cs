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
            connectionString.DataSource = "Data Source=C:\\Users\\logzi\\Documents\\sqlite projects\\TasksApp.db";
        }

        public SqliteConnection connect()
        {
            //if(conn.State == System.Data.ConnectionState.Closed)
            //{
                connectionString.DataSource = "Data Source=C:\\Users\\logzi\\Documents\\sqlite projects\\TasksApp.db";
                SqliteConnection conn = new SqliteConnection(connectionString.DataSource);
                conn.Open();
            //}

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