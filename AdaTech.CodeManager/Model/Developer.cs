using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public class Developer : Employee
    {
        private Level _level;
        private MainSkill _mainSkill;

        public Developer(string username, string password, string name, Level level, MainSkill main)
            : base(username, password, name)
        {
            _level = level;
            _mainSkill = main;
        }

        public Level Level
        {
            get => _level;
            set => _level = value;
        }

        public MainSkill MainSkill
        {
            get => _mainSkill;
            set => _mainSkill = value;
        }


        public override string ToString()
        {
            string mainSkillString = _mainSkill == MainSkill.UI_UX ? "UI/UX" : _mainSkill.ToString();
            return Name + " - " + mainSkillString + " - " + Level.ToString();
        }

    }
}
