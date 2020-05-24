using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class RecipientsAccess
    {
        NotificationContext _context = new NotificationContext();

        public bool Create(Recipient recipient)
        {
            _context.Recipients.Add(recipient);
            _context.SaveChanges();
            return true;
        }

        public List<Recipient> Get(int userId)
        {
            return _context.Recipients.Where(r => r.UserId == userId).ToList();
        }

        public void Clear(int userId, int notifId)
        {
            var notification = _context.Recipients.FirstOrDefault(r => r.UserId == userId && r.NotifId == notifId);
            _context.Recipients.Remove(notification);
            _context.SaveChanges();
        }
    }
}
