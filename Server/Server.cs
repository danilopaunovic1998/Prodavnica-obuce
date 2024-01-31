using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server //OK!
{
    public class Server //---- 1 pitanje -----
    {
        private Socket listener;
        private List<ClientHandler> clients = new List<ClientHandler>();
        private BindingList<StoreEmployee> storeEmployees = new BindingList<StoreEmployee>();

        public BindingList<StoreEmployee> StoreEmployees
        {
            get 
            {
                return storeEmployees;
            }
        }

        public Server()
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000));
        }

        public void Listen()
        {
            listener.Listen(5);
            bool end = false;
            while (!end)
            {
                try
                {
                    Socket client = listener.Accept();
                    ClientHandler handler = new ClientHandler(client, storeEmployees);
                    clients.Add(handler);
                    Thread thread = new Thread(handler.StartHandler);
                    //sta je ovo is Background????
                    thread.IsBackground = true;
                    thread.Start();
                }
                catch (Exception)
                {

                    Console.WriteLine("Kraj rada");
                    end = true;
                }
            
            }
        
        }
        internal void Stop()
        {
            listener.Close();
            foreach (ClientHandler c in clients)
            {
                c.Stop();
            }
            clients.Clear();
        }

    }
}
