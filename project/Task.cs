using System;

namespace project
{
    public class Task
    {
         public int id;
        public String title;
        public String desc;
        public DateTime date;

        public Task(int id, string title, String desc, DateTime date)
        {
            this.id = id;
            this.title = title;
            this.desc = desc;
            this.date = date;
        }
    }
}