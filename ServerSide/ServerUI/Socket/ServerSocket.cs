﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerUI.Socket
{
    public class ServerSocket
    {
        IPAddress serverIP = IPAddress.Any;
        int serverPort = 2222;
        SocketHelper _helper = new SocketHelper();

        internal void CloseSocket()
        {
            try
            {
                if (listener != null)
                {
                    listener.Stop();
                    Debug.WriteLine("[-] Server Stoped");
                }

                foreach (var client in connectedClients)
                {
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        internal void Send(byte[] data, TcpClient client)
        {
            var stream = client.GetStream();
            stream.WriteAsync(data, 0, data.Length);
        }

        TcpListener listener;
        public bool IsRunning;

        List<TcpClient> connectedClients;
        public static Dictionary<TcpClient, string> loginedClients;

        public static Dictionary<TcpClient, string> GetClients() { return loginedClients; }
        public ServerSocket()
        {
            connectedClients = new List<TcpClient>();
            loginedClients = new Dictionary<TcpClient, string>();
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

                char[] buff = new char[1024 * 1024];

                while(IsRunning)
                {
                    int recievedNoOfBytes = await reader.ReadAsync(buff, 0, buff.Length);

                    if (recievedNoOfBytes <= 0)
                    {
                        DisconnectClient(client);

                        Debug.WriteLine("Client {0} disconnected", client.Client.RemoteEndPoint);
                        break;
                    }

                    string recivedText = new string(buff);
                    Debug.WriteLine("Recived Data: " + recivedText);
                    ReadingHandler(recivedText, client);
                    Array.Clear(buff, 0, buff.Length);
                    
                }
            }
            catch (Exception e)
            {
                DisconnectClient(client);
                Debug.WriteLine("[-] Exception: " + e.ToString());
            }
        }

        private void ReadingHandler(string recivedText, TcpClient client)
        {
            // For future acknowledgment purposes
            if (recivedText.StartsWith("Ack"))
            {

            } 
            // To clear the notifications from the recepient queue
            else if (recivedText.StartsWith("Clear"))
            {
                _helper.ClearNotification(recivedText, client);
            }
            // For subscription of groups
            else if (recivedText.StartsWith("Subscription"))
            {
                _helper.SetSubscriptions(recivedText, client);
            }
            // For client identity validation
            else
            {
                if (!loginedClients.ContainsKey(client))
                {
                    loginedClients.Add(client, recivedText);
                }
                var userId = _helper.VerifyIdentiy(recivedText);
                var subscriptions = _helper.GetSubscriptions(userId);
                byte[] response = userId != 0 ? Encoding.ASCII.GetBytes("true" + subscriptions) : Encoding.ASCII.GetBytes("false" + subscriptions);

                Send(response, client);
                int milliseconds = 1000;
                Thread.Sleep(milliseconds);

                // If user is valid
                if (userId != 0)
                {
                    var notifications = _helper.GetNotifications(userId, recivedText[0]);
                    Send(notifications, client);
                }
            }
        }

        private void DisconnectClient(TcpClient client)
        {
            if (connectedClients.Contains(client))
            {
                connectedClients.Remove(client);
            }

            if (loginedClients.ContainsKey(client))
            {
                loginedClients.Remove(client);
            }
        }
    }
}
