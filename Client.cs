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
    public partial class Client : Form
    {
        public const int MAX_IP_LEN = 25;

        public Client()
        {
            InitializeComponent();
        }

        private void ipConnect_Click(object sender, EventArgs e)
        {
            if (IsValidIP(ipInput.Text, out string output))
            {
                TryConnect(output);
            }
        }

        private void ipInput_TextChanged(object sender, EventArgs e)
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
                    i++;
                    continue;
                }
                else // Otherwise, the input is a valid number
                {
                    validNums[i] = input[i];
                }
            }

            // Output the resulting numbers
            output = string.Concat(validNums);
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
