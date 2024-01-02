using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
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
        private DateTime _startDate;
        private DateTime _targetDate;


        public Project(string name, string description, DateTime startDate, DateTime targetDate) { 
            _name = name;
            _description = description;
            _startDate = startDate;
            _targetDate = targetDate;
            _tasks = new List<Task>();
        }

        public List<Task>? getBackLogTasks()
        {
           if(_tasks == null)
            {
                return null;
            }
            return _tasks.Where(task => task.Status == Status.BackLog).ToList();
        }

        public int DaysUntilTargetDate()
        {
            return _targetDate.Subtract(DateTime.Now).Days;
        }

        public double concludedTasksPercent()
        {
            if(_tasks == null)
            {
                return 0.00;
            }

            return ((double)_tasks.Count(task => task.Status == Status.Done) / _tasks.Count) * 100;
        }

        public void AddTask(Task task)
        {
            _tasks.Add(task);
            UserData.SaveUsers();
        }


        public List<Task> Tasks { get => _tasks;
            set => _tasks = value; }

        public string Name 
        {
            get => _name; 
            set => _name = value; 
        }
        public string Description 
        { get => _description; 
            set => _description = value;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public DateTime TargetDate
        {
            get => _targetDate;
            set => _targetDate = value;
        }



    }
}
