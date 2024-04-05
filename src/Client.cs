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
        // Constant variables
        public const int MAX_IP_LEN = 25; // Max length of the IP address
        public const string LOCALHOST = "127001"; // Local client's IP address

        // Servers
        public Server[] servers = new Server[2048]; // Arbitrary amount

        // Local
        public User localUser;

        // Hosting
        public int serverMaxUsers;
        public string serverName;
        public string serverIP;
        public Server hostedServer;

        public Client()
        {
            InitializeComponent();

            localUser = new User();
        }

        #region CONNECT
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

        private void IPInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Effectively click the connect button when enter is pressed
            if (e.KeyChar == (char)Keys.Return)
            {
                IPConnect_Click(this, null);
            }
        }

        private void IPConnect_Click(object sender, EventArgs e)
        {
            if (IsValidIP(ipInput.Text, out string output))
            {
                // Can't connect to localhost, cause of obvious reasons
                if (output == LOCALHOST)
                {
                    // Display an error pop-up describing what's wrong
                    MessageBox.Show(
                        "Can't connect to localhost, that is your client!",
                        "Error - localhost",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                TryConnect(output);

#if DEBUG
                Console.WriteLine($"Attempting to connect to IP address {output}...");
#endif // DEBUG
            }
        }
        #endregion // CONNECT

        #region HOST
        private void HostInput_TextChanged(object sender, EventArgs e)
        {
            // Check if the IP is valid, if so, have the button be enabled
            if (IsValidIP(hostInput.Text, out string output))
            {
                hostButton.Enabled = true;
                serverIP = output; // Set the server's IP address
            }
            else // Otherwise, no button!
            {
                hostButton.Enabled = false;
            }
        }

        private void MaxUsersInput_TextChanged(object sender, EventArgs e)
        {
            // Can't set null as a user count
            if (string.IsNullOrEmpty(maxUserInput.Text))
            {
                serverMaxUsers = 0;
            }
            else
            {
                if (int.TryParse(maxUserInput.Text, out int result))
                {
                    // maxUsers is now the set input!
                    serverMaxUsers = result;
                }
                else
                {
                    // No proper input, maxUsers is 0
                    serverMaxUsers = 0;
                }
            }
        }

        private void ServerNameInput_TextChanged(object sender, EventArgs e)
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

        // Handle the user pressing Enter on any of the valid inputs
        private void HostInputs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                HostButton_Click(this, null);
            }
        }

        // Start hosting a server with the info gathered from above
        private void HostButton_Click(object sender, EventArgs e)
        {
            // Show an error if the serverMaxUsers is 0
            if (serverMaxUsers == 0)
            {
                // Display a pop-up showing the error
                MessageBox.Show(
                    $"Please input a valid max user amount!\nThe range is from 1 to {Server.MAX_USERS} users.",
                    "Error - maxUsers",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (IsValidIP(hostInput.Text, out string output))
            {
                // Make the server and fill its variables
                hostedServer = new Server(serverMaxUsers, serverName, serverIP, localUser);
                servers.Append(hostedServer);

#if DEBUG
                // Write the info of the new server
                Console.WriteLine($"Making a new server...\n" +
                    $"  serverIP : {hostedServer.ipAddr}\n" +
                    $"  serverMaxUsers : {hostedServer.maxUsers}\n" +
                    $"  serverName : {hostedServer.serverName}");
#endif // DEBUG
            }
        }
        #endregion // HOST

        #region CONNECTION_HANDLERS
        // Method to check if the input is an IP address, and outputs the resulting IP
        private bool IsValidIP(string input, out string output)
        {
            // Array of valid numbers, concat'd to one string to check if a valid int
            // Potentially change to a regex
            char[] validNums = new char[MAX_IP_LEN];

            // For each character in the input
            for (int i = 0; i < input.Length; i++)
            {
                // Skip the .'s in the IP address
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
                // This is primarily for testing purposes when hosting
                output = LOCALHOST;
            }
            else
            {
                // Output the resulting numbers
                output = string.Concat(validNums);
            }
            // Return true if the output (validNums[]) is an int
            return int.TryParse(output, out int result);
        }

        // Try to connect to the inputted IP address
        private bool TryConnect(string ipInput)
        {
            bool foundServer = false;

            // Check every server in the list, if their ipAddr fits the inputted IP
            foreach (Server server in servers)
            {
                if (ipInput == server?.ipAddr)
                {
                    foundServer = true;
                }
            }

            if (!foundServer)
            {
                // Show an info box saying that no server's been found
                MessageBox.Show(
                    $"Couldn't find a server with the IP address of {ipInput}",
                    "Server Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return foundServer;
        }
        #endregion // CONNECTION_HANDLERS
    }
}