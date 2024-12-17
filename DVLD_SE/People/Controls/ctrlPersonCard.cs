using DVLD_Business;
using DVLD_SE.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_SE.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID {

            get { return _PersonID; } 

        }

        public clsPerson SelectedPersonInf { 

            get { return _Person; }
        
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        
        private void _FillPersonInfo()
        {


            if (_Person == null )
            {
                MessageBox.Show("There Are Not Any Person With : " + _PersonID + " ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PersonID = _Person.PersonID;

            lbPersonID.Text = _Person.PersonID.ToString();
            lbPersonName.Text = _Person.FullName;
            lbNationalNo.Text = _Person.NationalNo;
            lbGendor.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            lbEmail.Text = _Person.Email;
            lbPhone.Text = _Person.Phone;
            lbAddress.Text = _Person.Address;
            lbCountry.Text = _Person.ContryInfo.CountryName;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            _LoadPersonImage();
            
            lnlEditPersonInfo.Visible = true;
        }

        private void _LoadPersonImage()
        {
            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                {
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                }
                else
                {
                    MessageBox.Show("There Is NO Image In This Location : " + _Person.ImagePath);
                }
            }
            else
            {
                pbPersonImage.Image = (_Person.Gendor == 0) ? Resources.Male_512 : Resources.Female_512;
            }

        }

        private void _ResetControlValues()
        {
            lbPersonID.Text = "N/A";
            lbPersonName.Text = "N/A";
            lbNationalNo.Text = "N/A";
            lbGendor.Text = "N/A";
            lbEmail.Text = "N/A";
            lbPhone.Text = "N/A";
            lbAddress.Text = "N/A";
            lbCountry.Text = "N/A";
            lbDateOfBirth.Text = "N/A";

            lnlEditPersonInfo.Visible = false;

        }

        private void lnlEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            _Person = clsPerson.Find(_PersonID);
            _FillPersonInfo();
        }

        public void LoadPersonInfo(int PersonID)
        {

            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                _ResetControlValues();
                MessageBox.Show("There is No PersonID With : " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNO)
        {
            _Person = clsPerson.Find(NationalNO);

            if (_Person == null)
            {
                _ResetControlValues();
                MessageBox.Show("There is No NationalNO With : " + NationalNO, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lbPersonID.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbPersonName.Text = "[????]";
            lbGendor.Text = "[????]";
            lbEmail.Text = "[????]";
            lbPhone.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbCountry.Text = "[????]";
            lbAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;

        }

    }

}
