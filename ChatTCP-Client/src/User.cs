using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatTCP
{
    public struct User
    {
        public const int MAX_USERNAME_LEN = 32; // Max length a user's name can be

        public TcpClient client; // The user's client, this allows them to connect to a server 

        public string username; // The user's username, displays when chatting
        public byte[] msg; // The user's message as a buffer
        public Server currServer; // The current server that the user's in, if any
    }
}
