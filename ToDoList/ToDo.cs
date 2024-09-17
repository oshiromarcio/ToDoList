using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ToDo
    {
        public int Id { get; private set; } = 0;
        public required string Task { get; set; }
        public DateTime Date { get; set; }
        public bool Priority { get; set; }
        public bool Completed { get; set; }

        public bool SetId(int id)
        {
            if(this.Id != 0)
                return false;
            this.Id = id;
            return true;
        }
    }
}