using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide.Data
{
    public static class NotificationData
    {
        static List<INotificationEntity> list = new List<INotificationEntity>();
        
        public static INotificationEntity Add(int id, string type, string body, string date)
        {
            INotificationEntity entity = new NotificationEntity();

            entity.Id = id;
            entity.Type = type;
            entity.Notification = body;
            entity.Date = DateTime.Parse(date);
            list.Add(entity);

            return entity;
        }

        public static void Clear()
        {
            list.Clear();
        }

        public static IList<INotificationEntity> GetAll()
        {
            return list.OrderByDescending(n => n.Date).ToList();
        }

        internal static int GetId(string notification)
        {
            return list.Find(n => n.Notification == notification).Id;
        }
    }
}
