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
    public class SocketManager : ISocketManager
    {
        IClientSocket _socket;
        IDataExtraction _data;
        public SocketManager(IClientSocket socket, IDataExtraction data)
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

        public async void SendData(string data)
        {
            await _socket.SendData(Encoding.ASCII.GetBytes(data));
        }
    }
}

