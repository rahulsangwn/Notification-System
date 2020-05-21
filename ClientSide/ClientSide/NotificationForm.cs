using ClientSide.Data;
using ClientSide.Socket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class NotificationForm : Form
    {
        ClientSocket _socket;

        public NotificationForm(ClientSocket socket)
        {
            _socket = socket;
            InitializeComponent();
            textBoxNotification.Enabled = false;
            _socket.DataReceived += PrintInBox;
        }

        private async void PrintInBox(object sender, DataRecEventArgs e)
        {
            if(e.text.StartsWith("Notification"))
            {
                string[] notifications = e.text.Split(':');
                StringBuilder acks = new StringBuilder("Ack:");
                foreach(var notification in notifications)
                {
                    textBoxNotification.AppendText(notification);
                    textBoxNotification.AppendText(Environment.NewLine);
                    var notifId = notification.Split(' ')[1];
                    acks.Append(notifId + ":");
                }
                await _socket.SendData(Encoding.ASCII.GetBytes(acks.ToString()));
            }
        }

        internal void ClearData()
        {
            textBoxNotification.Text = "";
        }
    }
}
