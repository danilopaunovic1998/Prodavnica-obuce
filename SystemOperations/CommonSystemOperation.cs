using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBBroker;
using Domen;

namespace SystemOperations //OK!!!!
{
    public abstract class CommonSystemOperation
    {
        protected Broker broker = new Broker();
        protected abstract void ExcecuteConcreteOperation(IEntity objekat);
        protected abstract void Validation(IEntity objekat);
        public void Execute(IEntity objekat)
        {
            try
            {
                Console.WriteLine("-----OBJEKAT JE TIPA: " + objekat.GetType().ToString());
                Validation(objekat);
                broker.OpenConnection();
                broker.BeginTransaction();
                ExcecuteConcreteOperation(objekat);
                broker.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                broker.Rollback();
            }
            finally 
            {
                broker.CloseConnection();
            }
        }
    }
}
