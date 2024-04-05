using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTCP
{
    internal class Server
    {
        public const int MAX_USERS = 64;

        public int maxUsers = 4;
        public int[] ipAddr;
        public string serverName;
        public User[] users = new User[MAX_USERS];

        public Server(int maxUsers, int[] ipAddr, string serverName)
        {
            this.maxUsers = maxUsers;
            this.ipAddr = ipAddr;
            this.serverName = serverName;
        }

        public void JoinServer(User newUser)
        {
            newUser.currServer = this;
            users.Append(newUser);
            Console.WriteLine($"User {newUser.username} has joined the server.");
        }
    }
}
