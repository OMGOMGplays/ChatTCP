using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTCP
{
    internal class Server
    {
        public const int MAX_USERS = 60;

        public int maxUsers = 4;
        public int ipAddr;
        public User[] users = new User[MAX_USERS];

        public Server(int maxUsers)
        {
            this.maxUsers = maxUsers;
        }

        public void JoinServer(User newUser)
        {
            newUser.currServer = this;
            users.Append(newUser);
        }
    }
}
