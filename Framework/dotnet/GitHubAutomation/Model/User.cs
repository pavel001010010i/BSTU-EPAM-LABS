using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Model
{
    public class User
    {
        private string Login { get; set; }
        private string Password { get; set; }

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
