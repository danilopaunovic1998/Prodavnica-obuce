using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.OrderSO
{
    public class SaveOrderSO : CommonSystemOperation
    {
        public bool Result { get; private set; }

        protected override void ExcecuteConcreteOperation(IEntity objekat)
        {
            //ubaci porudzbinu
            Order order = (Order)objekat;
            if (broker.Insert(order) != 1)
            {
                Result = false;
            }
            else 
            {
                Result = true;
            }
            //ubaci stavke
            int br = broker.GetId(objekat);
            
            if (Result == true)
            {
                foreach (OrderItem oi in order.OrderItems)
                {
                    try
                    {
                        oi.Order = order;
                        oi.Order.OrderID = br;
                        if (broker.Insert(oi) != 1)
                        {
                            Result = false;
                            //da li treba prekinuti
                            break;

                        }
                        else
                        {
                            Result = true;
                        }
                    }
                    catch 
                    {
                        Result = false;
                        throw;
                    }
                }
            
            }

            //apdejtuj premiumUsera
            if (Result == true)
            {
                PremiumUser p = (PremiumUser)order.PremiumUser;
                p.ConditionForSearch = $"PremiumUserID = '{p.PremiumUserID}'";
                if (broker.Update(p) != 1)
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
            if (!(objekat is Order))
            {
                throw new ArgumentException();
            }
        }
    }
}
