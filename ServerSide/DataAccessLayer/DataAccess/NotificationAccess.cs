using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class NotificationsAccess
    {
        NotificationContext _context = new NotificationContext();

        public int Create(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return notification.NotifId;
        }
    }
}
