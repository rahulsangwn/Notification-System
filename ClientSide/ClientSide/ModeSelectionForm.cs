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
    public partial class ModeSelectionForm : Form
    {
        SocketManager _manager;
        NotificationForm _notificationForm;
        ClientSocket _socket;
        public ModeSelectionForm(NotificationForm notificationForm, SocketManager manager, ClientSocket socket)
        {
            InitializeComponent();
            buttonModeSelectionFormNext.Enabled = false;
            _manager = manager;
            _notificationForm = notificationForm;
            _socket = socket;
            socket.DataReceived += EnableNextButton;
        }

        private void EnableNextButton(object sender, DataRecEventArgs e)
        {
            
            Debug.WriteLine("Form Data " + e.text.ToString());
            buttonModeSelectionFormNext.Enabled = true;
        }

        private async void buttonVerify_Click(object sender, EventArgs e)
        {
            var value = await _manager.IsValidUser(textBoxIdentity.Text);
        }

        private void buttonModeSelectionFormNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            _notificationForm.FormClosed += (s, args) => this.Close();
            _notificationForm.Show();
        }

    }
}
