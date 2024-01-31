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
    public partial class FrmViewSuppliers : Form
    {
        SupplierController supplierController;
        public FrmViewSuppliers()
        {
            InitializeComponent();
            supplierController = new SupplierController();
        }

        private void FrmViewSuppliers_Load(object sender, EventArgs e)
        {
            supplierController.FillSupplierDGV(dgvSupplier);
        }

        private void dgvSupplier_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(supplierController.ShowSelectedSupplier(dgvSupplier));
        }
    }
}
