using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Model;
using Framework.Utils;

namespace Framework.Service
{
    public class CreatorCountryModel
    {
        public static CountryModel WithCountryProperties()
        {
            return new CountryModel(TestDataReader.GetData("Country"),TestDataReader.GetData("CountryBelarus"),"","");
        }

        public static CountryModel ChosenCountryAndSelectCity()
        {
            return new CountryModel("","",TestDataReader.GetData("ChosenCountry"), TestDataReader.GetData("SelectCity"));
        }
    }
}
