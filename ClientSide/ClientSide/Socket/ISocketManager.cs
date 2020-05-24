using System.Threading.Tasks;

namespace ClientSide.Socket
{
    public interface ISocketManager
    {
        Task<bool> IsValidUser(string user);
        void SendData(string data);
    }
}