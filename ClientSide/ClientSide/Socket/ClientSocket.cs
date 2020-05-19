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
                //NetworkStream networkStream = client.GetStream();
                
                char[] buff = new char[1024];
                int readByteCount = 0;
                //buff = client.GetStream()

                while (true)
                {
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);
                    //readByteCount = client.ReceiveBufferSize;
                    
                    if (readByteCount <= 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        client.Close();
                        break;
                    } else
                    {
                        var receivedData = new String(buff);
                        receivedData = receivedData.Replace("\0", string.Empty);
                        //await networkStream.ReadAsync(buff, 0, client.ReceiveBufferSize);
                        OnDataReceived(receivedData);
                        //Debug.WriteLine(SocketHelper.ByteArrayToObject<NotificationEntity>(buff));
                    }
                    //Console.WriteLine(string.Format("Received bytes: {0} - Message: {1}",
                    //    readByteCount, new string(buff)));

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
