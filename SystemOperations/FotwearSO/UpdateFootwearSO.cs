using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.FotwearSO
{
    public class UpdateFootwearSO : CommonSystemOperation
    {
        public bool Result { get; private set; }
        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            Footwear footwear = (Footwear)objekat;
            footwear.ConditionForSearch = $"FootwearID = '{footwear.FootwearID}'";

            if (broker.Update(footwear) != 1)
            {
                Result = false;
            }
            else 
            {
                Result = true;
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
