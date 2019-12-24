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
            return new CountryModel(TestDataReader.GetData("Country").Value,TestDataReader.GetData("CountryBelarus").Value, "","");
        }

        public static CountryModel ChosenCountryAndSelectCity()
        {
            return new CountryModel("","",TestDataReader.GetData("ChosenCountry").Value, TestDataReader.GetData("SelectCity").Value);
        }
    }
}
