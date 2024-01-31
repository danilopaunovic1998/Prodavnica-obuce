using ControllerAL;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler //---- 1 pitanje -----
    {
        private Socket clientSocket;
        private readonly BindingList<StoreEmployee> registeredStoreEmployees;

        private StoreEmployee logedInStoreEmployee;

        public ClientHandler(Socket client, BindingList<StoreEmployee> storeEmployees)
        {
            this.clientSocket = client;
            this.registeredStoreEmployees = storeEmployees;
        }


        public void StartHandler()
        {
            try
            {
                NetworkStream stream = new NetworkStream(clientSocket);
                BinaryFormatter formatter = new BinaryFormatter();
                while (true)
                {
                    Request request = (Request)formatter.Deserialize(stream);
                    Response response;
                    try
                    {
                        response = ProcessRequest(request);
                    }
                    catch (Exception ex)
                    {
                        response = new Response();
                        response.Signal = Signal.Error;
                        response.Message = ex.Message;
                    }
                    formatter.Serialize(stream, response);

                }
            }
            catch (IOException)
            {
                Console.WriteLine("Doslo je do prekida veze");
                //izbaci iz liste registrovanih radnika
                registeredStoreEmployees.Remove(logedInStoreEmployee);

            }
            catch (SerializationException)
            {
                //zasto je ista poruka opet????
                Console.WriteLine("Doslo je do prekida veze");
                //izbaci iz liste registrovanih radnika
                registeredStoreEmployees.Remove(logedInStoreEmployee);
            }
        }

        private Response ProcessRequest(Request request)
        {
            Response response = new Response();
            switch (request.Operation)
            {
                case Operation.Login:
                    response = Login((StoreEmployee)request.Objekat);
                    break;
                case Operation.AddNewSupplier:
                    response = AddNewSupplier((Supplier)request.Objekat);
                    break;
                case Operation.AddNewPremiumUser:
                    response = AddNewPremiumUser((PremiumUser)request.Objekat);
                    break;
                case Operation.FindPremiumUser:
                    response = FindPremiumUser((PremiumUser)request.Objekat);
                    break;
                case Operation.GetAllSuppliers:
                    response = GetAllSuppliers();
                    break;
                case Operation.AddNewFootwear:
                    response = AddNewFootwear((Footwear)request.Objekat);
                    break;
                case Operation.FindSuppliers:
                    response = FindSuppliers((Supplier)request.Objekat);
                    break;
                case Operation.FindFootwear:
                    response = FindFootwear((Footwear)request.Objekat);
                    break;
                case Operation.DeleteFootwear:
                    response = DeleteFootwear((Footwear)request.Objekat);
                    break;
                case Operation.UpdateFootwear:
                    response = UpdateFootwear((Footwear)request.Objekat);
                    break;
                case Operation.CreateOrder:
                    response = CreateOrder((Order)request.Objekat);
                    break;
                case Operation.FindOrders:
                    response = FindOrders((Order)request.Objekat);
                    break;
                case Operation.GetOrderItems:
                    response = GetOrderItems((Order)request.Objekat);
                    break;
                default:
                    break;
            }
            return response;
        }

        private Response GetOrderItems(Order objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.GetOrderItems(objekat);
            Order orders = (Order)response.Objekat;

            if (orders == null || orders.OrderItems == null)
            {
                response.Signal = Signal.Error;
                response.Message = "Trazene porudzbine ne postoje";
            }
            else
            {
                response.Signal = Signal.Ok;
                response.Message = "Sistem je pronasao porudzbinu i njegove stavke ";
            }
            return response;
        }

        private Response FindOrders(Order objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.FindOrders(objekat);
            List<Order> orders = (List<Order>)response.Objekat;

            if (orders == null)
            {
                response.Signal = Signal.Error;
                response.Message = "Trazene porudzbine ne postoje";
            }
            else
            {
                response.Signal = Signal.Ok;
                response.Message = "Sistem je pronasao porudzbine";
            }
            return response;
        }

        private Response CreateOrder(Order objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.SaveOrder(objekat);

            if ((bool)response.Objekat == false)
            {
                response.Signal = Signal.Error;
            }
            else
            {
                response.Signal = Signal.Ok;
            }

            return response;
        }

        private Response UpdateFootwear(Footwear objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.UpdateFootwear(objekat);
            
            if ((bool)response.Objekat == false)
            {
                response.Signal = Signal.Error;
            }
            else
            {
                response.Signal = Signal.Ok;
            }

            return response;
        }

        private Response DeleteFootwear(Footwear objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.DeleteFootwear(objekat);

            if ((bool)response.Objekat == false)
            {
                response.Signal = Signal.Error;
            }
            else
            {
                response.Signal = Signal.Ok;
            }

            return response;
        }

        private Response FindFootwear(Footwear objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.FindFootwear(objekat);
            List<Footwear> f = (List<Footwear>)response.Objekat;

            if (f == null)
            {
                response.Signal = Signal.Error;
                response.Message = "Trazena obuca ne postoji";
            }
            else
            {
                response.Signal = Signal.Ok;
                response.Message = "Sistem je pronasao obucu";
            }
            return response;
        }

        private Response FindSuppliers(Supplier objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.FindSuppliers(objekat);
            List<Supplier> s = (List<Supplier>)response.Objekat;

            if (s == null)
            {
                response.Signal = Signal.Error;
                response.Message = "Trazeni dobavljac ne postoji";
            }
            else
            {
                response.Signal = Signal.Ok;
                response.Message = "Sistem je pronasao dobavljaca";
            }
            return response;
        }

        private Response AddNewFootwear(Footwear objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.AddNewFootwear(objekat);

            if ((bool)response.Objekat == false)
            {
                response.Signal = Signal.Error;
                response.Message = "Neuspesno cuvanje obuce";
            }
            else
            {
                response.Signal = Signal.Ok;
            }
            return response;
        }

        private Response GetAllSuppliers()
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.GetAllSuppliers();

            if (response.Objekat == null)
            {
                response.Signal = Signal.Error;
            }
            else
            {
                response.Signal = Signal.Ok;
            }
            return response;
        }

        private Response AddNewPremiumUser(PremiumUser objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.AddNewPremiumUser(objekat);

            if ((bool)response.Objekat == false)
            {
                response.Signal = Signal.Error;
                response.Message = "Neuspesno cuvanje premium user-a";
            }
            else 
            {
                response.Signal = Signal.Ok;
            }
            return response;
        }

        private Response AddNewSupplier(Supplier objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.AddNewSupplier(objekat);

            if ((bool)response.Objekat == false)
            {
                response.Signal = Signal.Error;
                response.Message = "Neuspesno cuvanje dobavljaca!";
            }
            else
            {
                response.Signal = Signal.Ok;
            }
            return response;


        }

        private Response Login(StoreEmployee objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.Login(objekat);
            StoreEmployee storeEmployee = (StoreEmployee)response.Objekat;

            if (storeEmployee == null)
            {
                response.Signal = Signal.Error;
                response.Message = "Prodavac nije pronadjen!";
            }
            else if (registeredStoreEmployees.Any(rse => rse.StoreEmployeeID == storeEmployee.StoreEmployeeID))
            {
                response.Signal = Signal.AlreadyLogedIn;
                response.Message = "Prodavac je vec prijavljen";
            }
            else 
            {
                response.Signal = Signal.Ok;
                response.Message = "Pronadjen je prodavac sa unetim kredencijalima!";
                logedInStoreEmployee = storeEmployee;
                registeredStoreEmployees.Add(storeEmployee);
            }
            return response;
        }
        private Response FindPremiumUser(PremiumUser objekat)
        {
            Response response = new Response();
            response.Objekat = Controller.Instance.FindPremiumUser(objekat);
            List<PremiumUser> p = (List<PremiumUser>)response.Objekat;

            if (p == null)
            {
                response.Signal = Signal.Error;
                response.Message = "Trazeni premium user ne postoji";
            }
            else 
            {
                response.Signal = Signal.Ok;
                response.Message = "Sistem je pronasao premium user-a";
            }
            return response;
        }

        internal void Stop()
        {
            clientSocket.Close();
        }
    }
}
