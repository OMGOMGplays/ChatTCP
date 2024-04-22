using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using ChatTCP;

namespace ChatTCP.Host
{
    // This is the ChatTCP-Host server, every client should try to connect to this upon booting up
    // This is primarily to send server info amongst every client
    // If the host isn't active, tough luck, you won't be able to use the client
    internal class Program
    {
        // !! IF THE SERVER ARRAY SIZE IS CHANGED HERE, CHANGE IT IN THE CLIENT TOO !!
        private static int[] openServers = new int[2048];

        // Used to handle server stuffs
        private static TcpListener listener;

        // Start the program
        public static void Main()
        {
            // The application is active, so receive and send data appropriately
            bool active = true;

            // Inform the user that the server is starting up
            Console.WriteLine("Starting ChatTCP-Host server...");

            // Find a more suitable port than 27015
            // (Preferably one that works with my school laptop too)
            listener = new TcpListener(IPAddress.Any, 27015);
            listener.Start();

            // The server has been initialized!
            Console.WriteLine("ChatTCP-Host server started!" + Environment.NewLine);

            // Handle clients connecting, and updating server list info
            while (active)
            {
                TcpClient connectedClient = listener.AcceptTcpClient();
                Console.WriteLine("Client connected!");
            }
        }
    }
}
