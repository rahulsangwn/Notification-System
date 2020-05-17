using DataAccessLayer;
using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Processor
{
    public class NotificationProcessor
    {
        NotificationTypesAccess _type = new NotificationTypesAccess();
        NotificationsAccess _notification = new NotificationsAccess();
        RecipientsAccess _recipient = new RecipientsAccess();
        UserGroupAccess _group = new UserGroupAccess();

        public void CreateNotification(string typeName, string content)
        {
            Debug.WriteLine($"[+] Type: {typeName}, Content: {content}");

            // Get notification type
            var type = _type.Get(typeName); 

            Notification notification = new Notification();
            notification.CreateDate = DateTime.Now;
            notification.NotifBody  = content;
            notification.TypeId     = type.TypeId;

            // Create entry in Notification table
            var notifId = _notification.Create(notification);

            // Get list of user who subscribed this type of event
            var users = _group.GetUserList(type.TypeId);

            // Insert notification for each user in Recipients queue
            foreach (var user in users)
            {
                Recipient recipient = new Recipient();
                recipient.UserId = user;
                recipient.CommModes = type.CommModes;
                recipient.ReceivedModes = 0;
                recipient.ClearedModes = 0;
                recipient.NotifId = notifId;

                _recipient.Create(recipient);
            }

            Debug.WriteLine("[>] Notification Pushed to Clients");
        }
    }
}
