using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AdaTech.CodeManager.Model
{
    public class Task
    {
        private string _name;
        private string? _description;
        private readonly int _taskID;
        private List<User>? _owners;
        private Status _status;
        private DateTime? _startDate;
        private DateTime? _endDate;


        private static int _nextTaskID = 1;

        // - CONSTRUTOR
        public Task(string name)
        {
            _name = name;
            _status = Status.BACKLOG;
            _taskID = _nextTaskID++;
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
        public List<User> Owners
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
