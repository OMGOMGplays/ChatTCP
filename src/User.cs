using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatTCP
{
    internal struct User
    {
        public const int MAX_USERNAME_LEN = 64;

        public TcpClient client;

        public string username; // The user's username, displays when chatting
        public string msg; // The user's message (in a sort of buffer)
        public Server currServer; // The current server that the user's in, if any
    }
}
