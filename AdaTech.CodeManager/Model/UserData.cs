using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdaTech.CodeManager.Model
{
    public class UserData
    {
        private static List<User> _users;
        private const string DATA_DIRECTORY = "../../../Data";
        private const string USER_FILE_NAME = "Users.json";
        private static readonly string USER_FILE_PATH = Path.Combine(DATA_DIRECTORY, USER_FILE_NAME);

        static UserData()
        {
            LoadUsers();
        }
        public static List<User> Users { get { return _users; } }

        public static void AddUser(User user)
        {
            _users.Add(user);
            SaveUsers();
        }

        public static User? SelectUser(string username)
        {
            return _users.Find(user => user.Username.Equals(username));
        }

        public static void PrintUsers()
        {
            foreach (var user in _users)
            {
                Console.WriteLine(user.Username);
            }
        }

        private static void LoadUsers()
        {
            if (File.Exists(USER_FILE_PATH))
            {
                Console.WriteLine("Loading users from file...");

                string json = File.ReadAllText(USER_FILE_PATH);

                // Configurar o JsonSerializerSettings para lidar com a serialização/deserialização de tipos derivados
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                try
                {
                    _users = JsonConvert.DeserializeObject<List<User>>(json, settings);
                    Console.WriteLine($"Users loaded successfully. Count: {_users.Count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading users: {ex.Message}");
                }
            }
        }


        public static void SaveUsers()
        {
            EncryptPasswords();
            Console.WriteLine("Saving users to file...");

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented  // Configuração para indentação
            };

            try
            {
                string json = JsonConvert.SerializeObject(_users, settings);
                File.WriteAllText(USER_FILE_PATH, json);
                Console.WriteLine("Users saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving users: {ex.Message}");
            }
        }


        private static void EncryptPasswords()
        {
            foreach (var user in _users)
            {
                user.Password = User.EncryptPassword(user.Password);
            }
        }
    }
}
