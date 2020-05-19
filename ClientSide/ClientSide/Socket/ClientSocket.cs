using ClientSide.Data;
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

        public ClientSocket()
        {

        }
        
        public event EventHandler<DataRecEventArgs> DataReceived;
        protected virtual void OnDataReceived()
        {
            DataReceived?.Invoke(this, new DataRecEventArgs() { text = "mydata"});
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
                char[] buff = new char[64];
                int readByteCount = 0;

                while (true)
                {
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);

                    if (readByteCount <= 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        client.Close();
                        break;
                    } else
                    {
                        OnDataReceived();
                    }
                    Console.WriteLine(string.Format("Received bytes: {0} - Message: {1}",
                        readByteCount, new string(buff)));

                    //OnRaiseTextReceivedEvent(
                    //new TextReceivedEventArgs(
                    //mClient.Client.RemoteEndPoint.ToString(),
                    //new string(buff)));


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
