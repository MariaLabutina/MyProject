using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json;

namespace ProjectManager
{
    class ListOfTask
    {
        List<Task> tasks = new List<Task>();

        public void AddATask(string nameTask, DateTime startDate, int duration)
        {
            tasks.Add(new Task(nameTask, startDate, duration));
        }

        public void ChangeTheTask(int index, string nameTask, DateTime startDate, int duration)
        {
            tasks[index] = new Task(nameTask, startDate, duration);
        }

        public void RemoveATask(int index)
        {
            tasks.RemoveAt(index);
        }

        public Task this [int index]
        {
            get { return tasks[index]; }
        }
        public int Count()
        {
            return tasks.Count;
        }

        public DateTime FirstDate()
        {
            DateTime firstdate = tasks[0].StartDate;
            foreach (Task task in tasks)
            {
                if (firstdate > task.StartDate) { firstdate = task.StartDate; }
            }
            return firstdate;
        }


        public DateTime LastDate()
        {
            DateTime lastdate = tasks[0].StartDate.AddDays(tasks[0].Duration);
            foreach (Task task in tasks)
            {
                if (lastdate < task.StartDate.AddDays(task.Duration)) { lastdate = task.StartDate.AddDays(task.Duration); }
            }
            return lastdate;
        }

    }
}
