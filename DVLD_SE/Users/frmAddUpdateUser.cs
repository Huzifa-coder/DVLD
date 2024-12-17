using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_SE.Users
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { Add, Update}
        enMode _Mode = enMode.Add;

        private int _UserID;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if(_Mode == enMode.Add)
            {
                lbTitle.Text = "Add New User";
                this.Text = lbTitle.Text;

                _User = new clsUser();
                tpUserInfo.Enabled = false;

                ctrlPersonFilterCard1.FilterFocus();
            }
            else
            {
                lbTitle.Text = "Upate User Info";
                this.Text = lbTitle.Text;

                tpUserInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            tbUserName.Text = "";
            tbPassword.Text = "";
            tbConfrimPassword.Text = "";
            cbActive.Checked = true;
        }

        private void _LoadData()
        {
            _User = clsUser.FindByUserID( _UserID );
            ctrlPersonFilterCard1.FilterEndable = false;

            if (_User == null) {

                MessageBox.Show("They are no User with [" + _UserID.ToString() + "]");
                this.Close(); 
            }

            ctrlPersonFilterCard1.LoadPersonInfo( _User.PersonID );
            lbUserID.Text = _UserID.ToString();
            tbUserName.Text = _User.UserName;
            tbPassword.Text = _User.Password;
            tbConfrimPassword.Text = _User.Password;
            cbActive.Checked = _User.IsActive;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds is empty, Pleace complate your form...", "Failed");
                return;
            }

            _User.PersonID = ctrlPersonFilterCard1.PersonID;
            _User.UserName = tbUserName.Text.Trim();
            _User.Password = tbPassword.Text.Trim();
            _User.IsActive = cbActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("User Info Is  Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbUserID.Text = _User.UserID.ToString();

                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Error : User Is Not Saved Successfully.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                tpUserInfo.Enabled = true;
                tcLoginInfo.SelectTab(1);
                btnSave.Enabled = true;
                return;
            }

            if (ctrlPersonFilterCard1.SelectedPerson != null)
            {

                if (clsUser.isUserExistForPersonID(ctrlPersonFilterCard1.PersonID))
                {
                    MessageBox.Show("This Person Has a User Already Choice Anther Person.", "Exist");
                    ctrlPersonFilterCard1.FilterFocus();
                    return;
                }
                else
                {
                    tpUserInfo.Enabled = true;
                    tcLoginInfo.SelectTab(1);
                    btnSave.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("Select Person First", "Wrong");
                ctrlPersonFilterCard1.FilterFocus();
            }

        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if(_Mode == enMode.Update)
                _LoadData();

        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(tbUserName.Text == "")
            {
                e.Cancel = true;
                tbUserName.Focus();
                errorProvider1.SetError(tbUserName, "Pleace enter a user name.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUserName, "");
            }

            if(clsUser.isUserExist(tbUserName.Text) && tbUserName.Text.Trim() == _User.UserName)
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUserName, "");
            }
            else
            {
                e.Cancel = true;
                tbUserName.Focus();
                errorProvider1.SetError(tbUserName, "Place choice anther user name because this is already used.");
            }

        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text == "")
            {
                e.Cancel = true;
                tbUserName.Focus();
                errorProvider1.SetError(tbPassword, "Pleace enter a Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPassword, "");
            }
        }

        private void tbConfrimPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfrimPassword.Text == "")
            {
                e.Cancel = true;
                tbUserName.Focus();
                errorProvider1.SetError(tbConfrimPassword, "Pleace enter the Confrim Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfrimPassword, "");
            }

            if (tbPassword.Text != tbConfrimPassword.Text)
            {
                e.Cancel = true;
                tbUserName.Focus();
                errorProvider1.SetError(tbConfrimPassword, "Password Do Not Match.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPassword, "");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
