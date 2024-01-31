using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.FotwearSO
{
    public class FindFootwearSO : CommonSystemOperation
    {
        public object FootwearList { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            var x = broker.GetAll(objekat);
            if (x == null)
            {
                FootwearList = null;
            }
            else
            {
                FootwearList = new List<Footwear>(x.Cast<Footwear>());
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
