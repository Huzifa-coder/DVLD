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
    public partial class frmManageUsers : Form
    {
        DataTable _dtUsers;

        public frmManageUsers()
        {
            InitializeComponent();
            
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;

        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;

            if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";

                dgvUsers.Columns[1].HeaderText = "Person ID";

                dgvUsers.Columns[2].HeaderText = "Full Name";

                dgvUsers.Columns[3].HeaderText = "User Name";

                dgvUsers.Columns[4].HeaderText = "Is Active";

            }

            lbRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();


        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            if (clsUser.DeleteUser(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageUsers_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void changeUserPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implement Yet.", "Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implement Yet.", "Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = ((string)cbFilterBy.SelectedItem != "None" && (string)cbFilterBy.SelectedItem != "Is Active");

            cbIsActive.Visible = ((string)cbFilterBy.SelectedItem == "Is Active");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Text = "";
                tbFilterValue.Focus();
            }

        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (tbFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lbRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName") { 
                //in this case we deal with numbers not string.
                try
                {
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilterValue.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Enter Vailed Numbers.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = _dtUsers.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvUsers.Rows.Count == 0) return;

            if ((string)cbIsActive.SelectedItem == "Yes")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[IsActive] = 1");
            }
            else if ((string)cbIsActive.SelectedItem == "No")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[IsActive] = 0");
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = "";
            }

            lbRecords.Text = _dtUsers.DefaultView.Count.ToString();
        }
    }
}
