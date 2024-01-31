using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Helpers
{
    public static class ValidationHelpers
    {
        internal static bool EmptyFieldValidation(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.LightCoral;
                return true;
            }
            else 
            {
                txt.BackColor = Color.White;
                return false;
            }
        }

        internal static bool Over18Validetion(DateTimePicker dtpDateOfBirth)
        {
            if ((DateTime.Now - dtpDateOfBirth.Value).TotalDays < 18 * 365)
            {
                MessageBox.Show("Korisnik nije punoletan");
                return false;
            }
            return true;
        }

        internal static bool IsBonusOk(TextBox txtBonus)
        {
            double d = double.Parse(txtBonus.Text);
            if (d > 1 || d < 0)
            {
                return false;
            }
            return true;
        }

        internal static bool IsDoubleValidation(TextBox txt)
        {
            if (!double.TryParse(txt.Text, out double _))
            {
                txt.BackColor = Color.LightCoral;
                return false;
            }
            return true;
        }

        internal static void ResetColor(TextBox txt)
        {
            if (txt.BackColor == Color.LightCoral)
            {
                txt.BackColor = Color.White;
            }
        }
        internal static void ResetColor(RichTextBox txt)
        {
            if (txt.BackColor == Color.LightCoral)
            {
                txt.BackColor = Color.White;
            }
        }

        internal static bool EmptyFieldValidation(RichTextBox rtxt)
        {
            if (string.IsNullOrWhiteSpace(rtxt.Text))
            {
                rtxt.BackColor = Color.LightCoral;
                return true;
            }
            else
            {
                rtxt.BackColor = Color.White;
                return false;
            }
        }

        internal static bool DateOfCreationCheck(DateTime value)
        {
            if (value <= DateTime.Now)
            {
                return true;
            }
            return false;
        }

        internal static bool IsIntValidation(TextBox txt)
        {
            if (!int.TryParse(txt.Text, out int _))
            {
                txt.BackColor = Color.LightCoral;
                return false;
            }
            return true;
        }
    }
}
