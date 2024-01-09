using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace AdaTech.CodeManager.Model
{
    [JsonObject]
    public abstract class User
    {
        private string _username, _password;
        private Guid _userID;
        private bool _admin;

        // - Construtores
        public User(string username, string password, Guid userId)
        {
            _username = username;
            _password = password;
            _userID = userId;
            _admin = false;
        }


        // - Propriedades 
        public Guid UserID
        {
            get => _userID;
        }
        public string Username
        {
            get => _username;
            protected set => _username = value;
        }
        public string Password
        {
            get => _password;
            set => _password = value;
        }
        public bool Admin
        {
            get => _admin;
        }


        // - Métodos
        internal bool Log(string username, string senha)
        {
            return Username.Equals(username) && CheckPassword(senha);
        }

        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool CheckPassword(string enteredPassword)
        {
            string cryptEnteredPassword = EncryptPassword(enteredPassword);
            string password = EncryptPassword(_password);
            return _password.Equals(cryptEnteredPassword);
        }

        protected void ChangePassword(string currentPassword, string newPassword)
        {
            if (!CheckPassword(currentPassword)) throw new InvalidOperationException("Senha fornecida incorreta.");

            _password = EncryptPassword(newPassword);
        }

        // Sobrescrever o método Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            User otherUser = (User)obj;
            return _userID.Equals(otherUser._userID);
        }

        // Sobrescrever o método GetHashCode
        public override int GetHashCode()
        {
            return _userID.GetHashCode();
        }
    }
}
