using BusinessLogicLayer.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.Socket
{
    public class SocketHelper
    {
        UserProcessor _uprocessor = new UserProcessor();
        RecipientsProcessor _rprocessor = new RecipientsProcessor();
        UserGroupProcessor _ugProcessor = new UserGroupProcessor();

        internal int VerifyIdentiy(string recivedText)
        {
            return _uprocessor.Identify(recivedText);
        }

        internal byte[] GetNotifications(int userId, char mode)
        {
            return _rprocessor.GetNotifications(userId, mode);
        }

        internal string GetSubscriptions(int userId)
        {
            return _ugProcessor.GetSubscriptions(userId);
        }

        internal void SetSubscriptions(string newSubscriptions, TcpClient client)
        {
            // Extracting userId
            var userId = VerifyIdentiy(ServerSocket.loginedClients[client]);

            // Clear Old subscriptions and Set New Subscription groups for this userId
            _ugProcessor.SetSubscriptions(newSubscriptions, userId);
        }

        internal void ClearNotification(string recivedText, TcpClient client)
        {
            // Extracting userId
            var userId = VerifyIdentiy(ServerSocket.loginedClients[client]);

            // Clearing Notification from recipients queue
            var notifId = recivedText.Split(':')[3];
            _rprocessor.ClearNotification(userId, notifId);
        }
    }
}
