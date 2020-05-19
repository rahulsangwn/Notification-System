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

        public List<byte[]> GetNotifications(int userId)
        {
            var queue = _recipients.Get(userId);

            List<byte[]> notifications = new List<byte[]>();
            foreach(var item in queue)
            {
                StringBuilder itemString = new StringBuilder();
                itemString.Append("Notification ");
                itemString.Append(item.NotifId + " ");
                itemString.Append(_notification.Get(item.NotifId).NotifBody + ".");

                var notification = Encoding.ASCII.GetBytes(itemString.ToString());
                notifications.Add(notification);
            }

            return notifications;
        }
    }
}
