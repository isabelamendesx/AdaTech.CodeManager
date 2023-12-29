using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    public abstract class Employee : User
    {
        private string _name;
        private readonly int _empID;

        private static int _nextEmployeeID = 1;

        // - Construtores
        public Employee(string username, string password, string name)
            : base(username, password)
        {
            _name = name;
            _empID = _nextEmployeeID++;
        }

        // - Propriedades 
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        protected int EmpID
        {
            get => _empID;
        }

    }
}
