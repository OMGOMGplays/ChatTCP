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
        public string serverName;
        public string ipAddr;
        public User[] users = new User[MAX_USERS];

        public Server(int maxUsers, string serverName, string ipAddr, User user)
        {
            this.maxUsers = maxUsers;
            this.serverName = serverName;
            this.ipAddr = ipAddr;
            users.Append(user);
        }

        public void JoinServer(User newUser)
        {
            newUser.currServer = this;
            users.Append(newUser);
        }
    }
}
