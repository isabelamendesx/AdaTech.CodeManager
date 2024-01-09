using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public abstract class Employee : User
    {
        private string _name;

        // - Construtores
        public Employee(string username, string password, Guid userID, string name)
            : base(username, password, userID)
        {
            _name = name;
        }

        // - Propriedades 
        public string Name
        {
            get => _name;
            set => _name = value;
        }

    }
}
