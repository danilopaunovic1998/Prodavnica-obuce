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
    public partial class UCFindPremiumUser : UserControl
    {
        private readonly PremiumUserController premiumUserController;
      

        public UCFindPremiumUser(PremiumUserController premiumUserController)
        {
            InitializeComponent();
            this.premiumUserController = premiumUserController;
        }

        private void btnFindPremiumUser_Click(object sender, EventArgs e)
        {

            if (ValidationHelpers.EmptyFieldValidation(txtCriteria))
            {
                return;
            }
            //sta ako prosledi null?
            premiumUserController.FindPremiumUser(txtCriteria);
            if (this.Parent is Panel)
            {
                return;
            }
            else
            {
                this.Parent.Visible = false;
            }
            
        }
    }
}
