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
    public class PremiumUserController
    {
        private BindingList<PremiumUser> premiumUsers;
        private PremiumUser foundPremiumUser;
        
        internal void AddPremiumUser(TextBox txtFirstName, TextBox txtLastName, DateTimePicker dtpDateOfBirth, TextBox txtBonus)
        {
            try
            {
                if (ValidationHelpers.EmptyFieldValidation(txtFirstName) |
                    ValidationHelpers.EmptyFieldValidation(txtLastName) |
                    ValidationHelpers.EmptyFieldValidation(txtBonus) |
                    !ValidationHelpers.Over18Validetion(dtpDateOfBirth))
                {
                    return;
                }
                
                if (!(ValidationHelpers.IsDoubleValidation(txtBonus)))
                {
                    MessageBox.Show("Bonus nije decimalni broj");
                    return;
                }
                
                if (!(ValidationHelpers.IsBonusOk(txtBonus)))
                {
                    MessageBox.Show("Bonus nije broj izmedju 0 i 1");
                    return;
                }
                
                PremiumUser premiumUser = new PremiumUser();
                premiumUser.FirstName = txtFirstName.Text;
                premiumUser.LastName = txtLastName.Text;
                premiumUser.DateOfBirth = dtpDateOfBirth.Value;
                premiumUser.Bonus = Convert.ToDouble(txtBonus.Text);

                if (Communication.Communication.Instance.AddNewPremiumUser(premiumUser))
                {
                    MessageBox.Show("Premium user je uspesno sacuvan");
                }
                else 
                {
                    MessageBox.Show($"Premium user {premiumUser.FirstName} {premiumUser.LastName} vec postoji u sistemu!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Doslo je do greske prilikom cuvanja!");
                Console.WriteLine(">>" + ex.Message);
            }

            
        }

        internal string ShowSelectedPremiumUser(DataGridView dgvPremiumUsers)
        {
            DataGridViewRow row =  dgvPremiumUsers.SelectedRows[0];
            foundPremiumUser = (PremiumUser)row.DataBoundItem;
            Communication.Communication.Instance.SetFoundPremiumUser(foundPremiumUser);
            return $"First Name: {foundPremiumUser.FirstName} \n Last Name: {foundPremiumUser.LastName} \n Date of Birth: {foundPremiumUser.DateOfBirth.ToString("dd:MM:yyyy")} \n Bonus: {foundPremiumUser.Bonus.ToString()}%";
        }

        internal void FillPremiumUserDGV(DataGridView dgvPremiumUsers)
        {
            premiumUsers = new BindingList<PremiumUser>(Communication.Communication.Instance.premiumUsersFound);
            dgvPremiumUsers.DataSource = premiumUsers;
        }

       

        internal void FindPremiumUser(TextBox txtCriteria)
        {
            PremiumUser premiumUser = new PremiumUser();
            string criteria = "%" + txtCriteria.Text + "%";
            premiumUser.ConditionForSearch = $"lower(FirstName) like lower('{criteria}') or lower(LastName) like lower('{criteria}')";
            if(Communication.Communication.Instance.FindPremiumUser(premiumUser))
            {
                MessageBox.Show("Sistem je pronasao premium user-a");
                MainCoordinator.Instance.OpenViewPremiumUser();
                // da li da izlazi?
                return;
            }
            else
            {
                MessageBox.Show("Ne postoji premium user sa unetim kriterijumima, pokusajte ponovo!");
                return;

            }
        }
    }
}
