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
    internal class Server
    {
        // Default amount of max users in a server
        public const int MAX_USERS = 64;

        // Server stuffs
        public int maxUsers;
        public IPAddress ipAddr;
        public string serverName;
        public User[] users = new User[MAX_USERS];

        private bool serverRunning;
        private TextBox serverOutput;

        // Network stuffs
        TcpListener listener;

        public Server(int maxUsers, IPAddress ipAddr, string serverName)
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
            if (listener != null)
            {
                Console.WriteLine("Server already exists.");
                return;
            }

            listener = new TcpListener(IPAddress.Any, 8000);
            listener.Start();

            serverRunning = true;

            serverOutput = MainClient.serverOutput;
            AppendServerOutputText("Server: Server initialized!");

            DisplayServerOutput();
        }

        public async Task DisplayServerOutput()
        {
            while (serverRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                await Task.Run(() => HandleData(client));
            }
        }

        public async Task HandleData(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    AppendServerOutputText("Received: " + data);
                }
            }
        }

        public void AppendServerOutputText(string input)
        {
            if (MainClient.serverOutput.InvokeRequired)
            {
                MainClient.serverOutput.BeginInvoke(new Action<string>(AppendServerOutputText), input);
            }
            else
            {
                MainClient.serverOutput.AppendText(input + Environment.NewLine);
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
