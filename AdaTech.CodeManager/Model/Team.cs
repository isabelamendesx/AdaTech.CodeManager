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
        
        public Team(string name, List<Guid> teamMembersID, Guid techLeadID) {
            _teamMembersID = teamMembersID;
            _projects = new List<Project>();
            _name = name;
            _techLeadID = techLeadID;
        }

        public Guid TechLeadID { get { return _techLeadID; } }

        public List<Guid> TeamMembersID { get {  return _teamMembersID; } }
        public List<Project> Projects { get {  return _projects; } }
        public string Name { get { return _name;} }

        //public void AddTeamMember(Developer developer) {  _teamMembers.Add(developer); }
        //public void RemoveTeamMember(Developer developer) { _teamMembers.Remove(developer); }

        public void AddProject(string projectName, string projectDescription, DateTime startDate, DateTime targetDate) 
        {  
            _projects.Add(new Project(projectName, projectDescription, startDate, targetDate));
        }

        public void RemoveProjectMember(Project project) { _projects.Add(project); }


    }
}
