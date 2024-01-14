using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    public static class TeamData
    {

        private static List<Team> _teams;

        private const string DATA_DIRECTORY = "../../../Data";
        private const string TEAMS_FILE_NAME = "Teams.json";
        private static readonly string TEAMS_FILE_PATH = Path.Combine(DATA_DIRECTORY, TEAMS_FILE_NAME);

        static TeamData()
        {
            _teams = new List<Team>();
            DataHandler.LoadData(ref _teams, TEAMS_FILE_PATH);
        }

        public static List<Team> Teams { get { return _teams; } }

        public static void AddTeam(Team team)
        {
            _teams.Add(team);
            SaveTeams();
        }

        public static void RemoveTeam(Team team)
        {
            _teams.Remove(team);
            SaveTeams();
        }

        public static void RemoveProject(Project project)
        {
            _teams.Find(team => team.Projects.Contains(project)).Projects.Remove(project);
            TeamData.SaveTeams();
        }

        public static List<Team>? FindTeamsByTechLead(TechLead techLead)
        {
            return _teams.FindAll(team => team.TechLeadID.Equals(techLead.UserID));
        }

        public static Team? FindTeamByDeveloper(Developer dev)
        {
            return _teams.Find(team => team.TeamMembersID.Contains(dev.UserID));

        }

        public static List<Task>? FindTasksToApproveByTechLead
            (TechLead techLead)
        {
            var teams = FindTeamsByTechLead(techLead);

            return teams.SelectMany(team => team.Projects).SelectMany(project => project.TasksToApprove).ToList();
        }

        public static Project FindProjectByTask(Model.Task task, TechLead techLead)
        {
            var teams = FindTeamsByTechLead(techLead);

            var project = teams.SelectMany(team => team.Projects)
                   .FirstOrDefault(proj => proj.Tasks.Contains(task) || proj.TasksToApprove.Contains(task));

            return project;
        }

        public static Project FindProjectByTask(Model.Task task, Developer dev)
        {
            var team = FindTeamByDeveloper(dev);

            var project = team.Projects.FirstOrDefault(proj => proj.Tasks.Contains(task) || proj.TasksToApprove.Contains(task));

            return project;
        }

        public static void SaveTeams()
        {
            DataHandler.SaveData(_teams, TEAMS_FILE_PATH);
        }




    }
}
