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

namespace DVLD_SE.Tests
{
    public partial class frmScheduleTest : Form
    {
        int _localDrivingLinceseApplictionID = -1;
        int _AppiontmentID = -1;
        clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        
        public frmScheduleTest(int LocalLicenseApplictionID, clsTestType.enTestType testType, int AppointmentID =-1)
        {
            InitializeComponent();

            _localDrivingLinceseApplictionID = LocalLicenseApplictionID;
            _AppiontmentID = AppointmentID;
            _TestType = testType;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
           
            ctrlTestSchedule1.TestTypeID = _TestType;
            ctrlTestSchedule1.LoadInfo(_localDrivingLinceseApplictionID, _AppiontmentID);

        }

    }
}
