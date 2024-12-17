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

namespace DVLD_SE.Applications.Application_Types
{
    public partial class frmEditApplicationType : Form
    {

        private int _ApplicationTypeID = 0;
        private clsApplicationType _ApplicationType;

        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType == null) 
            {
                MessageBox.Show("This Application Type Is Not Found...", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lbPersonID.Text = _ApplicationTypeID.ToString();
            tbTitle.Text = _ApplicationType.Title;
            tbFees.Text = _ApplicationType.Fees.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Complate Empty Faildes...");
                return;
            }

            _ApplicationType.Title = tbTitle.Text.Trim();
            _ApplicationType.Fees = float.Parse(tbFees.Text.Trim().ToString());

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Changes Has Been Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
            {
                MessageBox.Show("Something Went Worng...", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {

            if (!clsValidating.IsNumber(tbFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFees, "Pleace Enter Number Just.");
                tbFees.Focus();

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFees, "");
            }
        }

    }
}
