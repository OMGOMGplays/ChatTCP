using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatTCP
{
    internal partial class Client : Form
    {
        // Important variables
        public const int MAX_IP_LEN = 25;

        // Local
        public User localUser;

        // Hosting
        public bool hostingServer;
        public int maxUsers;
        public string serverName;
        public Server hostedServer;

        public Client()
        {
            InitializeComponent();
        }

        private void IPConnect_Click(object sender, EventArgs e)
        {
            if (IsValidIP(ipInput.Text, out string output))
            {
                TryConnect(output);
            }
        }

        private void IPInput_TextChanged(object sender, EventArgs e)
        {
            // Make sure the input doesn't exceed the allowed length
            // I would freeze the text as it is, were I to know how to
            if (ipInput.Text.Length > MAX_IP_LEN)
            {
                ipInput.Clear();
            }

            // Check if the IP is valid, if so, have the button be enabled
            if (IsValidIP(ipInput.Text, out string output))
            {
                ipConnect.Enabled = true;
            }
            else // Otherwise, no button!
            {
                ipConnect.Enabled = false;
            }
        }

        private void HostInput_TextChanged(object sender, EventArgs e)
        {
            // Check if the IP is valid, if so, have the button be enabled
            if (IsValidIP(hostInput.Text, out string output))
            {
                hostButton.Enabled = true;
            }
            else // Otherwise, no button!
            {
                hostButton.Enabled = false;
            }
        }

        private void MaxUsersInput_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(maxUserInput.Text))
            {
                maxUsers = 0;
            }
            else
            {
                if (int.TryParse(maxUserInput.Text, out int result))
                {
                    maxUsers = result;
                }
                else
                {
                    maxUsers = 0;
                }
            }
        }

        private void serverNameInput_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(serverNameInput.Text))
            {
                serverName = "Server";
            }
            else
            {
                serverName = serverNameInput.Text;
            }
        }

        private void HostButton_Click(object sender, EventArgs e)
        {
            if (maxUsers == 0)
            {
                MessageBox.Show("Please input a valid max user amount!\nThe range is from 1 to 60 users.", "Error - maxUsers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (IsValidIP(hostInput.Text, out string output))
            {
                hostingServer = true;
                hostedServer = new Server(maxUsers, serverName);


            }
        }

        /// <summary>
        /// Is the input a valid IP address?
        /// </summary>
        private bool IsValidIP(string input, out string output)
        {
            // Array of valid numbers, concat'd to one string to check if a valid int
            char[] validNums = new char[MAX_IP_LEN];

            // For each character in the input
            for (int i = 0; i < input.Length; i++)
            {
                // Skip the .'s in e.g. "192.168.0.1"
                if (input[i] == '.')
                {
                    validNums[i] = validNums[i - 1];
                    continue;
                }
                else // Otherwise, the input is (presumably) a number
                {
                    validNums[i] = input[i];
                }
            }

            if (input == "localhost")
            {
                // The client's local IP
                output = "127001";
            }
            else
            {
                // Output the resulting numbers
                output = string.Concat(validNums);
            }
            // Return true if the output (validNums[]) is an int
            return int.TryParse(output, out int result);
        }

        private bool TryConnect(string ip)
        {
            int intIP = int.Parse(ip);
            Socket sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);

            return true;
        }
    }
}
