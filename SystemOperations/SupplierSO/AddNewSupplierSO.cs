using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.SupplierSO
{
    public class AddNewSupplierSO : CommonSystemOperation
    {
        public bool Result { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            Supplier supplier = (Supplier)objekat;
            supplier.ConditionForSearch = $"CompanyName = '{supplier.CompanyName}' and NameOfSaleEmployee = '{supplier.NameOfSaleEmployee}'";

            Supplier s = (Supplier)broker.SelectOne(supplier);

            if (s == null)
            {
                if (broker.Insert(supplier) != 1)
                {
                    Result = false;
                }
                else 
                {
                    Result = true;
                }
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
