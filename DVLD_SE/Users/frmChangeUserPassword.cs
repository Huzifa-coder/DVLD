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
    public partial class frmChangeUserPassword : Form
    {
        private int _UserID;
        private clsUser _User;

        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _ResetValues()
        {
            tbConfrimPassword.Text = "";
            tbCurrentPassword.Text = "";
            tbNewPassword.Text = "";
            tbCurrentPassword.Focus();
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            _ResetValues();

            _User = clsUser.FindByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show("No User With [" + _UserID + "] ID", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(tbCurrentPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "This Faild is Empty, Pleace Enter Your Password");
                tbCurrentPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCurrentPassword, "");
            }

            if(tbCurrentPassword.Text.Trim() != _User.Password.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "This Password Is Wrong, Pleace Enter Again");
                tbCurrentPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCurrentPassword, "");
            }
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbNewPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNewPassword, "This Faild is Empty, Pleace Enter Your New Password");
                tbNewPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNewPassword, "");
            }
        }

        private void tbConfrimPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfrimPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfrimPassword, "This Faild is Empty, Pleace Enter Your Password");
                tbConfrimPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfrimPassword, "");
            }

            if (tbNewPassword.Text.Trim() != tbConfrimPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfrimPassword, "This Password Does Not Match With New Password");
                tbCurrentPassword.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfrimPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             if(!this.ValidateChildren())
            {
                MessageBox.Show("They Are Some faileds Are Empty, Pleace Check Again", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

             _User.Password = tbNewPassword.Text.Trim();
            if (_User.Save())
            {
                MessageBox.Show("Password Has Been Changed Successfully.", "Complate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Does Not Changed.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _ResetValues();

        }

    }
}
