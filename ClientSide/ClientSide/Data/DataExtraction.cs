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

        public event EventHandler<NotificationEntity> NewNotification;
        protected virtual void OnNewNotification(NotificationEntity notification)
        {
            NewNotification?.Invoke(this, notification);
        }

        private async void ExtractAndLoad(object sender, DataRecEventArgs e)
        {
            if (e.text.StartsWith("Notification"))
            {
                string[] notifications = e.text.Split('$');
                StringBuilder acks = new StringBuilder("Ack:");
                NotificationEntity recentNotification = new NotificationEntity();
                foreach (var notification in notifications)
                {
                    var columns = notification.Split(',');
                    recentNotification = NotificationData.Add(int.Parse(columns[1]), columns[2], columns[3], columns[4]);
                    
                    acks.Append(int.Parse(columns[1]) + ":");
                }

                if(notifications.Length == 1)
                {
                    OnNewNotification(recentNotification);
                }
                await _socket.SendData(Encoding.ASCII.GetBytes(acks.ToString()));
            }
        }
    }
}
