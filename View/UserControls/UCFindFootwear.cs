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
    public partial class UCFindFootwear : UserControl
    {
        private readonly FootwearController footwearController;
      

        public UCFindFootwear(FootwearController footwearController)
        {
            InitializeComponent();
            this.footwearController = footwearController;
            
        }

        private void txtCriteria_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtCriteria);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            footwearController.FindFootwear(txtCriteria,cmbSupplierCriteria);
        }

        private void UCFindFootwear_Load(object sender, EventArgs e)
        {
            footwearController.FillSupplierCMB(cmbSupplierCriteria, this);
            cmbSupplierCriteria.SelectedIndex = -1;
            
        }
    }
}
