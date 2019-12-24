using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Model;
using Framework.Utils;

namespace Framework.Service
{
    public class CreatorLogIn
    {
        public static User WithAllProperties()
        {
            return new User(TestDataReader.GetData("Login").Value, TestDataReader.GetData("Password").Value, "","");
        }

        public static User ConclusionWrongPassword()
        {
            return new User(TestDataReader.GetData("NotCorrectPassword").Value);
        }

        public static User ConclusionNameAndNewAccount()
        {
            return new User("","",TestDataReader.GetData("UserName").Value, TestDataReader.GetData("NewEmail").Value);
        }

    }
}
