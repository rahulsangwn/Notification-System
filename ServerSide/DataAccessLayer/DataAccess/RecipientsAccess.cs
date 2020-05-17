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
    }
}
