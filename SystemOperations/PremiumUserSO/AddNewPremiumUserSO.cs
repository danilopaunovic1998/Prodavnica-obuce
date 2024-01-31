using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.PremiumUserSO
{
    public class AddNewPremiumUserSO : CommonSystemOperation
    {
        public bool Result { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            //proveri format za date of birth;
            PremiumUser premiumUser = (PremiumUser)objekat;
            premiumUser.ConditionForSearch = $" FirstName = '{premiumUser.FirstName}' " +
                $"and LastName = '{premiumUser.LastName}' and DateOfBirth = '{premiumUser.DateOfBirth}'";

            PremiumUser p = (PremiumUser)broker.SelectOne(premiumUser);

            if (p == null)
            {
                if (broker.Insert(premiumUser) != 1)
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
            if (!(objekat is PremiumUser))
            {
                throw new ArgumentException();
            }
        }
    }
}
