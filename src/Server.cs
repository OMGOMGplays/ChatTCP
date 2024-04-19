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
        // Default amount of max users in a server
        public const int MAX_USERS = 64;

        // Server stuffs
        public int maxUsers;
        public string ipAddr;
        public string serverName;
        public User[] users = new User[MAX_USERS];

        // Network stuffs
        Socket socket;

        public Server(int maxUsers, string ipAddr, string serverName)
        {
            this.maxUsers = maxUsers;
            this.ipAddr = ipAddr;
            this.serverName = serverName;

            // Make the server properly
            MakeServer();
        }

        // Initialize the server
        public void MakeServer()
        {
            // Create the socket
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the IP address
            socket.Bind(new IPEndPoint(IPAddress.Parse(ipAddr), 0));

            // Start listening for connections
            socket.Listen();
        }

        // Close the server
        public void CloseServer()
        {
            // Close the socket
            socket.Close();
            socket.Shutdown(SocketShutdown.Both);
            socket = null;
        }

        // Have the input User join the server
        public void JoinServer(User user)
        {
            user.currServer = this;
            users.Append(user);
            Console.WriteLine($"User \"{user.username}\" has joined the server.");
        }
    }
}
