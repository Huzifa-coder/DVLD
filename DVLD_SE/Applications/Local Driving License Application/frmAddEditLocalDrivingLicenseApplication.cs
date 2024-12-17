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

namespace DVLD_SE.Applications.Local_Driving_License_Application
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        int _SelectedPersonID = -1;
        int _LocalDrivingLicneseApplicationID = -1;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        enum enMode { New, Update }

        enMode _mode;
        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            _mode = enMode.New;
            tpApplication.Enabled = false;

        }

        public frmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicneseApplicationID = LocalDrivingLicenseApplicationID;
            tpApplication.Enabled = false;
            _mode = enMode.Update; 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplication.Enabled = true;
                tcApplication.SelectedTab = tcApplication.TabPages["tcApplication"];
                return;
            }


            //incase of add new mode.
            if (ctrlPersonFilterCard1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpApplication.Enabled = true;
                tcApplication.SelectedTab = tcApplication.TabPages["tpApplication"];

            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonFilterCard1.FilterFocus();
            }

        }


        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _RestDefualteValues();

            if(_mode == enMode.Update )
            {
                _LoadDate();
            }
        }

        private void _LoadDate()
        {
            ctrlPersonFilterCard1.FilterEndable = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicneseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicneseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonFilterCard1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lbApplicatoinID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lbApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lbCreatedBy.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }

        private void _RestDefualteValues()
        {
            FillLicenseClassList();

            if (_mode == enMode.New)
            {
                this.Text = "New Local Driving License Application";
                lbTitle.Text = "New Local Driving License Application";
                ctrlPersonFilterCard1.FilterFocus();

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbApplicationFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.NewDrivingLicense).Fees.ToString(); 
                lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
                cbLicenseClasses.SelectedIndex = clsLicenseClass.Find("Class 3 - Ordinary driving license").LicenseClassID - 1;
            }
            else
            {
                this.Text = "Update Local Driving License Application";
                lbTitle.Text = "Update Local Driving License Application";

                tpApplication.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void FillLicenseClassList()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;


            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }


            //check if user already have issued license of the same driving  class.
            if (clsLicense.IsLicenseExistByPersonID(ctrlPersonFilterCard1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonFilterCard1.PersonID; ;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lbApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {
                lbApplicatoinID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _mode = enMode.Update;
                lbTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonFilterCard1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }
    }
}
