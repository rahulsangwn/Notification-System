using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class UserAccess
    {
        NotificationContext _context = new NotificationContext();

        public bool IsValidEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsValidPhone(string phone)
        {
            return _context.Users.Any(u => u.Phone == phone);
        }
    }
}
