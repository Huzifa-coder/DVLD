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

namespace DVLD_SE.Tests.Test_Types
{
    public partial class frmEditTestType : Form
    {
        private clsTestType.enTestType _testTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _testType;

        public frmEditTestType(clsTestType.enTestType type)
        {
            InitializeComponent();

            _testTypeID = type;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _testType = clsTestType.Find(_testTypeID);

            if (_testType != null) 
            {
                lbTestTypeID.Text = ((int)_testTypeID).ToString();
                tbTitle.Text = _testType.Title;
                tbDescription.Text = _testType.Description;
                tbFees.Text = _testType.Fees.ToString();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) {

                MessageBox.Show("Some Filds are not valide or empty, pleace try input again..");
            }

            _testType.Title = tbTitle.Text.Trim();
            _testType.Description = tbDescription.Text.Trim();
            _testType.Fees = float.Parse(tbFees.Text);

            if(_testType.Save())
                MessageBox.Show("The data saved successfully.");
            else
                MessageBox.Show("Erorr: the data not saved successfully pleace  try again..", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
