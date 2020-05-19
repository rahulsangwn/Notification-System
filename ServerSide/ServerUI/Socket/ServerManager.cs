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

        public void SendData()
        {
            //NotificationEntity obj = new NotificationEntity();
            //obj.Id = 1;
            //obj.NotifBody = "My Notification";
            //var bytes = ObjectToByteArray<NotificationEntity>(obj);
            //_socket.Send(bytes);
        }

        //public static byte[] ObjectToByteArray<T>(T obj)
        //{
        //    using (var stream = new MemoryStream())
        //    {
        //        XmlSerializer xmlS = new XmlSerializer(typeof(T));
        //        xmlS.Serialize(stream, obj);
        //        return stream.ToArray();
        //    }
        //}

    }
}
