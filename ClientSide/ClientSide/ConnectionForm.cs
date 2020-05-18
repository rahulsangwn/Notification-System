using ClientSide.Data;
using ClientSide.Socket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class ConnectionForm : Form
    {
        ClientSocket client;
        public ConnectionForm()
        {
            InitializeComponent();
            buttonServerNext.Enabled = false;
            textBoxServerIP.Text = "127.0.0.1";
            textBoxServerPort.Text = "2222";
            client = new ClientSocket();
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            

            IPAddress serverIP;
            int serverPort;

            if (!IPAddress.TryParse(textBoxServerIP.Text, out serverIP))
            {
                textBoxConnectionLog.Text = "Please Enter a Valid IP Address";
                return;
            }

            if (int.TryParse(textBoxServerPort.Text, out serverPort))
            {
                if (1020 < serverPort || serverPort < 65535)
                {
                    
                    // To Connect to the Server
                    if (await client.ConnectToServer(serverIP, serverPort))
                    {
                        buttonConnect.Enabled = false;
                        buttonServerNext.Enabled = true;
                        textBoxConnectionLog.Text = "[+] Connected to Server on Port " + serverPort;
                    }
                    else
                    {
                        textBoxConnectionLog.Text = "[-] Unable to Connect to Server";
                        return;
                    }
                } else
                {
                    textBoxConnectionLog.Text = "Port No must be between 1020 and 65535";
                    return;
                }
            } else
            {
                textBoxConnectionLog.Text = "Please Enter a Valid Port";
                return;
            }

        }

        private void buttonServerNext_Click(object sender, EventArgs e)
        {
            // Closing Conection Form
            this.Hide();
            ModeSelectionForm modeSelectionForm = new ModeSelectionForm();
            modeSelectionForm.FormClosed += (s, args) => this.Close();
            modeSelectionForm.Show();

        }
    }
}
