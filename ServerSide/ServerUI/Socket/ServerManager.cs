using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.Socket
{
    public class ServerManager
    {
        ServerSocket _socket;
        public ServerManager()
        {
            _socket = new ServerSocket();
            _socket.ConnectionListner();
        }
        public void StopServer()
        {
            _socket.CloseSocket();
        }

        internal void SendSomeData()
        {
            _socket.SendSomeData();
        }
    }
}
