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
        public TechLead(string username, string password, Guid userID, string name)
      : base(username, password, userID, name)
        {
        }

        //public void CreateTeam(string teamName, List<Developer> teamMembers)
        //{
        //    var team = new Team(teamName, teamMembers);
        //    _teams.Add(team);
        //    UserData.SaveUsers();
        //}

        //public List<Team> GetTeams()
        //{
        //    return _teams;
        //}

        public override string ToString()
        {
            return Name + " - " + "TechLead";
        }



    }
}
