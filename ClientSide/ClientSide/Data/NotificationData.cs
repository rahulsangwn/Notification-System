using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide.Data
{
    public static class NotificationData
    {
        static List<NotificationEntity> list = new List<NotificationEntity>();
        
        public static NotificationEntity Add(int id, string type, string body, string date)
        {
            NotificationEntity entity = new NotificationEntity();

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

        public static IList<NotificationEntity> GetAll()
        {
            return list.OrderByDescending(n => n.Date).ToList();
        }

        internal static int GetId(string notification)
        {
            return list.Find(n => n.Notification == notification).Id;
        }
    }
}
