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

        public static List<Team>? FindTeamsByTechLead(TechLead techLead)
        {
            return _teams.FindAll(team => team.TechLeadID.Equals(techLead.UserID));
        }

        public static void SaveTeams()
        {
            DataHandler.SaveData(_teams, TEAMS_FILE_PATH);
        }


    }
}
