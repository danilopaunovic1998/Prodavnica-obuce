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
using View.UserControls;

namespace View
{
    public partial class FrmMain : Form
    {

        private MainController mainController;
        public FrmMain()
        {
            InitializeComponent();
            this.mainController = new MainController();
        }

        internal void SetPanel(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Parent = panel1;
            uc.Dock = DockStyle.Fill;
            uc.Anchor = AnchorStyles.None;
            int leftRightMargin = (panel1.Width - uc.Width) / 2;
            uc.Left = (panel1.Width - uc.Width) / 2;
            uc.Top = (panel1.Height - uc.Height) / 2;


        }

        private void addFootwearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCAddFootwear(this);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblStoreEmployee.Text = "Welcome " + mainController.WelcomeSE();
        }

        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCAddSupplier(this);
        }

        private void addNewPremiumUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCAddPremiumUser(this);
        }

        private void findPremiumUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCFindPremiumUser(this);
        }

        private void findSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpeUCFindSupplier(this);
        }

        private void findFootwearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCFindFootwear(this);
        }

        private void createNewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCCreateNewOrder(this);
        }

        private void findAndUpdateOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new FrmFindAndUpdateOrders().ShowDialog();
            this.Visible = true;
        }
    }
}
