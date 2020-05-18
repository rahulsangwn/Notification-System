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
        public ModeSelectionForm()
        {
            InitializeComponent();
            buttonModeSelectionFormNext.Enabled = false;
            _manager = new SocketManager();
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
            NotificationForm notificationForm = new NotificationForm();
            this.Hide();
            notificationForm.Show();
        }
    }
}
