using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
using SystemOperations.FotwearSO;
using SystemOperations.PremiumUserSO;
using SystemOperations.StoreEmployeeSO;
using SystemOperations.SupplierSO;
using SystemOperations.OrderSO;

namespace ControllerAL
{
    public class Controller
    {
        //zasto je Controller singleton???

        private static Controller instance;
        private Controller() { }

        public static Controller Instance
        {

            get 
            {
                if (instance == null)
                    instance = new Controller();
                return instance;
            }
        
        }

        public object Login(StoreEmployee objekat)
        {
            CommonSystemOperation operation = new LogInSO();
            operation.Execute(objekat);
            return ((LogInSO)operation).StoreEmployee;
        }

        public object AddNewSupplier(Supplier objekat)
        {
            CommonSystemOperation operation = new AddNewSupplierSO();
            operation.Execute(objekat);
            return ((AddNewSupplierSO)operation).Result;
        }

        public object AddNewPremiumUser(PremiumUser objekat)
        {
            CommonSystemOperation operation = new AddNewPremiumUserSO();
            operation.Execute(objekat);
            return ((AddNewPremiumUserSO)operation).Result;
        }

        public object FindPremiumUser(PremiumUser objekat)
        {
            CommonSystemOperation operation = new FindPremiumUserSO();
            operation.Execute(objekat);
            return ((FindPremiumUserSO)operation).premiumUser;
        }

        public object GetAllSuppliers()
        {
            CommonSystemOperation operation = new ReturnAllSuppliersSO();
            operation.Execute(new Supplier());
            return ((ReturnAllSuppliersSO)operation).SupplierList;
        }

        public object AddNewFootwear(Footwear objekat)
        {
            CommonSystemOperation operation = new AddNewFootwearSO();
            operation.Execute(objekat);
            return ((AddNewFootwearSO)operation).Result;
        }

        public object FindSuppliers(Supplier objekat)
        {
            CommonSystemOperation operation = new FindSuppliersSO();
            operation.Execute(objekat);
            return ((FindSuppliersSO)operation).SupplierList;
        }

        public object FindFootwear(Footwear objekat)
        {
            CommonSystemOperation operation = new FindFootwearSO();
            operation.Execute(objekat);
            return ((FindFootwearSO)operation).FootwearList;
        }

        public object DeleteFootwear(Footwear objekat)
        {
            CommonSystemOperation operation = new DeleteFootwearSO();
            operation.Execute(objekat);
            return ((DeleteFootwearSO)operation).Result;
        }

        public object UpdateFootwear(Footwear objekat)
        {
            CommonSystemOperation operation = new UpdateFootwearSO();
            operation.Execute(objekat);
            return ((UpdateFootwearSO)operation).Result;
        }

        public object SaveOrder(Order objekat)
        {
            CommonSystemOperation operation = new SaveOrderSO();
            operation.Execute(objekat);
            return ((SaveOrderSO)operation).Result;
        }

        public object FindOrders(Order objekat)
        {
            CommonSystemOperation operation = new FindOrdersSO();
            operation.Execute(objekat);
            return ((FindOrdersSO)operation).OrderList;
        }

        public object GetOrderItems(Order objekat)
        {
            CommonSystemOperation operation = new LoadOrderSO();
            operation.Execute(objekat);
            return ((LoadOrderSO)operation).Order;
        }


        //Odavde se zapocinju f-je!!!
    }
}
