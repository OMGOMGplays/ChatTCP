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
    // This is primarily to send server info amongst every client
    // If the host isn't active, tough luck, you won't be able to use the client
    internal class Program
    {
        // !! IF THE SERVER ARRAY SIZE IS CHANGED HERE, CHANGE IT IN THE CLIENT TOO !!
        private static Server[] openServers = new Server[2048];

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
                // Accept clients
                TcpClient connectedClient = listener.AcceptTcpClient();
                Console.WriteLine("Client connected!");

                // If the client has data to send, receive it
                if (connectedClient.ReceiveBufferSize > 0)
                {
                    Stream stream = connectedClient.GetStream();
                    byte[] buffer = new byte[connectedClient.ReceiveBufferSize];

                    Console.WriteLine($"Receiving new server info from client(s)...");

                    for (int i = 0; i < openServers.Length; i++)
                    {
                        Server currServer = openServers[i];

                        // Set the openServers list appropriately
                        currServer = stream.Read(buffer, 0, buffer.Length) != 0 ? new Server() : null;

                        if (currServer != null)
                        {
                            // Get the server's info from the buffer
                            currServer.serverIP = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                            currServer.serverMaxUsers = stream.Read(buffer, 0, buffer.Length);
                            currServer.serverName = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                        }

                        // Show which servers are now open at which index
                        Console.WriteLine($"Server info of the server at the index of {i + 1} is:\n" +
                            $"  IP: {currServer?.serverIP}\n" +
                            $"  Max Users: {currServer?.serverMaxUsers}\n" +
                            $"  Name: \"{currServer?.serverName}\"\n");
                    }
                }


            }
        }
    }
}
