using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Controllers;
using View.Helpers;

namespace View.UserControls
{
    public partial class UCAddPremiumUser : UserControl
    {
        private readonly PremiumUserController premiumUserController;
       
        public UCAddPremiumUser(PremiumUserController premiumUserController)
        {
            InitializeComponent();
            this.premiumUserController = premiumUserController;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtFirstName);
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtLastName);
        }

        private void txtBonus_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtBonus);
        }

        private void btnSavePremiumUser_Click(object sender, EventArgs e)
        {
            premiumUserController.AddPremiumUser(txtFirstName, txtLastName, dtpDateOfBirth, txtBonus);
        }
    }
}
