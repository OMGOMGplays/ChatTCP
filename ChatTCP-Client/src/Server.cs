﻿using System;
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
        public int maxUsers;
        public string ipAddr;
        public string serverName;
        public User[] users = new User[MAX_USERS];

        // Private server stuffs
        private bool serverRunning;
        private TextBox serverOutput;

        // Network stuffs
        TcpListener listener;

        // Server constructor
        public Server(int maxUsers, string ipAddr, string serverName)
        {
            this.maxUsers = maxUsers;
            this.ipAddr = ipAddr;
            this.serverName = serverName;

            // Make the server properly
            MakeServer();
        }

        // Initialize the server
        public async void MakeServer()
        {
            if (listener != null)
            {
                MessageBox.Show(
                    "Server is already initialized.",
                    "Error - Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            listener = new TcpListener(IPAddress.Any, 27015);
            listener.Start();

            serverRunning = true;

            serverOutput = Program.mainClient.serverOutput;
            AppendServerOutputText($"<Server>: Server \"{serverName}\" initialized!");

            DisplayServerOutput();
        }

        public async void DisplayServerOutput()
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
                Stream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.Default.GetString(buffer, 0, bytesRead);
                    AppendServerOutputText("Received: " + data);
                    MessageBox.Show("Received: " + data);
                }
            }
        }

        // Append text to the server output
        public void AppendServerOutputText(string input)
        {
            if (serverOutput.InvokeRequired)
            {
                serverOutput.BeginInvoke(new Action<string>(AppendServerOutputText), input);
            }
            else
            {
                serverOutput.AppendText(input + Environment.NewLine);
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