using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public class Project
    {
        private List<Task> _tasks;
        private string _name;
        private string? _description;

        public Project() { }
        public List<Task> tasks { get => _tasks;
            set => _tasks = value; }

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }

        public int concludedTasks()
        {
            return _tasks.Where(task => task.Status == Status.DEPLOYED).Count();
        }

    }
}
