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

        public int IsValidEmail(string email)
        {
            if (_context.Users.Any(u => u.Email == email))
                return _context.Users.Where(u => u.Email == email).Select(u => u.UserId).First();
            else
                return 0;
        }

        public int IsValidPhone(string phone)
        {
            if (_context.Users.Any(u => u.Phone == phone))
                return _context.Users.Where(u => u.Phone == phone).Select(u => u.UserId).First();
            else
                return 0;
        }
    }
}
