using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountry
    {

        int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry() {
            CountryID = 0;
            CountryName = string.Empty;
        }

        private clsCountry(int countryID, string countryName) { 
            
            CountryID = countryID;
            CountryName = countryName;

        }

        public static clsCountry Find(int countryID) {

            string countryName = string.Empty;

            if(clsCountryData.GetCountryInfoByID(countryID, ref countryName))
            {
                return new clsCountry(countryID, countryName);
            }

            return null;
        }

        public static clsCountry Find(string countryName)
        {

            int countryID = -1;

            if (clsCountryData.GetCountryInfoByName(countryName, ref countryID))
            {
                return new clsCountry(countryID, countryName);
            }

            return null;
        }

        public static DataTable GetAllCountries() { 

            return clsCountryData.GetAllCountries();
        }
    }
}
