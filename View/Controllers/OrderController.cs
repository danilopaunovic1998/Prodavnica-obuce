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
    public  class OrderController
    {
        BindingList<Order> FoundOrders { get; set; }
        BindingList<OrderItem> OrderItems { get; set; }
        Order selectedOrder { get; set; }
        public OrderController()
        {
            OrderItems = new BindingList<OrderItem>();
            FoundOrders = new BindingList<Order>();
        
        }

        internal void RefreshDataGridView(DataGridView dgvOrderItems)
        {
            dgvOrderItems.DataSource = null;
            dgvOrderItems.DataSource = OrderItems;
        }

        internal void GetOrderItems(DataGridView dgvOrderItems, TextBox txtAmount, TextBox txtDate, TextBox txtPremiumUser)
        {
            if (Communication.Communication.Instance.GetOrderItems(selectedOrder))
            {
                Communication.Communication.Instance.FillViewOrder(dgvOrderItems, txtAmount, txtPremiumUser, txtDate);
            }
            else
            {
                MessageBox.Show("Niste izabrali red");
                return;
            }
        }

        internal void AddOrderItemToList(Supplier supplier, Footwear footwear, int quantity, int size)
        {
            OrderItem o = new OrderItem()
            {
                Quantity = quantity,
                Size = size,
                Supplier = supplier,
                Footwear = footwear

            };
            OrderItems.Add(o);
        }

        internal void RefreshAmount(TextBox txtAmount)
        {
            double amount = 0;
            foreach (OrderItem oi in OrderItems)
            {
                amount += (oi.Footwear.Price * oi.Quantity);
            }

            txtAmount.Text = amount.ToString();
        }

        internal void RemoveOrderItem(DataGridView dgvOrderItems)
        {
            OrderItem i = (OrderItem)dgvOrderItems.SelectedRows[0].DataBoundItem;
            OrderItems.Remove(i);
        }

        internal void SaveOrder(DateTimePicker dtpDateOfCreation, TextBox txtPremiumUser, CheckBox chkBonus, CheckBox ckbPaid, TextBox txtAmount)
        {
            if (ValidationHelpers.EmptyFieldValidation(txtPremiumUser))
            {
                MessageBox.Show("Niste izabrali premijum korisnika");
                return;
            }
            if (!ValidationHelpers.DateOfCreationCheck(dtpDateOfCreation.Value))
            {
                MessageBox.Show("Datum kreiranja ne moze da bude u buducnosti");
                return;
            }

            Order order = new Order();
            if (ckbPaid.Checked)
            {
                order.isPaid = true;
                order.PaidDate = DateTime.Now;
            }
            else
            {
                order.isPaid = false;
                order.PaidDate = DateTime.MaxValue;
            }
            order.CreatedDate = dtpDateOfCreation.Value;
            order.PremiumUser = Communication.Communication.Instance.selectedPremiumUser;
            if (chkBonus.Checked)
            {
                order.Amount = double.Parse(txtAmount.Text) * (1 - order.PremiumUser.Bonus);
                order.PremiumUser.Bonus = 0;
            }
            else 
            {
                order.Amount = double.Parse(txtAmount.Text);
                order.PremiumUser.Bonus += (order.Amount / 1000000);
            }
            order.StoreEmployee = Communication.Communication.Instance.LogedInStoreEmployee;
            order.OrderItems = OrderItems.ToList<OrderItem>();

            if (Communication.Communication.Instance.SaveOrder(order))
            {
                MessageBox.Show("Uspesno ste sacuvali porudzbinu!");
            }
            else
            {
                MessageBox.Show("Doslo je do greske prilikom cuvanja porudzbine!");
            }
        }

        internal void SetOrder(object dataBoundItem)
        {
            selectedOrder = (Order)dataBoundItem;
        }

        internal void DeleteOrder(DataGridView dgvOrders)
        {
            if (dgvOrders.SelectedRows[0] == null)
            {
                return;
            }
            DataGridViewRow row = dgvOrders.SelectedRows[0];
            Order o = (Order)row.DataBoundItem;
            if (Communication.Communication.Instance.DeleteOrder(o))
            {
                FoundOrders.Remove(o);
                RefreshDataGridViewOrder(dgvOrders);
            }
        }

        private void RefreshDataGridViewOrder(DataGridView dgvOrders)
        {
            dgvOrders.DataSource = null;
            dgvOrders.DataSource = FoundOrders;
        }

        internal void FindOrders(DateTimePicker dtpDateCriteria, CheckBox chkbIsPaid, DataGridView dgvOrders, TextBox txtPremiumUser)
        {
            Order order;
            if (!ValidationHelpers.EmptyFieldValidation(txtPremiumUser))
            {
                order = new Order
                {
                    CreatedDate = dtpDateCriteria.Value,
                    PremiumUser = Communication.Communication.Instance.selectedPremiumUser,
                    isPaid = chkbIsPaid.Checked,

                };
                order.ConditionForSearch = $"o.PremiumUserID = '{order.PremiumUser.PremiumUserID}' and o.Paid = '{order.isPaid}' and o.CreatedDate <= '{order.CreatedDate}'";
            }
            else
            {
                order = new Order 
                {
                    CreatedDate = dtpDateCriteria.Value,
                    isPaid = chkbIsPaid.Checked,
                };
                order.ConditionForSearch = $"o.Paid = '{order.isPaid}' and o.CreatedDate <= '{order.CreatedDate}'";
            }
            
            if ((List<Order>)Communication.Communication.Instance.ReturnFoundOrders(order) == null)
            {
                MessageBox.Show("Ne postoje porudzbine sa zadatim vrednostima!\nProbajte ponovo!");
                return;
            }
            else
                dgvOrders.DataSource = new BindingList<Order>((List<Order>)Communication.Communication.Instance.ReturnFoundOrders(order));
        }
    }
}
