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
        private List<Task> _tasksToApprove;
        private string _name;
        private string? _description;
        private DateTime _startDate;
        private DateTime? _targetDate;


        public Project(string name, string? description, DateTime startDate, DateTime? targetDate) { 
            _name = name;
            _description = description;
            _startDate = startDate;
            _targetDate = targetDate;
            _tasks = new List<Task>();
            _tasksToApprove = new List<Task>();
        }

        #region Properties

        public List<Task> Tasks
        {
            get => _tasks;
            set => _tasks = value;
        }

        public List<Task> TasksToApprove
        {
            get => _tasksToApprove;
            set => _tasksToApprove = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string? Description
        {
            get => _description;
            set => _description = value;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public DateTime? TargetDate
        {
            get => _targetDate;
            set => _targetDate = value;
        }

        #endregion

        public List<Task>? GetTasksByStatus(Status desiredStatus)
        {
            if (_tasks == null)
            {
                return null;
            }

            return _tasks.Where(task => task.Status == desiredStatus).ToList();
        }

        public int GetDaysUntilTargetDate()
        {
            if (_targetDate.HasValue)
            {
                return _targetDate.Value.Subtract(DateTime.Now).Days;
            }

            return -1;
        }

        public double GetConcludedTasksPercent()
        {
            if(_tasks == null || _tasks.Count == 0)
            {
                return 0.00;
            }

            return ((double)_tasks.Count(task => task.Status == Status.Done) / _tasks.Count) * 100;
        }

        public void AddTask(Task task)
        {
            _tasks.Add(task);
            TeamData.SaveTeams();
        }

        public void RemoveTask(Task task)
        {
            _tasks.Remove(task);
            TeamData.SaveTeams();
        }
        public void AddTaskToApprove(Task task)
        {
            _tasksToApprove.Add(task);
            TeamData.SaveTeams();
        }

        public void RemoveTaskToApprove(Task task)
        {
            _tasksToApprove.Remove(task);
            TeamData.SaveTeams();
        }





    }
}
