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
        private List<Developer> _teamMembers;
        private List<Project>? _projects;
        
        public Team(string name, List<Developer> teamMembers) {
            _teamMembers = teamMembers;
            _projects = new List<Project>();
            _name = name;
        }

        public List<Developer> TeamMembers { get {  return _teamMembers; } }
        public List<Project> Projects { get {  return _projects; } }
        public string Name { get { return _name;} }

        public void AddTeamMember(Developer employee) {  _teamMembers.Add(employee); }
        public void RemoveTeamMember(Developer employee) { _teamMembers.Remove(employee); }

        public void AddProjectMember(Project project) {  _projects.Add(project); }
        public void RemoveProjectMember(Project project) { _projects.Add(project); }


    }
}
