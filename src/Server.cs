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

        public int maxUsers;
        public string ipAddr;
        public string serverName;
        public User[] users = new User[MAX_USERS];

        public Server(int maxUsers, string ipAddr, string serverName)
        {
            this.maxUsers = maxUsers;
            this.ipAddr = ipAddr;
            this.serverName = serverName;
        }

        public void JoinServer(User newUser)
        {
            // Half baked attempt to not allow more than maxUsers amount of users in one server
            //int i;

            //for (i = 0; i < users.Length;)
            //{
            //    if (users?[i] == null)
            //    {
            //        i--;
            //    }
            //    else
            //    {
            //        i = Math.Abs(i) + 1;
            //    }
            //}

            //if (i >= maxUsers)
            //{
            //    Console.WriteLine($"User \"{newUser.username}\" tried to join the server, but it is filled!");
            //    return;
            //}

            newUser.currServer = this;
            users.Append(newUser);
            Console.WriteLine($"User \"{newUser.username}\" has joined the server.");
        }
    }
}
