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

namespace DVLD_SE.Users
{
    public partial class ctrlUserCard : UserControl
    {

        private int _UserID ;
        private clsUser _User;

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User =clsUser.FindByUserID(UserID);

            if( _User == null )
            {
                _ResetUserInfo();
                MessageBox.Show("They is no person wiht [" + UserID.ToString() + "] ID.");
                return;
            }

            _FillUserInfo();
        }

        private void _ResetUserInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            lbUserID.Text = "N/A";
            lbUserName.Text = "N/A";
            lbIsActive.Text = "N/A";

        }

        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lbUserID.Text = _User.UserID.ToString();
            lbUserName.Text = _User.UserName;
            lbIsActive.Text = (_User.IsActive) ? "Yes" : "NO";
        }

    }
}
