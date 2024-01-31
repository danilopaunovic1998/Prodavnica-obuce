using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Communication;

namespace View.Controllers
{
    public class LoginController
    {
        internal bool Connect()
        {
            try
            {
                Communication.Communication.Instance.Connect();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska pri povezivanju sa serverom");
                return false;
            }
        
        }

        internal bool LogIn(TextBox txtUsername, TextBox txtPassword)
        {
            try
            {
                StoreEmployee se = Communication.Communication.Instance.Login(txtUsername.Text, txtPassword.Text);

                if (se != null)
                {
                    MessageBox.Show($"Prodavac {se.FirstName} {se.LastName} se uspesno ulogovao!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Prodavac ne postoji ili se vec ulogovao. Pokusajte ponovo!");
                    return false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //obrisi ako radi bez frm
        internal bool LogIn(TextBox txtUsername, TextBox txtPassword, FrmLogin frmLogin)
        {
            try
            {
                StoreEmployee se = Communication.Communication.Instance.Login(txtUsername.Text, txtPassword.Text);

                if (se != null)
                {
                    MessageBox.Show($"Prodavac {se.FirstName} {se.LastName} se uspesno ulogovao!");
                    return true;
                }
                else 
                {
                    MessageBox.Show("Prodavac ne postoji ili se vec ulogovao. Pokusajte ponovo!");
                    return false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
