using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Processor
{
    public class RecipientsProcessor
    {
        RecipientsAccess _recipients = new RecipientsAccess();
        NotificationsAccess _notification = new NotificationsAccess();
        NotificationTypesAccess _type = new NotificationTypesAccess();
        CommunicationModesAccess _mode = new CommunicationModesAccess();
        UserProcessor _uprocessor = new UserProcessor();

        public byte[] GetNotifications(int userId, char mode)
        {
            var queue = _recipients.Get(userId);

            StringBuilder itemString = new StringBuilder();
            foreach (var item in queue)
            {
                // Get notification for apropriate communication mode only
                if (_mode.GetName(item.CommModes).Contains(mode))
                {
                    var notification = _notification.Get(item.NotifId);
                    itemString.Append("Notification,");
                    itemString.Append(item.NotifId + ",");
                    itemString.Append(_type.GetName(notification.TypeId) + ",");
                    itemString.Append(notification.NotifBody + ",");
                    itemString.Append(notification.CreateDate.ToShortDateString());
                    itemString.Append(":");
                }
            }
            return Encoding.ASCII.GetBytes(itemString.ToString().Remove(itemString.Length - 1, 1));
        }

        public byte[] FetchUserNotification(string communication, int notifId)
        {
            communication = communication.Replace("\0", string.Empty);
            char mode = communication[0];

            // Get the User Id 
            int userId = _uprocessor.Identify(communication);

            var notification = _recipients.Get(userId).FirstOrDefault(n => n.NotifId == notifId);

            StringBuilder itemString = new StringBuilder();
            if (notification != null)
            {
                if (_mode.GetName(notification.CommModes).Contains(mode))
                {
                    itemString.Append("Notification ");
                    itemString.Append(notification.NotifId + " ");
                    itemString.Append(_notification.Get(notification.NotifId).NotifBody);
                }
            }

            if(notification == null || String.IsNullOrEmpty(itemString.ToString()))
            {
                return null;
            }
            return Encoding.ASCII.GetBytes(itemString.ToString());
        }
    }
}
