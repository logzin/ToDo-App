using System;
using System.Collections.Generic;

namespace project
{
    public class Menu
    {
        TaskService taskService = new TaskService();
        List<Task> tasks;      
        String[] head = { "<<ACCESS TASKS>>", "<<CREATE TASK>>", "<<EXIT>>" };
        int selectedMenuIndex;
        int selectedIndex = 1;

        public void displayMenu()
        {
            text(1);

            for (int i = 0; i < head.Length; i++)
            {
                string currentHead = head[i];
                if (i == selectedMenuIndex)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {                   
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(currentHead);
            }
            Console.ResetColor();
        }


        public int runHead()
        {
            
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();

                displayMenu();

                ConsoleKeyInfo keyinfo = Console.ReadKey();
                keyPressed = keyinfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedMenuIndex--;                   

                    if(selectedMenuIndex <= -1)
                    {
                        selectedMenuIndex = head.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedMenuIndex++;

                    if (selectedMenuIndex == head.Length)
                    {
                        selectedMenuIndex = 0;
                    }                    
                }

            } while (keyPressed != ConsoleKey.Enter);

            switch (selectedMenuIndex)
            {
                case 0:
                    runDisplayAllTasks();
                    break;
                case 1:
                    runCreateTask();
                    break;
                case 2:
                    exit();
                    break;
            }

            return selectedMenuIndex;
        }

        public void runDisplayAllTasks()
        {
            ConsoleKey keyPressed;
            int i;
            i = selectedIndex;
            do
            {
                Console.Clear();

                displayAllTasks();               

                ConsoleKeyInfo keyinfo = Console.ReadKey();
                keyPressed = keyinfo.Key;
        

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;

                    if (selectedIndex == 0)
                    {
                        selectedIndex = tasks.Count;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;

                    if (selectedIndex > tasks.Count )
                    {
                        selectedIndex = 1;                       
                    }
                }
                
            } while (keyPressed != ConsoleKey.Enter);

            try
            {
                runTaskDrop(tasks[i].id);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("There's nothing to access :(");
                Console.WriteLine();
                exit();
            }
        }

        public void displayAllTasks()
        {
            text(2);

            tasks = taskService.getAllTasks();

            int i = 0;
            foreach (Task task in tasks)
            {
                i++;
                string prefix;
                string deleteFb;

                if (i == selectedIndex)
                {
                    prefix = "->";
                    deleteFb = "[DELETE]";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = "";
                    deleteFb = "";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix} ||{task.title}||{task.desc}|| {deleteFb}");
            }
            Console.ResetColor();
        }
        
        public void runCreateTask()
        {
            int id = 0;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Type your task title");
            Console.ResetColor();

            String title = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Type your task description:");
            Console.ResetColor();
            String desc = Console.ReadLine();

            Console.WriteLine();
            DateTime date = DateTime.Now;

            Task task = new Task(id, title, desc, date);

            taskService.createTask(task);
            Console.WriteLine(taskService.tryMessage);
            Console.ForegroundColor = ConsoleColor.Blue;

            exit();           
        }

        public void runTaskDrop(int id)
        {          
            Console.WriteLine(taskService.deleteTask(id));         
        }

        public void exit(){
            Console.WriteLine("\nPress any key to exit . . .");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void text(int i)
        {
            string title = @"
 _____      ______        _     _     _   
|_   _|     |  _  \      | |   (_)   | |  
  | | ___   | | | |___   | |    _ ___| |_ 
  | |/ _ \  | | | / _ \  | |   | / __| __|
  | | (_) | | |/ / (_) | | |___| \__ \ |_ 
  \_/\___/  |___/ \___/  \_____/_|___/\__|

This is the V2.0 version of ToDoList. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option.)
";
            string tasks = @"
 _____         _            
|_   _|       | |         _ 
  | | __ _ ___| | _____  (_)
  | |/ _` / __| |/ / __|    
  | | (_| \__ \   <\__ \  _ 
  \_/\__,_|___/_|\_\___/ (_)
                            
                            
";
            switch (i)
            {
                case 1:
                    Console.WriteLine(title);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine(tasks);
                    Console.WriteLine();
                    break;
            }
        }
    }
}