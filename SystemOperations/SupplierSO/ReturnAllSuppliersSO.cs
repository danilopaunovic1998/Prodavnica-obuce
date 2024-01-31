using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.SupplierSO
{
    public class ReturnAllSuppliersSO : CommonSystemOperation
    {
        public object SupplierList { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            Supplier s = (Supplier)objekat;
            s.ConditionForSearch = "";

            var x = broker.GetAll(s);

            if (x == null)
            {
                SupplierList = null;
            }
            else
            {
                SupplierList = new List<Supplier>(x.Cast<Supplier>());
            }
        }

        protected override void Validation(IEntity objekat)
        {
            if (!(objekat is Supplier))
            {
                throw new ArgumentException();
            }
        }
    }
}
