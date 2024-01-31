using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.StoreEmployeeSO
{
    public class LogInSO : CommonSystemOperation
    {
        public StoreEmployee StoreEmployee { get; set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            StoreEmployee = (StoreEmployee)broker.SelectOne(objekat);
        }

        protected override void Validation(IEntity objekat)
        {
            if (!(objekat is StoreEmployee))
            {
                throw new ArgumentException();
            }
        }
    }
}
