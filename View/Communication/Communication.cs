using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Communication
{
    public class Communication //ima jos da se radi
    {
        //zasto je communication instance???
        private static Communication instance;

        private Communication() { }


        public static Communication Instance
        {
            get 
            {
                if (instance == null)
                    instance = new Communication();
                return instance;
            }
        }
        //---------------------------------------------

        //atributi-----------------------------------

        private Socket clientSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();


        public StoreEmployee LogedInStoreEmployee;
        public PremiumUser selectedPremiumUser;


        public List<PremiumUser> premiumUsersFound;

        public Order selectedOrder;
        public List<Supplier> suppliersFound;
        public List<Footwear> footwearsFound;

        internal void GetSelectedPremiumUser(TextBox txtPremiumUser)
        {
            txtPremiumUser.Text = selectedPremiumUser.ToString();
        }

        //--------------------------------------------

        public void Connect()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                return;
            }
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000));
            stream = new NetworkStream(clientSocket);
        }


        internal void Disconect()
        {
            clientSocket.Close();
            clientSocket = null;
        }


        internal StoreEmployee Login(string username, string password)
        {
            try
            {
                StoreEmployee storeEmployee = new StoreEmployee
                {
                    Username = username,
                    Password = password
                };
                Request request = new Request 
                { 
                    Objekat = storeEmployee, 
                    Operation = Operation.Login
                };
                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani sa serverom!");
                    System.Windows.Forms.Application.Exit();
                }
                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    LogedInStoreEmployee = (StoreEmployee)response.Objekat;
                    return (StoreEmployee)response.Objekat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }

        internal bool SaveOrder(Order order)
        {
            try
            {

                Request request = new Request
                {
                    Operation = Operation.CreateOrder,
                    Objekat = order
                };
                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }
                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    return true;
                }
                else
                {
                    //proveri da li je ovo praza mb???
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }

        internal void FillViewOrder(DataGridView dgvOrderItems, TextBox txtAmount, TextBox txtPremiumUser, TextBox txtDate)
        {
            dgvOrderItems.DataSource = new BindingList<OrderItem>(selectedOrder.OrderItems);
            txtAmount.Text = selectedOrder.Amount.ToString();
            txtPremiumUser.Text = selectedOrder.PremiumUser.ToString();
            txtDate.Text = selectedOrder.CreatedDate.ToString();
        }
        internal bool GetOrderItems(Order selectedOrder)
        {
            try
            {
                Request request = new Request
                {
                    Operation = Operation.GetOrderItems,
                    Objekat = selectedOrder
                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Niste povezani sa serverom!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);
                if (response.Signal == Signal.Ok)
                {
                    this.selectedOrder = (Order)response.Objekat;
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal bool DeleteOrder(Order o)
        {
            throw new NotImplementedException();
        }

        internal object ReturnFoundOrders(Order order)
        {
            try
            {
                Request request = new Request
                {
                    Operation = Operation.FindOrders,
                    Objekat = order
                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Niste povezani sa serverom!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);
                if (response.Signal == Signal.Ok)
                {
                    return response.Objekat;
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void SetFoundPremiumUser(PremiumUser foundPremiumUser)
        {
            this.selectedPremiumUser = foundPremiumUser;
        }

        internal bool FindSupplier(Supplier supplier)
        {
            try
            {
                Request request = new Request
                {
                    Operation = Operation.FindSuppliers,
                    Objekat = supplier

                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    suppliersFound = (List<Supplier>)response.Objekat;
                    return true;
                }
                else
                {
                    //proveri da li je ovo praza mb???
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }

        internal bool FindFootwear(Footwear footwear)
        {
            try
            {
                Request request = new Request
                {
                    Operation = Operation.FindFootwear,
                    Objekat = footwear

                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    footwearsFound = (List<Footwear>)response.Objekat;
                    return true;
                }
                else
                {
                    //proveri da li je ovo praza mb???
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }

      
        internal bool UpdateFootwear(Footwear footwear)
        {
            try
            {
                Request request = new Request
                {
                    Operation = Operation.UpdateFootwear,
                    Objekat = footwear
                };
                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }
                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    return true;
                }
                else
                {
                    //proveri da li je ovo praza mb???
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }

        internal bool AddNewFootwear(Footwear footwear)
        {
            try
            {

                Request request = new Request
                {
                    Operation = Operation.AddNewFootwear,
                    Objekat = footwear
                };
                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }
                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    return true;
                }
                else
                {
                    //proveri da li je ovo praza mb???
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }

        internal object ReturnAllSuppliers()
        {
            try
            {   
                Request request = new Request
                {
                    Operation = Operation.GetAllSuppliers,
                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Niste povezani sa serverom!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);
                if (response.Signal == Signal.Ok)
                {
                    return response.Objekat;
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal bool FindPremiumUser(PremiumUser premiumUser)
        {
            try
            {
                Request request = new Request
                {
                    Operation = Operation.FindPremiumUser,
                    Objekat = premiumUser
                
                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);
                
                if (response.Signal == Signal.Ok)
                {
                    premiumUsersFound = (List<PremiumUser>)response.Objekat;
                    return true;
                }
                else
                {
                    //proveri da li je ovo praza mb???
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }

        internal bool AddNewSupplier(Supplier supplier)
        {
            try
            {

                Request request = new Request
                {
                    Operation = Operation.AddNewSupplier,
                    Objekat = supplier
                };
                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }
                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    return true;
                }
                else
                {
                    //proveri da li je ovo praza mb???
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }
        internal bool AddNewPremiumUser(PremiumUser premiumUser)
        {
            try
            {
                Request request = new Request
                {
                    Operation = Operation.AddNewPremiumUser,
                    Objekat = premiumUser

                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Niste povezani na server!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(response.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
        }
        internal bool DeleteFootwear(Footwear f)
        {

            try
            {
                Request request = new Request
                {
                    Objekat = f,
                    Operation = Operation.DeleteFootwear
                };

                try
                {
                    formatter.Serialize(stream, request);
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Niste povezani sa serverom!");
                    System.Windows.Forms.Application.Exit();
                }

                Response response = (Response)formatter.Deserialize(stream);

                if (response.Signal == Signal.Ok)
                {
                    return true;
                }
                else 
                {
                    return false;
                }



            }
            catch(Exception ex) 
            {
                Console.WriteLine(">>" + ex.Message);
                throw;
            }
           
        }
        //ostale funkcije...
    }

}

