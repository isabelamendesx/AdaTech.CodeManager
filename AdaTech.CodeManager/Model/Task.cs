using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public class Task
    {
        private string _name;
        private string? _description;
        private readonly int _taskID;
        private bool _isTechLeadAssigneed;
        private List<Developer>? _owners;
        private Status _status;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private Priority _priority;

        private static int _nextTaskID = 1;

        // - CONSTRUTOR
        public Task(string name, string? description = null, List<Developer>? owners = null, Status status = Status.BackLog, DateTime? startDate = null, DateTime? endDate = null, Priority priority = Priority.Low, bool isTechLeadAssigneed = false)
        {
            _name = name;
            _description = description;
            _owners = owners;
            _status = status;
            _startDate = startDate;
            _endDate = endDate;
            _priority = priority;
            _taskID = _nextTaskID++;
            _isTechLeadAssigneed = isTechLeadAssigneed;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        public int TaskID
        {
            get => _taskID;
        }
        public List<Developer> Owners
        {
            get => _owners;
            set => _owners = value;
        }
        public Status Status
        {
            get => _status;
            set => _status = value;
        }

        public DateTime? StartDate
        {
            get => _startDate;
        }

        public DateTime? EndDate
        {
            get => _endDate;
        }
    }
}
