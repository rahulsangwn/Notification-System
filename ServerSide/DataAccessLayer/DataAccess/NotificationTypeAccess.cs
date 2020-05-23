using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class NotificationTypesAccess
    {
        readonly NotificationContext _context;
        public NotificationTypesAccess()
        {
            _context = new NotificationContext();
        }

        public NotificationType Get(string type)
        {
            if(_context.NotificationTypes.Any(t => t.Name == type))
            {
                return _context.NotificationTypes.First(t => t.Name == type);
            }

            return null;
        }

        public string GetName(int typeId)
        {
            return _context.NotificationTypes.Where(t => t.TypeId == typeId).Select(t => t.Name).First();
        }
    }
}
