using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubAutomation.Model;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Service
{
    class CreatorCountryModel
    {
        public static CountryModel WithCountryProperties()
        {
            return new CountryModel(TestDataReader.GetData("Country"));
        }
    }
}
