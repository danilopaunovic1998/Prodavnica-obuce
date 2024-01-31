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
    public partial class FrmViewFootwear : Form
    {
        FootwearController footwearController;
        public FrmViewFootwear()
        {
            InitializeComponent();
            footwearController = new FootwearController();
        }

        private void FrmViewFootwear_Load(object sender, EventArgs e)
        {
            footwearController.FillFootwearDGV(dgvFootwear);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            footwearController.DeleteSelectedFootwear(dgvFootwear);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenUpdateFootwear(dgvFootwear);
            this.Close();

        }
    }
    
}
