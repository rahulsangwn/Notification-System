using ClientSide.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide.Data
{
    public class DataExtraction
    {
        ClientSocket _socket;
        public DataExtraction(ClientSocket socket)
        {
            _socket = socket;
            _socket.DataReceived += ExtractAndLoad;
        }

        private async void ExtractAndLoad(object sender, DataRecEventArgs e)
        {
            if (e.text.StartsWith("Notification"))
            {
                string[] notifications = e.text.Split(':');
                StringBuilder acks = new StringBuilder("Ack:");
                foreach (var notification in notifications)
                {
                    var columns = notification.Split(',');
                    NotificationData.Add(int.Parse(columns[1]), columns[2], columns[3], columns[4]);
                    
                    acks.Append(int.Parse(columns[1]) + ":");
                }
                await _socket.SendData(Encoding.ASCII.GetBytes(acks.ToString()));
            }
        }
    }
}
