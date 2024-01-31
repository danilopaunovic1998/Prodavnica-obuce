using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.OrderSO
{
    public class LoadOrderSO : CommonSystemOperation
    {
        public Order Order { get; private set; }
        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            Order o = (Order)objekat;
            OrderItem oi = new OrderItem();
            oi.Order = o;
            oi.ConditionForSearch = $"oi.OrderID = '{oi.Order.OrderID}'";

            o.ConditionForSearch = $"o.OrderID = '{o.OrderID}'";
            Order = (Order)broker.SelectOne(objekat);
            var x = broker.GetAll(oi);
            

            if (x == null)
                Order.OrderItems = null;
            else
                Order.OrderItems = new List<OrderItem>(x.Cast<OrderItem>());
        }

        protected override void Validation(IEntity objekat)
        {
            if (!(objekat is Order))
            {
                throw new ArgumentException();
            }
        }
    }
}
