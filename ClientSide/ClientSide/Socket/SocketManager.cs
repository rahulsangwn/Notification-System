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
    public class SocketManager
    {
        ClientSocket _socket;
        public SocketManager(ClientSocket socket)
        {
            _socket = socket;
        }

        public async Task<bool> IsValidUser(string user)
        {
            byte[] data = Encoding.ASCII.GetBytes(user);
            await _socket.SendData(data);

            return true;
        }

    }
}

