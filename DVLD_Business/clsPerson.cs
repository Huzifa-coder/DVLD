using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode {AddNew, Update}
        public enMode mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get {  return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor {  get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        private string _ImagePath;
        public string ImagePath {
            get { return _ImagePath; }
            set { _ImagePath = value; } 
        }
        
        public int CountryNationalID { get; set; }
        public clsCountry ContryInfo { get; set; }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gendor = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            ImagePath = string.Empty;
            CountryNationalID = -1;
            ContryInfo = clsCountry.Find(CountryNationalID);

            mode = enMode.AddNew;
        }

        private clsPerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
            DateTime dateOfBirth, byte gendor, string address, string phone, string email, string imagePath, int countryNationalID) 
        {
            this.mode = enMode.Update;

            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            ImagePath = imagePath;

            CountryNationalID = countryNationalID;
            ContryInfo = clsCountry.Find(countryNationalID);
        }

        public static clsPerson Find(int PersonID)
        {
            
            int countryNationalID = -1;
            string nationalNo = string.Empty, firstName = string.Empty, secondName = string.Empty, thirdName = string.Empty, lastName = string.Empty, address = string.Empty, phone = string.Empty, email = string.Empty, imagePath = string.Empty;
            DateTime dateOfBirth = DateTime.MinValue;
            byte gendor = 0;

            bool Found = clsPersonData.GetPersonInfoByID(PersonID, ref nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gendor, ref address, ref phone, ref email, ref imagePath, ref countryNationalID);

            if (Found)
            {
                return new clsPerson(PersonID, nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth, gendor, address, phone, email, imagePath, countryNationalID);
            }
            else
            {
                return null;
            }

        }

        public static clsPerson Find(string NationaNo)
        {

            int personID = -1,countryNationalID = -1;
            string firstName = string.Empty, secondName = string.Empty, thirdName = string.Empty, lastName = string.Empty, address = string.Empty, phone = string.Empty, email = string.Empty, imagePath = string.Empty;
            DateTime dateOfBirth = DateTime.MinValue;
            byte gendor = 0;

            bool Found = clsPersonData.GetPersonInfoByNationalNo(NationaNo, ref personID, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gendor, ref address, ref phone, ref email, ref imagePath, ref countryNationalID);

            if (Found)
            {
                return new clsPerson(personID, NationaNo, firstName, secondName, thirdName, lastName, dateOfBirth, gendor, address, phone, email, imagePath, countryNationalID);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, FirstName, SecondName, ThirdName,
                LastName, DateOfBirth, Gendor, Address, Phone, Email, ImagePath, CountryNationalID); 

            return PersonID != -1;
        }

        private bool _UpdatePerson()
        {

            return clsPersonData.UpdatePersonInfo(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                DateOfBirth, Gendor, Address, Phone, Email, ImagePath, CountryNationalID);
        }

        public bool save()
        {
            switch(mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        mode = enMode.Update;
                        return true;

                    }else {

                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();
            }

            return false;
        }

        static public DataTable GetAllPeople()
        {

            return clsPersonData.GetAllPeople();
        }

        static public bool DeletePerson(int PersonID) { 

            return clsPersonData.DeletePerson(PersonID);
        }

        static public bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        static public bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

    }
}
