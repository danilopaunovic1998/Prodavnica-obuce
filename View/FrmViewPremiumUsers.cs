using System;
using System.Windows.Forms;
using View.Controllers;

namespace View
{
    public partial class FrmViewPremiumUsers : Form
    {
        PremiumUserController premiumUserController;
        public FrmViewPremiumUsers()
        {
            InitializeComponent();
            premiumUserController = new PremiumUserController();
        }

        private void FrmViewPremiumUsers_Load(object sender, EventArgs e)
        {
            premiumUserController.FillPremiumUserDGV(dgvPremiumUsers);
            dgvPremiumUsers.Columns[2].Visible = false;
            dgvPremiumUsers.Columns[3].Visible = false;
        }

        private void dgvPremiumUsers_DoubleClick(object sender, EventArgs e)
        {

            MessageBox.Show(premiumUserController.ShowSelectedPremiumUser(dgvPremiumUsers));
            this.Close();
        }
    }
}
