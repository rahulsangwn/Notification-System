﻿using BusinessLogicLayer.Processor;
using ServerUI.Socket;
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

namespace ServerUI
{
    public partial class Emitter : Form
    {
        NotificationProcessor _notification;
        ServerManager _manager;
        public Emitter()
        {
            _notification = new NotificationProcessor();
            _manager = new ServerManager();

            InitializeComponent();
            comboBoxGroup.SelectedItem = "All";
        }

        private void buttonPush_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNotification.Text) &&
                !string.IsNullOrEmpty(comboBoxGroup.Text) &&
                !string.IsNullOrEmpty(comboBoxNotificationType.Text))
            {
                int notifId = _notification.CreateNotification(comboBoxNotificationType.Text, comboBoxGroup.Text, textBoxNotification.Text);
                if (notifId != 0)
                {
                    _manager.PushNotification(notifId);
                    MessageBox.Show("Notifcation Pushed to Subscriber!");
                    Reset();
                }
            }
        }

        private void Reset()
        {
            comboBoxNotificationType.Text = "";
            comboBoxGroup.Text = "All";
            textBoxNotification.Text = "";
        }

        private void Emitter_FormClosing(object sender, FormClosingEventArgs e)
        {
            _manager.StopServer();
        }
    }
}
