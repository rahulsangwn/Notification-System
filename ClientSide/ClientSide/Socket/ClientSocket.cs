using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide.Socket
{
    public class ClientSocket
    {
        IPAddress serverIP;
        int serverPort;
        TcpClient client;

        public async Task<bool> ConnectToServer(IPAddress ip, int port)
        {
            serverIP = ip;
            serverPort = port;
            if (client == null)
            {
                client = new TcpClient();
            }

            try
            {
                await client.ConnectAsync(serverIP, serverPort);
                Debug.WriteLine("[+] Connected to Server {0} on Port {1}", serverIP, serverPort);

                //StreamReader reader = new StreamReader(client.GetStream());

                //char[] buff = new char[128];
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }

    }
}
