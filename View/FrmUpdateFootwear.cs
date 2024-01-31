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
    public partial class FrmUpdateFootwear : Form
    {
        FootwearController footwearController;

        private DataGridView dgvFootwear { get; set; }

        public FrmUpdateFootwear(DataGridView dgvFootwear)
        {
            InitializeComponent();
            this.dgvFootwear = dgvFootwear;
            footwearController = new FootwearController();
            footwearController.FillSupplierCMB(cmbSupplier, this);
            footwearController.FillUpdateFootwearFrm(txtModel, txtBrand, txtPrice, cmbSupplier, dgvFootwear);

        }

        private void btnResetInfo_Click(object sender, EventArgs e)
        {
            footwearController.ResetUpdateFootwearFrm(txtModel, txtBrand, txtPrice, cmbSupplier);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            footwearController.UpdateFootwear(txtModel, txtBrand, txtPrice, cmbSupplier, this);
            
        }
    }
}
