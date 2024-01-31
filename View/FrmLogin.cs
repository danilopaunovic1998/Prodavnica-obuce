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
    public partial class FrmLogin : Form
    {
        private LoginController loginController;
        public FrmLogin()
        {
            InitializeComponent();
            this.loginController = new LoginController();
            txtUsername.Text = "daki";
            txtPassword.Text = "daki";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (loginController.Connect())
            {
                if (ValidationHelpers.EmptyFieldValidation(txtUsername) |
                    ValidationHelpers.EmptyFieldValidation(txtPassword))
                {
                    return;
                }

                if (loginController.LogIn(txtUsername, txtPassword))
                {
                    FrmMain frmMain = new FrmMain();
                    this.Visible = false;
                    frmMain.ShowDialog();
                    //cemu ovo????
                    try
                    {
                        this.Visible = true;
                    }
                    catch (Exception)
                    {

                        return;
                    }

                }
                else 
                {
                    MessageBox.Show("Neuspesno logovanje");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.BackColor = Color.LightCoral;
                    txtPassword.BackColor = Color.LightCoral;

                }
                    
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtUsername);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidationHelpers.ResetColor(txtPassword);
        }

    }
}
