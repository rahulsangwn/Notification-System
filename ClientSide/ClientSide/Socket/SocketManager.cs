using ClientSide.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClientSide.Socket.ClientSocket;

namespace ClientSide.Socket
{
    class SocketManager
    {
        ClientSocket _socket = new ClientSocket();

        public bool IsValidUser(string user)
        {
            return true;
        }
    }
}
