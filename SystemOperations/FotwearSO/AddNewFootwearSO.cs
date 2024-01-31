using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.FotwearSO
{
    public class AddNewFootwearSO : CommonSystemOperation
    {
        public bool Result { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            //proveri format za date of birth;
            Footwear footwear = (Footwear)objekat;
            footwear.ConditionForSearch = $"f.Model = '{footwear.Model}' " +
                                          $"and f.Brand = '{footwear.Brand}' " +
                                          $"and f.SupplierID = '{footwear.Supplier.SupplierID}'";

            Footwear f = (Footwear)broker.SelectOne(footwear);

            if (f == null)
            {
                if (broker.Insert(footwear) != 1)
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
            if (!(objekat is Footwear))
            {
                throw new ArgumentException();
            }
        }
    }
}
