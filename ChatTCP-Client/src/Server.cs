using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable CA1416 // Disable annoying squiggly lines informing about old Windows support

namespace ChatTCP
{
    public class Server
    {
        // Default amount of max users in a server
        public const int MAX_USERS = 64;

        // Server stuffs
        public int serverMaxUsers;
        public string serverIP;
        public string serverName;
        public User[] users = new User[MAX_USERS];
        public bool serverRunning;

        // Private server stuffs
        private TextBox serverOutput;

        // Network stuffs
        TcpListener listener;

        // Server constructor
        public Server(int serverMaxUsers, string serverIP, string serverName)
        {
            this.serverMaxUsers = serverMaxUsers;
            this.serverIP = serverIP;
            this.serverName = serverName;

            // Make the server properly
            MakeServer();
        }

        // Initialize the server
        public async void MakeServer()
        {
            // Make sure the server isn't already initialized
            if (listener != null)
            {
                MessageBox.Show(
                    "Server is already initialized.",
                    "Error - Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Make a new listener and start it
            listener = new TcpListener(IPAddress.Any, 27014);
            listener.Start();

            serverRunning = true;

            // Append any server output needed
            serverOutput = Program.mainClient.serverOutput;
            Program.mainClient.AppendServerOutputText($"<Server>: Server \"{serverName}\" initialized!");

            // Display misc. server outputs
            DisplayServerOutput();
        }

        // Output server stuffs
        public async void DisplayServerOutput()
        {
            while (serverRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                await Task.Run(() => HandleData(client));
            }
        }

        // Handle the data from a client
        public async Task HandleData(TcpClient client)
        {
            using (client)
            {
                Stream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.Default.GetString(buffer, 0, bytesRead);
                    Program.mainClient.AppendServerOutputText("Received: " + data);
                    MessageBox.Show("Received: " + data);
                }
            }
        }

        // Close the server
        public void CloseServer()
        {
            serverRunning = false;
            // Stop the listener
            listener.Stop();
        }
    }
}
