using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public class UserData
    {
        private static List<User> _users;


        private const string DATA_DIRECTORY = "../../../Data";
        private const string USER_FILE_NAME = "Users.json";
        private static readonly string USER_FILE_PATH = Path.Combine(DATA_DIRECTORY, USER_FILE_NAME);

        static UserData()
        {
            _users = new List<User>();
           DataHandler.LoadData(ref _users, USER_FILE_PATH);
        }
        public static List<User> Users { get { return _users; } }

        public static void AddUser(User user)
        {
            EncryptPassword(user);
            _users.Add(user);
            DataHandler.SaveData(_users, USER_FILE_PATH);
        }

        public static List <Developer> GetDevelopers(){
            return _users.OfType<Developer>().ToList();  
        }

        public static List<TechLead> GetTechLeads()
        {
            return _users.OfType<TechLead>().ToList();
        }

        public static User? SelectUser(string username)
        {
            User? selectedUser = _users.Find(user => user.Username.Equals(username));
            return selectedUser;
        }

        public static User? SelectUser(User userToFind)
        {
            User? selectedUser = _users.Find(user => user.Equals(userToFind));
            return selectedUser;
        }

        public static User? SelectUser(Guid idToFind)
        {
            User? selectedUser = _users.Find(user => user.UserID.Equals(idToFind));
            return selectedUser;
        }

        private static void EncryptPassword(User user)
        {
                user.Password = User.EncryptPassword(user.Password);
        }
    }
}
