using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class CountryModel
    {
        public string Country { get; set; }
        public string CountryBelarus { get; set; }
        public string ChosenCountry { get; set; }
        public string SelectCity { get; set; }


        public CountryModel(string country, string countryBelarus, string chosenCountry, string selectCity)
        {
            this.Country = country;
            this.CountryBelarus = countryBelarus;
            this.ChosenCountry = chosenCountry;
            this.SelectCity = selectCity;
        }
    }
}
