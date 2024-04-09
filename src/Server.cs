using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatTCP
{
    internal class Server
    {
        public const int MAX_USERS = 64;

        private TcpListener tcpListener;
        private IPEndPoint ipEndPoint;

        public int maxUsers;
        public string ipAddr;
        public string serverName;
        public User[] users = new User[MAX_USERS];
        public bool running;

        public Server(int maxUsers, string ipAddr, string serverName)
        {
            this.maxUsers = maxUsers;
            this.ipAddr = ipAddr;
            this.serverName = serverName;

            MakeServer();

            running = true;
        }

        // Initialize the server
        public void MakeServer()
        {
            IPAddress ipAddress = IPAddress.Parse(ipAddr);
            ipEndPoint = new IPEndPoint(ipAddress, 27015);
            tcpListener = new TcpListener(ipEndPoint);

            tcpListener.Start(maxUsers);
        }

        // Have the input User join the server
        public async void JoinServer(User user)
        {
            try
            {
                while (running)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                }
            }
            catch (SocketException)
            {
                throw;
            }

            user.currServer = this;
            users.Append(user);
            Console.WriteLine($"User \"{user.username}\" has joined the server.");
        }

        // Close the server
        public void CloseServer()
        {
            tcpListener.Stop();
            running = false;
        }
    }
}
