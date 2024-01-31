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
    public class FootwearController
    {

        BindingList<Footwear> footwearList;
        Footwear footwearForUpdate;
        
        internal void FillSupplierCMB(ComboBox cmbSupplier, UserControl uc)
        {
            try
            {
                cmbSupplier.DataSource = (List<Supplier>)Communication.Communication.Instance.ReturnAllSuppliers();
                if (cmbSupplier.DataSource == null)
                {
                    MessageBox.Show("Ne postoje dobavljaci!\nUnesite prvo dobavljace!");
                    uc.Hide();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Doslo je do greske prilikom ucitavanja!");
                Console.WriteLine(">>" + ex.Message);
            }
            
            

        }

        internal void ResetUpdateFootwearFrm(TextBox txtModel, TextBox txtBrand, TextBox txtPrice, ComboBox cmbSupplier)
        {
            txtModel.Text = footwearForUpdate.Model;
            txtBrand.Text = footwearForUpdate.Brand;
            txtPrice.Text = footwearForUpdate.Price.ToString();
            cmbSupplier.SelectedIndex = cmbSupplier.FindStringExact(footwearForUpdate.Supplier.ToString());
        }


        internal void FillUpdateFootwearFrm(TextBox txtModel, TextBox txtBrand, TextBox txtPrice, ComboBox cmbSupplier, DataGridView dgvFootwear)
        {
            footwearForUpdate = (Footwear)dgvFootwear.SelectedRows[0].DataBoundItem;
            txtModel.Text = footwearForUpdate.Model;
            txtBrand.Text = footwearForUpdate.Brand;
            txtPrice.Text = footwearForUpdate.Price.ToString();
            cmbSupplier.SelectedIndex = cmbSupplier.FindStringExact(footwearForUpdate.Supplier.ToString());
        }

        internal void FillSupplierCMB(ComboBox cmbSupplier, FrmUpdateFootwear frmUpdateFootwear)
        {
            try
            {
                cmbSupplier.DataSource = (List<Supplier>)Communication.Communication.Instance.ReturnAllSuppliers();
                if (cmbSupplier.DataSource == null)
                {
                    MessageBox.Show("Ne postoje dobavljaci!\nUnesite prvo dobavljace!");
                    frmUpdateFootwear.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Doslo je do greske prilikom ucitavanja!");
                Console.WriteLine(">>" + ex.Message);
            }
        }

        internal void DeleteSelectedFootwear(DataGridView dgvFootwear)
        {
            DataGridViewRow row = dgvFootwear.SelectedRows[0];
            Footwear f = (Footwear)row.DataBoundItem;
            try
            {
                if (Communication.Communication.Instance.DeleteFootwear(f))
                {
                    MessageBox.Show("Obuca je uspesno obrisana!");
                    dgvFootwear.Rows.Remove(row);
                    //uradi mozda jos nesto
                }
                else 
                {

                    MessageBox.Show("Neuspesno brisanje obuce");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        internal void FillFootwearDGV(DataGridView dgvFootwear)
        {
            footwearList = new BindingList<Footwear>(Communication.Communication.Instance.footwearsFound);
            dgvFootwear.DataSource = footwearList;
        }
        internal void UpdateFootwear(TextBox txtModel, TextBox txtBrand, TextBox txtPrice, ComboBox cmbSupplier, FrmUpdateFootwear frmUpdateFootwear)
        {
            try
            {
                if (ValidationHelpers.EmptyFieldValidation(txtModel) |
                    ValidationHelpers.EmptyFieldValidation(txtBrand) |
                    ValidationHelpers.EmptyFieldValidation(txtPrice))
                {
                    return;
                }
                if (!(ValidationHelpers.IsDoubleValidation(txtPrice)))
                {
                    MessageBox.Show("Price nije decimalni broj");
                    return;
                }
                if (txtModel.Text == footwearForUpdate.Model &&
                    txtBrand.Text == footwearForUpdate.Brand &&
                    Convert.ToDouble(txtPrice.Text) == footwearForUpdate.Price &&
                    (Supplier)cmbSupplier.SelectedItem == footwearForUpdate.Supplier)
                {
                    MessageBox.Show("Niste uneli nikakve promene");
                    return;
                }

                Footwear footwear = footwearForUpdate;
                footwear.Model = txtModel.Text;
                footwear.Brand = txtBrand.Text;
                footwear.Price = Convert.ToDouble(txtPrice.Text);
                footwear.Supplier = (Supplier)cmbSupplier.SelectedItem;

                if (Communication.Communication.Instance.UpdateFootwear(footwear))
                {
                    MessageBox.Show("Obuca je uspesno izmenjena");
                    frmUpdateFootwear.Close();
                }
                else
                {
                    MessageBox.Show($"Neuspesna izmena");
                    frmUpdateFootwear.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske prilikom cuvanja!");
                Console.WriteLine(">>" + ex.Message);
            }
        }

        internal void AddFootwear(TextBox txtModel, TextBox txtBrand, TextBox txtPrice, ComboBox cmbSupplier)
        {
            try
            {
                if (ValidationHelpers.EmptyFieldValidation(txtModel) |
                   ValidationHelpers.EmptyFieldValidation(txtBrand) |
                   ValidationHelpers.EmptyFieldValidation(txtPrice))
                {
                    return;
                }
                if (!(ValidationHelpers.IsDoubleValidation(txtPrice)))
                {
                    MessageBox.Show("Price nije decimalni broj");
                    return;
                }
                Footwear footwear = new Footwear();
                footwear.Model = txtModel.Text;
                footwear.Brand = txtBrand.Text;
                footwear.Price = Convert.ToDouble(txtPrice.Text);
                footwear.Supplier = (Supplier)cmbSupplier.SelectedItem;

                if(Communication.Communication.Instance.AddNewFootwear(footwear))
                {
                    MessageBox.Show("Nova obuca je uspesno sacuvana");
                }
                else
                {
                    MessageBox.Show($"Obuca {txtModel.Text} {txtBrand.Text} vec postoji u sistemu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske prilikom cuvanja!");
                Console.WriteLine(">>" + ex.Message);
            }
        }

        internal void FindFootwear(TextBox txtCriteria, ComboBox cmbSupplierCriteria)
        {
            Footwear footwear = new Footwear();
            if (cmbSupplierCriteria.SelectedIndex == -1 && ValidationHelpers.EmptyFieldValidation(txtCriteria))
            {
                return;
            }
            if (cmbSupplierCriteria.SelectedIndex == -1)
            {
                string criteria = "%" + txtCriteria.Text + "%";
                
                footwear.ConditionForSearch = $"lower(f.Brand) like lower('{criteria}') or lower(f.Model) like lower('{criteria}')";
            }
            else if (string.IsNullOrEmpty(txtCriteria.Text))
            {
                Supplier s = (Supplier)cmbSupplierCriteria.SelectedItem;
                footwear.ConditionForSearch = $"f.SupplierID = '{s.SupplierID}'";
            }
            else 
            {
                Supplier s = (Supplier)cmbSupplierCriteria.SelectedItem;
                string criteria = "%" + txtCriteria.Text + "%";

                footwear.ConditionForSearch = $"f.SupplierID = '{s.SupplierID}' and (lower(f.Brand) like lower('{criteria}') or lower(f.Model) like lower('{criteria}'))";
            }
            if (Communication.Communication.Instance.FindFootwear(footwear))
            {
                MessageBox.Show("Sistem je pronasao obucu");
                MainCoordinator.Instance.OpenViewFootwear();
                // da li da izlazi?
                return;
            }
            else
            {
                MessageBox.Show("Ne postoji obuca sa unetim kriterijumima, pokusajte ponovo!");
                return;

            }
        }
    }
}
