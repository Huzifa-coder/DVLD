using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace DVLD_SE.People
{
    public partial class frmManagePeople : Form
    {

        private DataTable _dtPeople = null;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {

            _dtPeople = clsPerson.GetAllPeople();

            dgvPeople.DataSource = _dtPeople;

            cbFilterBy.SelectedIndex = 0;

            lbRecords.Text = _dtPeople.Rows.Count.ToString();
        }
      
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _LoadData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _LoadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are Sure Do You Want To Delete Person With ID = [" + dgvPeople.CurrentRow.Cells[0].Value.ToString() + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;

            if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Person Deleted Successfully", "Complate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("Person Deleted Does Not Complate, Because Some Data releated to it....", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            tbFilterValue.Visible = ((string)cbFilterBy.SelectedItem != "None");
            
            if (tbFilterValue.Visible)
            {
                tbFilterValue.Text = "";
                tbFilterValue.Focus();
            }
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = "";

            switch((string)cbFilterBy.SelectedItem)
            {
                case "Person ID":
                    filterColumn = "PersonID";
                    break;

                case "National No":
                    filterColumn = "NationalNo";

                    break;

                case "First Name":
                    filterColumn = "FirstName";

                    break;

                case "Second Name":
                    filterColumn = "SecondName";

                    break;

                case "Third Name":
                    filterColumn = "ThirdName";

                    break;

                case "Last Name":
                    filterColumn = "LastName";

                    break;

                case "Nationalty":
                    filterColumn = "CountryName";

                    break;

                case "Gendor":
                    filterColumn = "Gendor";

                    break;

                case "Phone":
                    filterColumn = "Phone";

                    break;

                case "Email":
                    filterColumn = "Email";

                    break;
                
                    default: 
                    filterColumn = "None";
                    break;
            }

            if(filterColumn == "None" || tbFilterValue.Text.Trim() == "") {

                _dtPeople.DefaultView.RowFilter = "";
                lbRecords.Text = dgvPeople.Rows.Count.ToString();
                return;
            }


            if (filterColumn == "PersonID")
                try {
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, tbFilterValue.Text.Trim());
                }
                catch 
                {
                    MessageBox.Show("Enter Vailed Numbers.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvPeople.Rows.Count.ToString();

        }

    }
}
