﻿using DVLD_Business;
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
    public partial class frmListApplicationTypes : Form
    {

        private DataTable _dtApplicationTypes;

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtApplicationTypes = clsApplicationType.GetAllApplicationTypes();  
            dgvApplicationTypes.DataSource = _dtApplicationTypes;
            lbRecords.Text = dgvApplicationTypes.ColumnCount.ToString();

            if (dgvApplicationTypes.Rows.Count > 0) 
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 110;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 440;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 100;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();


            frmListApplicationTypes_Load(null, null);
        }

    }
}
