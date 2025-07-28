using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProjectManager
{
    class Task
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public Task(string name, DateTime startDate, int duration)
        {
            Name = name;
            StartDate = startDate;
            Duration = duration;
        }

    }
}
