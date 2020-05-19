using BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
    }
}
