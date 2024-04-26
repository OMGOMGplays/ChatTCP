using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#pragma warning disable CA1416 // Disable annoying squiggly lines informing about old Windows support

namespace ChatTCP
{
    public partial class MainClient : Form
    {
        ////////////////////////////
        // Constant variables
        ////////////////////////////

        // Max length of an IP address
        public const int MAX_IP_LEN = 32;

        // Sourced from:
        // https://www.oreilly.com/library/view/regular-expressions-cookbook/9780596802837/ch07s16.html
        // Is to be used to determine whether or not an input is a valid IP address or not, through a Regex check
        public const string IP_PATTERN = @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$";

        ////////////////////////////
        // Servers
        ////////////////////////////

        // !! IF THE ARRAY SIZE IS CHANGED HERE, CHANGE IT IN THE HOST PROGRAM TOO !!
        private Server[] openServers = new Server[2048];

        ////////////////////////////
        // Local
        ////////////////////////////

        private User localUser;

        // Used to connecting to a ChatTCP-Host
        public TcpClient localClient;

        ////////////////////////////
        // Hosting
        ////////////////////////////

        private int serverMaxUsers;
        private string serverIP;
        private string serverName;
        private Server hostedServer;

        public MainClient()
        {
            // Initialize the form
            InitializeComponent();

            // Make a new local user
            localUser = new User();
            localUser.client = new TcpClient();

            // Make a new local client and connect to the main ChatTCP-Host server
            localClient = new TcpClient();
            ConnectToHostServer();
        }

        #region CLIENT
        // Connect the client to the host server
        private async void ConnectToHostServer()
        {
            try
            {
                // Connect to the ChatTCP-Host server
                // !! This IP address is *very* much temporary, find some way to have the ChatTCP-Host server broadcast its IP address !!
                await localClient.ConnectAsync(IPAddress.Parse("127.0.0.1"), 27015);
                AppendServerOutputText("<Client>: Successfully connected to the ChatTCP-Host server.");
            }
            catch (Exception e)
            {
                // Can't use the client if it can't connect to the server
                MessageBox.Show(
                    $"Error connecting to ChatTCP-Host server!\n({e.Message})",
                    "Error - Client",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
        }

        // Append text to the server output
        public void AppendServerOutputText(string input)
        {
            // Invoke the method, if it's required to
            if (serverOutput.InvokeRequired == true)
            {
                serverOutput.BeginInvoke(new Action<string>(AppendServerOutputText), input);
            }
            else
            {
                // Append the input to the server output
                // This displays server info (e.g. messages and etc.) from the server to the user
                serverOutput.AppendText(input + Environment.NewLine);
            }
        }
        #endregion // CLIENT

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
            if (IsValidIP(ipInput.Text))
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
            // Update the client's server list
            //GetServersFromHost();

            // Make sure the IP address is a valid one
            if (IsValidIP(ipInput.Text, out string output))
            {
                // Make a randomly generated username for those without a specified username
                if (string.IsNullOrEmpty(localUser.username))
                {
                    Random rnd = new Random();
                    localUser.username = $"User {rnd.Next(0, 10000)}";
                }

                // If we can't connect to the server, return
                if (!TryConnect(output))
                {
                    return;
                }
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
            // Can't set null as a user count, so default to MAX_USERS
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

                // Add the hosted server to the server list
                for (int i = 0; i < openServers.Length; i++)
                {
                    if (openServers[i] == null)
                    {
                        openServers[i] = hostedServer;
                        break;
                    }
                }

                // Display a text box to show the server's been made
#if DEBUG
                MessageBox.Show(
                    "Server has been successfully made! Its values are:\n" +
                    $"serverIP: {hostedServer.serverIP}\n" +
                    $"serverMaxUsers: {hostedServer.serverMaxUsers}\n" +
                    $"serverName: {hostedServer.serverName}",
                    "Info - Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
#endif // DEBUG

                // Inform the Host server that it should update its list of servers
                localClient.SendBufferSize = 1;

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
                    for (int i = 0; i < openServers.Length; i++)
                    {
                        if (hostedServer == openServers[i])
                        {
                            openServers[i] = null;
                            hostedServer = null;
                            break;
                        }
                    }

                    return;
                }
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

        // Checks if the input IP address is a valid IP address
        private bool IsValidIP(string input)
        {
            return IsValidIP(input, out string output);
        }

        // Try to connect to the inputted IP address
        private bool TryConnect(string ipInput)
        {
            bool foundServer = false;

            // Check every server in the list and if their ipAddr fits the inputted IP
            foreach (Server server in openServers)
            {
                // Skip over null servers
                if (server == null)
                {
                    continue;
                }

                if (ipInput == server.serverIP)
                {
                    // The client has found a server
                    foundServer = true;

                    // The user's already connected to the found server
                    if (localUser.currServer == server)
                    {
                        MessageBox.Show(
                            "You are already connected to this server!",
                            "Warning - Connecting",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return false;
                    }

                    // Connect the user to the server
                    localUser.client.Connect(IPAddress.Parse(ipInput), 27014);
                    localUser.currServer = server;

                    AppendServerOutputText($"<Server>: User \"{localUser.username}\" has joined the server!");
                }
            }

            // Show an info box saying that no server's been found
            if (!foundServer)
            {
                MessageBox.Show(
                    $"Couldn't find a server with the IP address of \"{ipInput}\"",
                    "Info - Connecting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Return foundServer's value
            return foundServer;
        }

        // When the form is closing we should...
        private void MainClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Inform the other users that this client has left the server
            if (localUser.currServer != null)
            {
                AppendServerOutputText($"<Server>: User \"{localUser.username}\" has left the server!");
            }

            // Close any locally hosted servers
            if (hostedServer != null)
            {
                hostedServer.CloseServer();

                // Remove the server from the list
                for (int i = 0; i < openServers.Length; i++)
                {
                    if (openServers[i] == hostedServer)
                    {
                        openServers[i] = null;
                        hostedServer = null;
                    }
                }
            }
        }
        #endregion // CONNECTION_HANDLERS
    }
}