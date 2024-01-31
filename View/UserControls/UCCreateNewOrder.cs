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


namespace View.UserControls
{
    public partial class UCCreateNewOrder : UserControl
    {
        OrderController orderController;

        public UCCreateNewOrder(OrderController orderController)
        {
            InitializeComponent();
            this.orderController = orderController;
            txtPremiumUser.Enabled = false;
            txtAmount.Enabled = false;
            
            
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
            Communication.Communication.Instance.GetSelectedPremiumUser(txtPremiumUser);
            window.Close();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenAddOrderItem(orderController);
            orderController.RefreshDataGridView(dgvOrderItems);
            EditDataGridView();
            orderController.RefreshAmount(txtAmount);
        }
        private void EditDataGridView()
        {
            dgvOrderItems.Columns["Footwear"].DisplayIndex = 0;
            dgvOrderItems.Columns["Supplier"].DisplayIndex = 1;
            dgvOrderItems.Columns["Size"].DisplayIndex = 2;
            dgvOrderItems.Columns["Quantity"].DisplayIndex = 3;
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            orderController.RemoveOrderItem(dgvOrderItems);
            orderController.RefreshDataGridView(dgvOrderItems);
            orderController.RefreshAmount(txtAmount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            orderController.SaveOrder(dtpDateOfCreation, txtPremiumUser, chkBonus, ckbPaid, txtAmount);
        }
    }
}
