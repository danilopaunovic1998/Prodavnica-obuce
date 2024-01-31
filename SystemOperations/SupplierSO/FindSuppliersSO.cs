using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.SupplierSO
{
    public class FindSuppliersSO : CommonSystemOperation
    {
        public List<Supplier> SupplierList { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            var x = broker.GetAll(objekat);
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
