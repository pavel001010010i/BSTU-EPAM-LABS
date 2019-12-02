using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubAutomation.Model;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Service
{
    class CreatorLogIn
    {
        public static User WithAllProperties()
        {
            return new User(TestDataReader.GetData("Login"), TestDataReader.GetData("Password"));
        }
    }
}
