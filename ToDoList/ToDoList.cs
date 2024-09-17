using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Reminders
    {
        private static int _lastId = 0;
        private static List<ToDo> remindersList = new List<ToDo>();

        public int Add(ToDo task)
        {
            task.SetId(++_lastId);
            remindersList.Add(task);
            return task.Id;
        }

        public void Remove(int id)
        {
            ToDo? task = remindersList.Find(x => x.Id == id);
            if(task != null)
                remindersList.Remove(task);
        }

        public void Complete(int id)
        {
            ToDo? task = remindersList.Find(x => x.Id == id);
            if(task != null)
                task.Completed = true;
        }

        public List<ToDo> List()
        {
            return remindersList;
        }

        public List<ToDo> List(string stringTask)
        {
            return remindersList.FindAll(r => r.Task.Contains(stringTask));
        }

        public List<ToDo> CompletedList(bool completed)
        {
            return remindersList.FindAll(r => r.Completed == completed);
        }

        public ToDo? Get(int idTask)
        {
            return remindersList.Find(x => x.Id == idTask);
        }
    }
}