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
    public partial class UCFindSupplier : UserControl
    {
        private readonly SupplierController supplierController;
        

        public UCFindSupplier(SupplierController supplierController)
        {
            InitializeComponent();
            this.supplierController = supplierController;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (ValidationHelpers.EmptyFieldValidation(txtCriteria))
            {
                return;
            }

            string criteria = "%" + txtCriteria.Text + "%";

            //sta ako prosledi null?
            supplierController.FindSupplier(criteria);
        }
    }
}
