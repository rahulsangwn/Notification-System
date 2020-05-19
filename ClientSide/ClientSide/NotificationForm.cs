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
        ClientSocket _socket; //= new ClientSocket();

        public NotificationForm(ClientSocket socket)
        {
            _socket = socket;
            Debug.WriteLine("Initialized");
            InitializeComponent();
            textBoxNotification.Enabled = false;
            _socket.DataReceived += PrintInBox;
        }

        private void PrintInBox(object sender, DataRecEventArgs e)
        {
            if(e.text.StartsWith("Notification"))
            {
                textBoxNotification.AppendText(e.text);
                textBoxNotification.AppendText(Environment.NewLine);
            }
        }
    }
}
