using DVLD_Business;
using DVLD_SE.Global;
using DVLD_SE.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_SE.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
       
        public event DataBackEventHandler DataBack;

        enum enGendor { Male, Female}
        enum enMode { AddPerson, UpdatePerson}

        private enMode _Mode = enMode.AddPerson;

        private int _PersonID = -1;
        private clsPerson _Person = new clsPerson();

        public frmAddUpdatePerson()
        {
            InitializeComponent();

            _Mode = enMode.AddPerson;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.UpdatePerson;
            _PersonID = PersonID;
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.UpdatePerson)
                _LoadData();
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesComboBox();

            if (_Mode == enMode.AddPerson)
                lbTitle.Text = "Add New Person";
            else
                lbTitle.Text = "Update Person";

            lnRemove.Visible = false;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            tbFirstName.Text = string.Empty;
            tbSecandName.Text = string.Empty;
            tbThirdName.Text = string.Empty;
            tbLastName.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbAddress.Text = string.Empty;
            tbNationalNo.Text = string.Empty;
            tbPhone.Text = string.Empty;

        }

        private void _FillCountriesComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();

            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"]);
            }

        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person With " + _PersonID + " ID", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();   
                return;
            }

            lbPersonID.Text = _PersonID.ToString();


            tbFirstName.Text = _Person.FirstName;
            tbSecandName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;

            tbNationalNo.Text = _Person.NationalNo;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            tbAddress.Text = _Person.Address;

            dtpDateOfBirth.Value = _Person.DateOfBirth;

            cbCountries.SelectedIndex = _Person.CountryNationalID;
             
            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFamale.Checked = true;
            
            if(_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            lnRemove.Visible = (_Person.ImagePath != "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                lnRemove.Visible = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) {

                MessageBox.Show("Some fileds are not vaild", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!HandlePersonImage())
                return;

            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecandName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.Email = tbEmail.Text.Trim();
            _Person.Phone = tbPhone.Text.Trim();
            _Person.Address = tbAddress.Text.Trim();

            if (rbMale.Checked)
                _Person.Gendor = (Byte)enGendor.Male;
            else
                _Person.Gendor = (byte) enGendor.Female;

            _Person.DateOfBirth = dtpDateOfBirth.Value;

            _Person.CountryNationalID = cbCountries.SelectedIndex;

            if(pbPersonImage.ImageLocation != null)
            {
                _Person.ImagePath = pbPersonImage.ImageLocation;
            }
            else
            {
                _Person.ImagePath = string.Empty;
            }

            if (_Person.save())
            {
                lbPersonID.Text = _Person.PersonID.ToString();

                _Mode = enMode.UpdatePerson;
                
                lbTitle.Text = "Update Person";

                MessageBox.Show("Person Inof Saved Successfully", "Complate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Error", "Person Info faild", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private bool HandlePersonImage()
        {
            if(_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);

                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }

                if (pbPersonImage.ImageLocation != null)
                {
                    string SourseImageFile = pbPersonImage.ImageLocation.ToString();
                    if(clsUtils.CopyImageToProjectImagesFolder(ref SourseImageFile))
                    {
                        pbPersonImage.ImageLocation = SourseImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Copying Image failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
  
            }
            
                         
            return true;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This filed is Empty.");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (string.IsNullOrEmpty(t.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(t, "This filed is Empty.");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(t, null);
            }

            if (!clsValidating.ValidateEmail(tbEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(t, "Enter a Vaild Email");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(t, null);
            }

        }

        private void lnRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            lnRemove.Visible = false;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
            {
            TextBox t = (TextBox)sender;

            if (string.IsNullOrEmpty(t.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(t, "This filed is Empty.");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(t, null);
            }

            if(clsPerson.Find(t.Text.Trim()) == null || _Mode == enMode.UpdatePerson)
            {
                e.Cancel = false;
                errorProvider1.SetError(t, null);
            }
            else
            {
                errorProvider1.SetError(t, "This National Number is Used Choce Anthor One");
                e.Cancel = true;
            }
        }
    }
}
