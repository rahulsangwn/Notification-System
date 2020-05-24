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
        ISocketManager _manager;
        NotificationForm _notificationForm;
        IClientSocket _socket;
        string _mode;
        string _identity;

        public ModeSelectionForm(NotificationForm notificationForm, ISocketManager manager, IClientSocket socket)
        {
            InitializeComponent();

            buttonModeSelectionFormNext.Enabled = false;
            buttonUpdateSubscriptions.Hide();
            checkedListBoxSubscription.Enabled = false;

            _manager = manager;
            _notificationForm = notificationForm;
            _socket = socket;

            socket.DataReceived += EnableNextButton;
        }

        // Enabling Next Button based on Verification Resopnse
        private void EnableNextButton(object sender, DataRecEventArgs e)
        {
            var resData = e.text.Split(':');
            if (resData[0] == "true")
            {
                buttonModeSelectionFormNext.Enabled = true;
                checkedListBoxSubscription.Enabled = true;
                buttonUpdateSubscriptions.Show();
                
                // Checking subscribed Groups in listBox
                for (int i = 1; i < resData.Length; i++)
                {
                    checkedListBoxSubscription.SetItemChecked(int.Parse(resData[i]) - 2, true);
                }
            }
            else if(resData[0] == "false")
            {
                buttonModeSelectionFormNext.Enabled = false;
                checkedListBoxSubscription.Enabled = false;
                buttonUpdateSubscriptions.Hide();
            }
        }

        // Verify Email Id or Phone Number entered
        private async void buttonVerify_Click(object sender, EventArgs e)
        {
            // Clear the selected check boxes;
            for (int i = 0; i < checkedListBoxSubscription.Items.Count; i++)
            {
                checkedListBoxSubscription.SetItemChecked(i, false);
            }

            _notificationForm.ClearData();
            bool email = radioButtonEmail.Checked;
            bool sms = radioButtonSMS.Checked;
            bool portal = radioButtonPortal.Checked;

            StringBuilder verifyRequest = new StringBuilder();

            if (email)
            {
                verifyRequest.Append("Email:");
                _mode = "Email";
            }
            else if (sms)
            {
                verifyRequest.Append("SMS:");
                _mode = "SMS";
            }
            else if (portal)
            {
                verifyRequest.Append("Portal:");
                _mode = "Online Portal";
            }

            verifyRequest.Append(textBoxIdentity.Text);
            _identity = textBoxIdentity.Text;
            var value = await _manager.IsValidUser(verifyRequest.ToString());
        }

        private void buttonModeSelectionFormNext_Click(object sender, EventArgs e)
        {
            // Unsubscribe From DataReceived Event
            _socket.DataReceived -= EnableNextButton;

            // Seting Info in Notification Form
            _notificationForm.SetInfo(_mode, _identity);

            // Closing Connection Form and Opening Model Selection Form
            this.Hide();
            _notificationForm.FormClosed += (s, args) => this.Close();
            _notificationForm.Show();
        }

        private void buttonUpdateSubscriptions_Click(object sender, EventArgs e)
        {
            StringBuilder subscriptionsIndicies = new StringBuilder("Subscriptions");
            for (int i = 0; i < 6; i++)
            {
                if(checkedListBoxSubscription.GetItemChecked(i))
                {
                    subscriptionsIndicies.Append(":" + (i + 2));
                }
            }

            _manager.SendData(subscriptionsIndicies.ToString());
        }
    }
}
