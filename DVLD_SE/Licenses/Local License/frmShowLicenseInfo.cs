﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_SE.Licenses.Local_License
{
    public partial class frmShowLicenseInfo : Form
    {
        int _LicenseID = -1;

        public frmShowLicenseInfo(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
