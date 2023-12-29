using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    public class TechLead : Employee
    {
        private List<Team> _teams;

        public TechLead(string username, string password, string name)
      : base(username, password, name)
        {
            _teams = new List<Team>();
        }


    }
}
