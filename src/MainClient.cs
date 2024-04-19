using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable CA1416 // Disable annoying squiggly lines informing about old Windows support

namespace ChatTCP
{
    internal partial class MainClient : Form
    {
        // Constant variables
        public const int MAX_IP_LEN = 32; // Max length of an IP address

        // Sourced from:
        // https://www.oreilly.com/library/view/regular-expressions-cookbook/9780596802837/ch07s16.html
        // Is to be used to determine whether or not an input is a valid IP address or not, through a Regex check
        public const string IP_PATTERN = @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$";

        // Servers
        private Server[] servers = new Server[2048]; // Arbitrary amount

        // Local
        private User localUser;

        // Hosting
        private int serverMaxUsers;
        private string serverIP;
        private string serverName;
        private Server hostedServer;

        public MainClient()
        {
            InitializeComponent();

            localUser = new User();
            localUser.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        #region USER
        private void UsernameInput_TextChanged(object sender, EventArgs e)
        {
            // Can't have a username that's too long
            if (usernameInput.Text.Length > User.MAX_USERNAME_LEN)
            {
                MessageBox.Show(
                    $"Username is above the max length of {User.MAX_USERNAME_LEN}!",
                    "Error - User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                usernameInput.MaxLength = User.MAX_USERNAME_LEN;
            }

            // Set the local user's username to the input
            localUser.username = usernameInput.Text;
        }
        #endregion // USER

        #region CONNECTING
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
        #endregion // CONNECTING

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

        // Change the server's name
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
            // Show an error if the serverMaxUsers is less than or equal to 0
            if (serverMaxUsers <= 0)
            {
                // Display a pop-up showing the error
                MessageBox.Show(
                    $"Please input a valid max user amount!\nThe range is from 1 to {Server.MAX_USERS} users.",
                    "Error - Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Make sure the input is a valid IP address
            if (IsValidIP(hostInput.Text, out string output))
            {
                // Make a random username for those without a specified username
                if (string.IsNullOrEmpty(localUser.username))
                {
                    Random rnd = new Random();
                    localUser.username = $"User {rnd.Next(0, 10000)}";
                }

                // Set the server IP to the output
                serverIP = output;

                // Make the server and fill its variables
                hostedServer = new Server(serverMaxUsers, serverIP, serverName);

                // Add the hosted server to the server list and try to have the localUser join the server
                for (int i = 0; i < servers.Length; i++)
                {
                    if (servers[i] == null)
                    {
                        servers[i] = hostedServer;
                        break;
                    }
                }

                // If we can't connect, then remove the server
                if (!TryConnect(serverIP))
                {
                    // Inform the user that the server couldn't be locally connected to
                    MessageBox.Show(
                        "Couldn't personally connect to server, please retry!",
                        "Error - Server",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Remove the server from the list
                    for (int i = 0; i < servers.Length - 1; i++)
                    {
                        if (hostedServer == servers[i])
                        {
                            servers[i] = null;
                            hostedServer = null;
                            break;
                        }
                    }

                    return;
                }

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
            // Regex to see if the input fits the IP pattern
            Regex regex = new Regex(IP_PATTERN);
            Match match = regex.Match(input);

            output = match.Value;
            return match.Success; // Returns the result, whether it's a valid IP address or not
        }

        // Try to connect to the inputted IP address
        private bool TryConnect(string ipInput)
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
                    // The client has found a server
                    foundServer = true;

                    // Connect the user to the server
                    localUser.socket.BeginConnect(ipInput, 1, null, null);
                }
            }

            if (!foundServer)
            {
                // Show an info box saying that no server's been found
                MessageBox.Show(
                    $"Couldn't find a server with the IP address of \"{ipInput}\"",
                    "Info - Connecting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Return foundServer's value
            return foundServer;
        }

        // Close the hosted server, when the form is closing
        private void MainClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hostedServer != null)
            {
                hostedServer.CloseServer();

                for (int i = 0; i < servers.Length; i++)
                {
                    if (servers[i] == hostedServer)
                    {
                        servers[i] = null;
                    }
                }
            }
        }
        #endregion // CONNECTION_HANDLERS
    }
}