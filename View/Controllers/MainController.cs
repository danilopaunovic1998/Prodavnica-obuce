using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.UserControls;

namespace View.Controllers
{
    public class MainController
    {
        internal void OpenUCAddFootwear(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCAddFootwear(new FootwearController()));
        }

        internal string WelcomeSE()
        {
            return Communication.Communication.Instance.LogedInStoreEmployee.FirstName;
        }

        internal void OpenUCAddSupplier(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCAddSupplier(new SupplierController()));
        }

        internal void OpenUCAddPremiumUser(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCAddPremiumUser(new PremiumUserController()));
        }

        internal void OpenUCFindPremiumUser(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCFindPremiumUser(new PremiumUserController()));
        }

        internal void OpeUCFindSupplier(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCFindSupplier(new SupplierController()));
        }

        internal void OpenUCFindFootwear(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCFindFootwear(new FootwearController()));
        }

        internal void OpenUCCreateNewOrder(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCCreateNewOrder(new OrderController()));
        }
    }
}
