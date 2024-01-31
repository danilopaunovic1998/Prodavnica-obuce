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
    public partial class UCAddFootwear : UserControl
    {
        //zasto readonly
        private readonly FootwearController footwearController;
       
        public UCAddFootwear(FootwearController footwearController)
        {
            InitializeComponent();
            this.footwearController = footwearController;
            footwearController.FillSupplierCMB(cmbSupplier, this);
        }

     

        private void UCAddFootwear_Load(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtModel);
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtBrand);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtPrice);
        }

        private void btnSaveFootwear_Click(object sender, EventArgs e)
        {
            footwearController.AddFootwear(txtModel, txtBrand, txtPrice, cmbSupplier);
        }
    }
}
