using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace project
{
    public class TaskService
    {
        Connection connection = new Connection();
        SqliteCommand cmd = new SqliteCommand();
        public string tryMessage;

        public string createTask(Task task)
        {
            cmd.CommandText = $"insert into tasks (title, `desc`, `date`) values (@title, @desc, @date)";

            cmd.Parameters.AddWithValue("@title", task.title);
            cmd.Parameters.AddWithValue("@desc", task.desc);
            cmd.Parameters.AddWithValue("@date", task.date);
          
            try
            {               
                cmd.Connection = connection.connect();               
                cmd.ExecuteNonQuery();
                connection.disconnect();

                Console.ForegroundColor = ConsoleColor.Green;
                tryMessage = "Lembrete Criado!";
            }
            catch (SqliteException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                tryMessage = "Erro ao criar o lembrete...";                
            }

            return tryMessage;
        }

        public string deleteTask(Int64 id)
        {
            string tryMessage;

            cmd.CommandText = "delete from tasks\n" + "where id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.Connection = connection.connect();
                cmd.ExecuteNonQuery();
                connection.disconnect();

                Console.ForegroundColor = ConsoleColor.Green;
                tryMessage = "Lembrete apagado!";               
            }
            catch (SqliteException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                tryMessage = "Erro ao apagar o lembrete...";                
            }

            return tryMessage;
        }

        public void getTask(int id)
        {
           
        }
        
        public List<Task> getAllTasks()
        {
            List<Task> tasks = new List<Task>();           
            cmd.CommandText = "select * from tasks";

            cmd.Connection = connection.connect();
            SqliteDataReader dtReader = cmd.ExecuteReader();           

            while (dtReader.Read())
            {
                Int64 id = (Int64)dtReader["id"];
                string title = (string)dtReader["title"];
                string desc = (string)dtReader["desc"];
                DateTime date = DateTime.Now;

                int cnv = Convert.ToInt32(id);

                Task task = new Task(cnv, title, desc, date);
                tasks.Add(task);                
            }           
 
            dtReader.Close();
            connection.disconnect();

            return tasks;
        }
    }
}