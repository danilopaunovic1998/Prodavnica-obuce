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
using View.UserControls;

namespace View
{
    public partial class FrmFindAndUpdateOrders : Form
    {
        OrderController orderController;
        
        public FrmFindAndUpdateOrders()
        {
            InitializeComponent();
            orderController = new OrderController();
            txtPremiumUser.Enabled = false;

        }

        private void btnFindPremiumUser_Click(object sender, EventArgs e)
        {
            UCFindPremiumUser ucFindPremiumUser = new UCFindPremiumUser(new PremiumUserController());

            Form window = new Form
            {
                Text = "Find premium user",
                TopLevel = true,
                FormBorderStyle = FormBorderStyle.Fixed3D, //Disables user resizing
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = ucFindPremiumUser.Size //size the form to fit the content
            };
            window.Controls.Add(ucFindPremiumUser);
            window.ShowDialog();
            try
            {
                Communication.Communication.Instance.GetSelectedPremiumUser(txtPremiumUser);
                dgvOrders.DataSource = null;
            }
            catch (Exception)
            {

                return;
            } 
            
        }

        private void btnFindOrder_Click(object sender, EventArgs e)
        {
            
            orderController.FindOrders(dtpDateCriteria, chkbIsPaid, dgvOrders,txtPremiumUser);
            dgvOrders.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            orderController.DeleteOrder(dgvOrders);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource == null)
            {
                MessageBox.Show("Niste pretrazili porudzbine");
                return;
            }
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali red");
                return;
            }
            orderController.SetOrder(dgvOrders.SelectedRows[0].DataBoundItem);
            MainCoordinator.Instance.OpenViewOrder(orderController);
        }
    }
}
