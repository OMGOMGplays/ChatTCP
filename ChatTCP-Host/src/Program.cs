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
            Console.WriteLine("ChatTCP-Host server started!");

            // Handle clients connecting, and updating server list info
            while (active)
            {
                // Receive (primarily server) info from clients
                ReceiveInfoFromClients();

                // Send (server) info to every client connected to the host
                // The client should e.g. receive the index of which server is open and refer to that in their own list to get server info
                // !! This feels like it'll be very dodgy, if possible just have an array of Server classes !!
                for (int i = 0; i < openServers.Length; i++)
                {
                    // Send to every client the current server info
                    // If it's active, it's a 1
                    // If the server's inactive / a null value, it's a 0
                    SendToClients(openServers[i]);
                }
            }
        }

        // Receive info from connected clients
        private static void ReceiveInfoFromClients()
        {
            // Receive server info from clients
            // If the server's open, the server at the current index should be set to a 1, to indicate that it's active
            for (int i = 0; i < openServers.Length; i++)
            {
                openServers[i] = 0; // All are null for now, till I figure out how to send data properly
            }
        }

        // Send miscellaneous info to connected clients
        private static void SendToClients(object info)
        {

        }

        // Send server info to connected clients
        private static void SendToClients(int serverActive)
        {

        }
    }
}
