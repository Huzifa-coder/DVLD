using DVLD_Business;
using DVLD_SE.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_SE
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }


        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if(clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                tbUserName.Text = UserName;
                tbPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                tbUserName.Text = "";
                tbPassword.Text = "";
                chkRememberMe.Checked = false;
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Pleace Fill All Fields ,Then Login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser user = clsUser.FindByUsernameAndPassword(tbUserName.Text.Trim(), tbPassword.Text.Trim());

            if (user != null)
            {

                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(tbUserName.Text, tbPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if (!user.IsActive)
                {

                    tbUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;

                frmMain frm = new frmMain(this);
                this.Hide();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Wrong UserName/Password, Pleace Try Again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            
            if(tb.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(tb, "Pleace Fill This Field");
                tb.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tb, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
