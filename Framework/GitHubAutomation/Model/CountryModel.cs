using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class CountryModel
    {
        private string Country { get; set; }
        private string CountryBelarus { get; set; }
        private string ChosenCountry { get; set; }
        private string SelectCity { get; set; }


        public CountryModel(string country, string countryBelarus, string chosenCountry, string selectCity)
        {
            this.Country = country;
            this.CountryBelarus = countryBelarus;
            this.ChosenCountry = chosenCountry;
            this.SelectCity = selectCity;
        }
    }
}
