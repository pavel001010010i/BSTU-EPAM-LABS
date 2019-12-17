using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class User
    {
        private string Login { get; set; }
        private string Password { get; set; }
        private string NotCorrectPassword { get; set; }
        private string UserName { get; set; }
        private string NewEmail { get; set; }

        public User(string login, string password, string userName, string newEmail)
        {
            this.Login = login;
            this.Password = password;
            this.UserName = userName;
            this.NewEmail = newEmail;
        }
        public User(string notCorrectPassword)
        {
            this.NotCorrectPassword = notCorrectPassword;
        }
    }
}
