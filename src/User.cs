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
        public const int MAX_USERNAME_LEN = 32; // Max length a user's name can be

        public Socket socket; // The user's network socket, used to connect to a server socket

        public string username; // The user's username, displays when chatting
        public string msg; // The user's message (in a sort of buffer)
        public Server currServer; // The current server that the user's in, if any
    }
}
