using System;
using System.Net;
using System.Threading.Tasks;
using ClientSide.Data;

namespace ClientSide.Socket
{
    public interface IClientSocket
    {
        event EventHandler<DataRecEventArgs> DataReceived;

        Task<bool> ConnectToServer(IPAddress ip, int port);
        Task SendData(byte[] data);
    }
}