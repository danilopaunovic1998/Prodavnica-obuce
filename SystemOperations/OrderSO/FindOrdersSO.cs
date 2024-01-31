using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.OrderSO
{
    public class FindOrdersSO : CommonSystemOperation
    {
        public object OrderList { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {

            var x = broker.GetAll(objekat);
            if (x == null)
            {
                OrderList = null;
            }
            else
            {
                OrderList = new List<Order>(x.Cast<Order>());
            }

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
