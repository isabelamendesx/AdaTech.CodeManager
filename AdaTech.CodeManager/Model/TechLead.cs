using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public class TechLead : Employee
    {
        public List<Team> _teams;

        public TechLead(string username, string password, string name)
      : base(username, password, name)
        {
            _teams = new List<Team>();
        }

        public void CreateTeam(string teamName, List<Developer> teamMembers)
        {
            var team = new Team(teamName, teamMembers);
            _teams.Add(team);
            UserData.SaveUsers();
        }

        public List<Team> GetTeams()
        {
            return _teams;
        }


    }
}
