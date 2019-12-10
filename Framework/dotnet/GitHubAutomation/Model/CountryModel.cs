using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Model
{
    public class CountryModel
    {
        public string Country { get; set; }

        public CountryModel(string country)
        {
            this.Country = country;
        }
    }
}
