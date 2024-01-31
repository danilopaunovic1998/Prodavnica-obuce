using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Helpers;

namespace View.Controllers
{
    public class SupplierController
    {
        BindingList<Supplier> suppliers;
        internal void AddNewSupplier(TextBox txtCompanyName, TextBox txtHeadOfSales, RichTextBox rtxtDescription)
        {
            if (ValidationHelpers.EmptyFieldValidation(txtCompanyName)
                | ValidationHelpers.EmptyFieldValidation(txtHeadOfSales)
                | ValidationHelpers.EmptyFieldValidation(rtxtDescription))
            {
                return;
            }

            Supplier supplier = new Supplier();
            supplier.CompanyName = txtCompanyName.Text;
            supplier.NameOfSaleEmployee = txtHeadOfSales.Text;
            supplier.Description = rtxtDescription.Text;

            try
            {
                if (Communication.Communication.Instance.AddNewSupplier(supplier))
                {
                    MessageBox.Show("Dobavljac je uspesno sacuvan");
                }
                else 
                {
                    MessageBox.Show("");
                }
                txtCompanyName.Text = "";
                txtHeadOfSales.Text = "";
                rtxtDescription.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sistem nije uspeo da sacuva dobavljaca!");
                MessageBox.Show(ex.Message);
            }
        }

        internal string ShowSelectedSupplier(DataGridView dgvSupplier)
        {
            DataGridViewRow row = dgvSupplier.SelectedRows[0];
            Supplier s = (Supplier)row.DataBoundItem;

            return $"Company Name: {s.CompanyName} \n Sales Employee: {s.NameOfSaleEmployee} \n Description: {s.Description}";
        }

        internal void FillSupplierDGV(DataGridView dgvSupplier)
        {
            suppliers = new BindingList<Supplier>(Communication.Communication.Instance.suppliersFound);
            dgvSupplier.DataSource = suppliers;
        }

        internal void FindSupplier(string criteria)
        {
            Supplier supplier = new Supplier();
            supplier.ConditionForSearch = $"lower(CompanyName) like lower('{criteria}') or lower(NameOfSaleEmployee) like lower('{criteria}')";
            if (Communication.Communication.Instance.FindSupplier(supplier))
            {
                MessageBox.Show("Sistem je pronasao bar jednog dobavljaca");
                MainCoordinator.Instance.OpenViewSuppliers();
                return;
            }
            else
            {
                MessageBox.Show("Ne postoji dobavljac sa unetim kriterijumima, pokusajte ponovo!");
                return;

            }
        }
    }
}
