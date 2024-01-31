using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.PremiumUserSO
{
    public class FindPremiumUserSO : CommonSystemOperation
    {
        
        public List<PremiumUser> premiumUser { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            var x = broker.GetAll(objekat);
            if (x == null)
            {
                premiumUser = null;
            }
            else 
            {
                premiumUser = new List<PremiumUser>(x.Cast<PremiumUser>());
            }
            
        }

        protected override void Validation(IEntity objekat)
        {
            if (!(objekat is PremiumUser))
            {
                throw new ArgumentException();
            }
        }
    }
}
