using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Processor;
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
        RecipientsProcessor _recipients;
        public ServerManager()
        {
            _socket = new ServerSocket();
            _recipients = new RecipientsProcessor();
            _socket.ConnectionListner();
        }
        public void StopServer()
        {
            _socket.CloseSocket();
        }

        internal void PushNotification(int notifId)
        {
            var clients = ServerSocket.GetClients();
            
            foreach(var client in clients)
            {
                var data = _recipients.FetchUserNotification(client.Value, notifId);
                if (data != null)
                {
                    _socket.Send(data, client.Key);
                }
            }
        }
    }
}
