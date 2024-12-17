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

namespace DVLD_SE.People.Controls
{
    public partial class ctrlPersonFilterCard : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PerosnID)
        {
            Action<int> handler = OnPersonSelected;
            if(handler != null)
            {
                handler(PerosnID);
            }
        }


        private bool _ShowAddPerson;
        public bool ShowAddPersonBtn
        {
            get { return _ShowAddPerson; } 
            
            set  
            {
                _ShowAddPerson = value;
                btnAddPerson.Enabled = _ShowAddPerson;
            }
        }


        private bool _FilterEnalble;
        public bool FilterEndable
        {
            get { return _FilterEnalble;}

            set
            {
                _FilterEnalble = value;
                gbFilterd.Enabled = _FilterEnalble;
            }
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPerson
        {
            get { return ctrlPersonCard1.SelectedPersonInf; }
        }

        public ctrlPersonFilterCard()
        {
            InitializeComponent();
        }
        
        public void FilterFocus()
        {
            tbFilterValue.Focus();
        }

        public void LoadPersonInfo(int PersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void _FindNow()
        {
            switch(cbOptions.SelectedIndex)
            {
                case 0:
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(tbFilterValue.Text.Trim()));
                    break;

                case 1:
                    ctrlPersonCard1.LoadPersonInfo(tbFilterValue.Text.Trim());
                    break;

                default:
                    break;
            }

            if(OnPersonSelected != null && FilterEndable == true)
            {
                OnPersonSelected(ctrlPersonCard1.PersonID);
            }
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
            }

            if(cbOptions.SelectedIndex == 0)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Faild Are Not Failed, Pleace fill all fileds", "Not Complated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FindNow();
        }

        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Text = "";
            tbFilterValue.Focus();
        }

        private void ctrlPersonFilterCard_Load(object sender, EventArgs e)
        {

            FilterEndable = true;
            ShowAddPersonBtn = true;

            cbOptions.SelectedIndex = 0;
            tbFilterValue.Focus();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            
            cbOptions.SelectedIndex = 0;
            tbFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);

        }


    }
}
