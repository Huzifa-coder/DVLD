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
    public partial class frmShowLocalDrivingLicenseApplicationInfo : Form
    {
        int _ApplicationID = -1;

        public frmShowLocalDrivingLicenseApplicationInfo(int ApplicationID)
        {
            InitializeComponent();

            _ApplicationID = ApplicationID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfoCard1.LoadApplicationInfoByLocalDrivingAppID(_ApplicationID);
        }
    }
}
