using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatTCP.Host
{
    // This is the ChatTCP-Host server, every client should try to connect to this upon booting up
    // If the host isn't active, tough luck, you won't be able to use the client
    // This is primarily to send server info amongst every client
    internal class Program
    {
        // !! IF THE SERVER ARRAY SIZE IS CHANGED HERE, CHANGE IT IN THE CLIENT TOO !!
        private static Server[] openServers = new Server[2048];

        // Used to handle server info
        private static TcpListener listener;

        // Amount of connected clients
        private static TcpClient[] clients = new TcpClient[2048];

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
            Console.WriteLine("ChatTCP-Host server started!\n");

            // Handle clients connecting, and updating server list info
            while (active)
            {
                try
                {
                    // Accept clients
                    TcpClient client = listener.AcceptTcpClient();

                    // Add the client to the list
                    for (int i = 0; i < clients.Length; i++)
                    {
                        if (clients[i] == null)
                        {
                            clients[i] = client;
                            break;
                        }
                    }

                    Console.WriteLine("Client connected!");
                }
                catch (Exception e)
                {
                    // Just incase we get an error...
                    Console.Error.WriteLine($"Error accepting client!\n{e.Message}");
                    Environment.Exit(-1);
                }

                foreach (TcpClient client in clients)
                {
                    // Skip over any null clients
                    if (client == null)
                    {
                        continue;
                    }

                    byte[] serverBuffer = new byte[openServers.Length];

                    client.GetStream().Read(serverBuffer, 0, serverBuffer.Length);
                    Console.WriteLine("Wrote server to client!");
                }
            }
        }
    }
}