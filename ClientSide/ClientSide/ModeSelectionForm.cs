using ClientSide.Socket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public ModeSelectionForm(NotificationForm notificationForm, SocketManager manager)
        {
            InitializeComponent();
            buttonModeSelectionFormNext.Enabled = false;
            _manager = manager;
            _notificationForm = notificationForm;
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if(_manager.IsValidUser(textBoxIdentity.Text))
            {
                buttonModeSelectionFormNext.Enabled = true;
            }
        }

        private void buttonModeSelectionFormNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            _notificationForm.FormClosed += (s, args) => this.Close();
            _notificationForm.Show();

        }
    }
}
