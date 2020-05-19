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

        // Enabling Next Button based on Verification Resopnse
        private void EnableNextButton(object sender, DataRecEventArgs e)
        {
            if (e.text == "true")
            {
                buttonModeSelectionFormNext.Enabled = true;
            }
            else if(e.text == "false")
            {
                buttonModeSelectionFormNext.Enabled = false;
            }
        }

        // Verify Email Id or Phone Number entered
        private async void buttonVerify_Click(object sender, EventArgs e)
        {
            bool email = radioButtonEmail.Checked;
            bool sms = radioButtonSMS.Checked;
            bool portal = radioButtonPortal.Checked;

            StringBuilder verifyRequest = new StringBuilder();

            if (email)
                verifyRequest.Append("Email:");
            else if (sms)
                verifyRequest.Append("SMS:");
            else if (portal)
                verifyRequest.Append("Portal:");

            verifyRequest.Append(textBoxIdentity.Text);
            var value = await _manager.IsValidUser(verifyRequest.ToString());
        }

        private void buttonModeSelectionFormNext_Click(object sender, EventArgs e)
        {
            // Unsubscribe From DataReceived Event
            _socket.DataReceived -= EnableNextButton;

            // Closing Connection Form and Opening Model Selection Form
            this.Hide();
            _notificationForm.FormClosed += (s, args) => this.Close();
            _notificationForm.Show();
        }

    }
}
