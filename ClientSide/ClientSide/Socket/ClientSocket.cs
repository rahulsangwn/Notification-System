﻿using ClientSide.Data;
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
    public class ClientSocket : IClientSocket
    {
        IPAddress serverIP;
        int serverPort;
        TcpClient client;

        public async Task SendData(byte[] data)
        {
            if(client != null)
            {
                var stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
            }
        }
        
        public event EventHandler<DataRecEventArgs> DataReceived;
        protected virtual void OnDataReceived(string receivedData)
        {
            DataReceived?.Invoke(this, new DataRecEventArgs() { text = receivedData.ToString()});
        }

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

                ReadDataAsync(client);

                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }

        private async void ReadDataAsync(TcpClient client)
        {
            try
            {
                StreamReader clientStreamReader = new StreamReader(client.GetStream());
                
                char[] buff = new char[1024 * 1024];
                int readByteCount = 0;

                while (true)
                {
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);
                    
                    if (readByteCount <= 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        client.Close();

                        // Closing the application
                        System.Windows.Forms.Application.Exit();

                        break;
                    } else
                    {
                        var receivedData = new String(buff);
                        receivedData = receivedData.Replace("\0", string.Empty);
                        OnDataReceived(receivedData);
                    }
                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
                throw;
            }
        }
    }
}
