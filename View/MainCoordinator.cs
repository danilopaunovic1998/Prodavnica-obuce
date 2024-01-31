using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Controllers;

namespace View
{
    public class MainCoordinator
    {
        private static MainCoordinator instance;

        public static MainCoordinator Instance
        {
            get 
            {
                if (instance == null)
                    instance = new MainCoordinator();
                return instance;
            }
        }

        private MainCoordinator() { }

        public void OpenLogin()
        {
            new FrmLogin().ShowDialog();
        }

        internal void OpenViewPremiumUser()
        {
            new FrmViewPremiumUsers().ShowDialog();
        }

        internal void OpenViewSuppliers()
        {
            new FrmViewSuppliers().ShowDialog();
        }

        internal void OpenViewFootwear()
        {
            new FrmViewFootwear().ShowDialog();
        }

        internal void OpenUpdateFootwear(DataGridView dgvFootwear)
        {
            new FrmUpdateFootwear(dgvFootwear).ShowDialog();
        }

        internal void OpenAddOrderItem()
        {
            
        }

        internal void OpenAddOrderItem(OrderController orderController)
        {
            new FrmAddOrderItem(orderController).ShowDialog();
        }

        internal void OpenViewOrder(OrderController orderController)
        {
            new FrmViewOrder(orderController).ShowDialog();
        }
    }
}
