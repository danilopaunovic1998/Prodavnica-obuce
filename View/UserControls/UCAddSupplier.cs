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
    public partial class UCAddSupplier : UserControl
    {

        private readonly SupplierController supplierController;

        public UCAddSupplier(SupplierController supplierController)
        {
            InitializeComponent();
            this.supplierController = supplierController;
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            supplierController.AddNewSupplier(txtCompanyName, txtHeadOfSales, rtxtDescription);
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtCompanyName);
        }

        private void txtHeadOfSales_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtHeadOfSales);
        }

        private void rtxtDescription_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(rtxtDescription);
        }
    }
}
