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
        DataExtraction _data;
        public SocketManager(ClientSocket socket, DataExtraction data)
        {
            _socket = socket;
            _data = data;
        }

        public async Task<bool> IsValidUser(string user)
        {
            byte[] data = Encoding.ASCII.GetBytes(user);
            await _socket.SendData(data);

            return true;
        }

        internal async void SendData(string data)
        {
            await _socket.SendData(Encoding.ASCII.GetBytes(data));
        }
    }
}

