using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public class Team
    {
        private string _name;
        private Guid _techLeadID;
        private List<Guid> _teamMembersID;
        private List<Project>? _projects;

        public Team(string name, List<Guid> teamMembersID, Guid techLeadID)
        {
            _teamMembersID = teamMembersID;
            _projects = new List<Project>();
            _name = name;
            _techLeadID = techLeadID;
        }

        #region Properties


        public Guid TechLeadID { get { return _techLeadID; } }
        public List<Guid> TeamMembersID
        {
            get { return _teamMembersID; }
            set { _teamMembersID = value; }
        }

        public List<Project> Projects
        {
            get { return _projects; }
            set { _projects = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        public void AddProject(string projectName, string? projectDescription, DateTime startDate, DateTime? targetDate)
        {
            _projects.Add(new Project(projectName, projectDescription, startDate, targetDate));
        }


        public List<Developer> GetTeamMembers()
        {
            var membersName = new List<Developer>();

            foreach (var id in _teamMembersID)
            {
                membersName.Add((Developer)UserData.SelectUser(id));
            }

            return membersName;
        }

        public int CountInProgressTasks()
        {
            return _projects.SelectMany(project => project.Tasks).Sum(task => task.Status == Status.Doing ? 1 : 0);
        }

        public int CountDelayedTasks()
        {
            DateTime today = DateTime.Now;
            return _projects.SelectMany(project => project.Tasks)
                    .Where(task => task.Status != Status.Done)
                    .Count(task => task.EndDate != null && task.EndDate < today);
        }

        public int CountDroppedTasks()
        {
            DateTime today = DateTime.Now;
            return  _projects.SelectMany(project => project.Tasks).Count(task => task.EndDate != null && (today - task.EndDate).TotalDays > 10);
        }

        public int CountToReviewTasks()
        {
            return _projects.SelectMany(project => project.Tasks).Count(task => task.Status == Status.Review);
        }

        public int CountAllTasks()
        {
            return _projects.SelectMany(project => project.Tasks).Count();
        }

        public int CountCompletedTasks()
        {
            return _projects.SelectMany(project => project.Tasks).Count(task => task.Status == Status.Done);
        }

        public List<Model.Task> GetInProgressTasks()
        {
            return _projects.SelectMany(project => project.Tasks)
                            .Where(task => task.Status == Status.Doing)
                            .ToList();
        }

        public List<Model.Task> GetDelayedTasks()
        {
            DateTime today = DateTime.Now;
            return _projects.SelectMany(project => project.Tasks)
                            .Where(task => task.Status != Status.Done && task.EndDate != null && task.EndDate < today)
                            .ToList();
        }

        public List<Model.Task> GetDroppedTasks()
        {
            DateTime today = DateTime.Now;
            return _projects.SelectMany(project => project.Tasks)
                            .Where(task => task.EndDate != null && (today - task.EndDate).TotalDays > 10)
                            .ToList();
        }

        public List<Model.Task> GetToReviewTasks()
        {
            return _projects.SelectMany(project => project.Tasks)
                            .Where(task => task.Status == Status.Review)
                            .ToList();
        }

        public List<Model.Task> GetAllTasks()
        {
            return _projects.SelectMany(project => project.Tasks)
                            .ToList();
        }

        public List<Model.Task> GetCompletedTasks()
        {
            return _projects.SelectMany(project => project.Tasks)
                            .Where(task => task.Status == Status.Done)
                            .ToList();
        }
    }
    }
