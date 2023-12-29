using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    internal class Developer : Employee
    {
        private Level _level;
        private Team _team;

        public Developer(string username, string password, string name, Level level)
            : base(username, password, name)
        {
            level = _level;
        }

        public Level Level
        {
            get => _level;
            set => _level = value;
        }

        public Team Team
        {
            get => _team;
            set => _team = value;
        }


    }
}
