using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_SE.People
{
    public partial class frmPersonInfo : Form
    {


        public frmPersonInfo(int personID)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(personID);

        }
        public frmPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(NationalNo);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
