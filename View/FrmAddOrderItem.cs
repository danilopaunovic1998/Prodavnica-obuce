using Domen;
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

namespace View
{
    public partial class FrmAddOrderItem : Form
    {
        OrderController orderController;
        Supplier supplier;
        Footwear footwear;
        
        public FrmAddOrderItem(OrderController orderController)
        {
            InitializeComponent();
            this.orderController = orderController;
            footwear = new Footwear();
            
            GetComboBoxSupplierDataSource();

        }

        private void GetComboBoxSupplierDataSource()
        {
            cmbSupplier.DataSource = (List<Supplier>)Communication.Communication.Instance.ReturnAllSuppliers();
            cmbSupplier.SelectedIndex = -1;
            cmbFootwear.Enabled = false;
            cmbFootwear.SelectedIndex = -1;
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedIndex != -1)
            {
                supplier = (Supplier)cmbSupplier.SelectedItem;
                footwear.ConditionForSearch = $"f.SupplierID = '{supplier.SupplierID}'";

                if (Communication.Communication.Instance.FindFootwear(footwear))
                {
                    cmbFootwear.DataSource = Communication.Communication.Instance.footwearsFound;
                    cmbFootwear.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Dati dobavljac nema obucu za prodaju, probajte nekog drugog");
                    return;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidationHelpers.EmptyFieldValidation(txtQuantity) & ValidationHelpers.EmptyFieldValidation(txtSize))
            {
                return;
            }

            if (!ValidationHelpers.IsIntValidation(txtQuantity))
            {
                MessageBox.Show("Quantuty mora biti ceo broj");
                return;
            }

            if (!ValidationHelpers.IsIntValidation(txtSize))
            {
                MessageBox.Show("Size mora biti ceo broj");
                return;
            }
            if (cmbSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite dobavljaca");
                return;
            }

            Supplier s = (Supplier)cmbSupplier.SelectedItem;
            Footwear f = (Footwear)cmbFootwear.SelectedItem;


            orderController.AddOrderItemToList(s, f, int.Parse(txtQuantity.Text), int.Parse(txtSize.Text));
            this.Close();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtQuantity);
        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtSize);
        }
    }
}
