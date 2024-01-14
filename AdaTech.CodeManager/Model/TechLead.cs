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

        public override string ToString()
        {
            return Name + " - " + "TechLead";
        }



    }
}
