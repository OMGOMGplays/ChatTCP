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
    internal partial class MainClient : Form
    {
        // Constant variables
        public const int MAX_IP_LEN = 32; // Max length of the IP address

        // Static variables
        public static int[] localHost = { 127, 0, 0, 1 }; // Local client's IP address

        // Servers
        private Server[] servers = new Server[2048]; // Arbitrary amount

        // Local
        private User localUser;

        // Hosting
        private int serverMaxUsers;
        private int[] serverIP;
        private string serverName;
        private Server hostedServer;

        public MainClient()
        {
            InitializeComponent();

            localUser = new User();
        }

        #region USER
        private void UsernameInput_TextChanged(object sender, EventArgs e)
        {
            if (usernameInput.Text.Length > User.MAX_USERNAME_LEN)
            {
                MessageBox.Show(
                    $"Username is above the max length of {User.MAX_USERNAME_LEN}!",
                    "Error - User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                usernameInput.MaxLength = User.MAX_USERNAME_LEN + 1;
            }

            localUser.username = usernameInput.Text;
        }
        #endregion // USER

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
            if (IsValidIP(ipInput.Text, out int[] output))
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
            if (IsValidIP(ipInput.Text, out int[] output))
            {
                // Can't connect to localhost, cause of obvious reasons
                if (output == localHost)
                {
                    // Display an error pop-up describing what's wrong
                    MessageBox.Show(
                        "Can't connect to localhost, that's your client!",
                        "Error - Connecting",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Make a random username for those without a specified username
                if (string.IsNullOrEmpty(localUser.username))
                {
                    Random rnd = new Random();
                    localUser.username = $"User {rnd.Next(0, 10000)}";
                }

                if (!TryConnect(output))
                {
                    return;
                }

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
            if (IsValidIP(hostInput.Text, out int[] output))
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
                serverMaxUsers = Server.MAX_USERS;
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
                    // No proper input, serverMaxUsers is the MAX_USERS set in Server
                    serverMaxUsers = Server.MAX_USERS;
                }
            }
        }

        private void ServerNameInput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serverNameInput.Text))
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
                    "Error - Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (IsValidIP(hostInput.Text, out int[] output))
            {
                // Make a random username for those without a specified username
                if (string.IsNullOrEmpty(localUser.username))
                {
                    Random rnd = new Random();
                    localUser.username = $"User {rnd.Next(0, 10000)}";
                }

                serverIP = output;

                // Make the server and fill its variables
                hostedServer = new Server(serverMaxUsers, serverIP, serverName);

                // Add the hosted server to the server list and join the localUser to the server
                servers.Append(hostedServer);
                TryConnect(serverIP);

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
        private bool IsValidIP(string input, out int[] output)
        {
            int[] ipAddr = new int[4];

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    i++;
                    continue;
                }
            }

            if (input.ToLower() == "localhost")
            {
                // The client's local IP
                // This is primarily for testing purposes when hosting
                output = localHost;
                ipAddr = localHost;
            }
            else
            {
                // Output the resulting numbers
                output = ipAddr;
            }
            Console.WriteLine($"Output is {output}");
            return ipAddr.Length < 4 ? false : true;
        }

        // Try to connect to the inputted IP address
        private bool TryConnect(int[] ipInput)
        {
            bool foundServer = false;

            // Check every server in the list and if their ipAddr fits the inputted IP
            foreach (Server server in servers)
            {
                // Skip over null servers
                if (server == null)
                {
                    continue;
                }

                if (ipInput == server?.ipAddr)
                {
                    foundServer = true;
                    server.JoinServer(localUser);
                }
            }

            if (!foundServer)
            {
                // Show an info box saying that no server's been found
                MessageBox.Show(
                    $"Couldn't find a server with the IP address of {ipInput}",
                    "Info - Connecting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            // Server has been found!
            return true;
        }
        #endregion // CONNECTION_HANDLERS
    }
}