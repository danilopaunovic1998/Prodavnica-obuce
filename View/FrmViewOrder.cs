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

namespace View
{
    public partial class FrmViewOrder : Form
    {
        OrderController orderController;
       

        public FrmViewOrder(OrderController orderController)
        {
            InitializeComponent();
            this.orderController = orderController;
            txtAmount.Enabled = false;
            txtDate.Enabled = false;
            txtPremiumUser.Enabled = false;
        }

        private void FrmViewOrder_Load(object sender, EventArgs e)
        {

            orderController.GetOrderItems(dgvOrderItems, txtAmount, txtDate, txtPremiumUser);
        }
    }
}
