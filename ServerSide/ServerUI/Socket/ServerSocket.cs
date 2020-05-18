﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.Socket
{
    public class ServerSocket
    {
        IPAddress serverIP = IPAddress.Any;
        int serverPort = 2222;

        internal void CloseSocket()
        {
            try
            {
                if (listener != null)
                {
                    listener.Stop();
                    Debug.WriteLine("[-] Server Stoped");
                }

                foreach(var client in connectedClients)
                {
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        internal void SendSomeData()
        {
            foreach (var client in connectedClients)
            {
                byte[] bytes = Encoding.ASCII.GetBytes("rahul");
                var stream = client.GetStream();
                stream.WriteAsync(bytes, 0, 4);
            }
        }

        TcpListener listener;
        public bool IsRunning;

        List<TcpClient> connectedClients;

        public ServerSocket()
        {
            connectedClients = new List<TcpClient>();
        }

        public async void ConnectionListner()
        {
            listener = new TcpListener(serverIP, serverPort);

            try
            {
                listener.Start();
                Debug.WriteLine($"[+] Started Listening on {serverIP}:{serverPort}");
                IsRunning = true;

                while(IsRunning)
                {
                    var latestClient = await listener.AcceptTcpClientAsync();
                    connectedClients.Add(latestClient);

                    Debug.WriteLine("[+] Client {0} connected Successfully ",
                        latestClient.Client.RemoteEndPoint);

                    HandleClient(latestClient);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("[-] Exception: {0}", e.ToString());
            }
        }

        private async void HandleClient(TcpClient client)
        {
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                stream = client.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[128];

                while(IsRunning)
                {
                    int recievedNoOfBytes = await reader.ReadAsync(buff, 0, buff.Length);

                    if (recievedNoOfBytes == 0)
                    {
                        DisconnectClient(client);

                        Debug.WriteLine("Client {0} disconnected", client.Client.RemoteEndPoint);
                        break;
                    }

                    string recivedText = new string(buff);
                    Debug.WriteLine("Recived Data: " + recivedText);
                    Array.Clear(buff, 0, buff.Length);
                    
                }
            }
            catch (Exception e)
            {
                DisconnectClient(client);
                Debug.WriteLine("[-] Exception: " + e.ToString());
            }
        }

        private void DisconnectClient(TcpClient client)
        {
            if (connectedClients.Contains(client))
            {
                connectedClients.Remove(client);
            }
        }
    }
}
