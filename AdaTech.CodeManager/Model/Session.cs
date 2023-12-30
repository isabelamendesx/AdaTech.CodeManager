using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.CodeManager.Model
{
    public sealed class Session
    {

        private static Session instance;
        private User currentUser;
        public static Session getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
        private Session() { }


        public bool UserIsLogged => currentUser != null;

        public void SetCurrentUser(User user)
        {
            if (UserIsLogged)
            {
                throw new InvalidOperationException("Já existe um usuário logado. Encerre a sessão atual para iniciar outra.");
            }

            currentUser = user;
        }

        public User GetCurrentUser()
        {
            if (!UserIsLogged)
            {
                throw new InvalidOperationException("Nenhum usuário está logado no momento.");
            }

            return currentUser;
        }

        public void EndSession()
        {
            currentUser = null;
        }
    }
}
