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
        IClientSocket client;
        ModeSelectionForm _modeSelectionForm;
        public ConnectionForm(IClientSocket socket, ModeSelectionForm modeSelectionForm)
        {
            InitializeComponent();
            buttonServerNext.Enabled = false;
            textBoxServerIP.Text = "127.0.0.1";
            textBoxServerPort.Text = "2222";
            client = socket;
            _modeSelectionForm = modeSelectionForm;
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
            _modeSelectionForm.FormClosed += (s, args) => this.Close();
            _modeSelectionForm.Show();

        }
    }
}
