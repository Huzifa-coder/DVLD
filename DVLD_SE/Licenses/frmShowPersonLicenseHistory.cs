﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_SE.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID = -1;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();


        }

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {

            if (_PersonID != -1)
            {
                ctrlPersonFilterCard1.LoadPersonInfo(_PersonID);
                ctrlPersonFilterCard1.FilterEndable = false;
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlPersonFilterCard1.Enabled = true;
                ctrlPersonFilterCard1.FilterFocus();
            }



        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ctrlDriverLicenses1.Clear();
            }
            else
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}