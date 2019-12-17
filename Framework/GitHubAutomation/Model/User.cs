using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string NotCorrectPassword { get; set; }
        public string UserName { get; set; }
        public string NewEmail { get; set; }

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
