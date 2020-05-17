using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class UserGroupAccess
    {
        NotificationContext _context = new NotificationContext();

        public int[] GetUserList(int typeId)
        {
            return _context.UserGroups.Where(u => u.TypeId == typeId).Select(u => u.UserId).ToArray();
        }
    }
}
